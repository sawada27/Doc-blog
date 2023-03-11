## 添加
```
// .Net 6
builder.Services.AddHostedService<TestHostedService>();

// .Net  5 及以下
services.AddHostedService<TestHostedService>();
```
## 使用
开始执行StartAsync 结束StopAsync
```
public class TestHostedService : IHostedService, IDisposable
{
    private Timer? _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StopAsync");

        return Task.CompletedTask;
    }


    public void Dispose()
    {
        _timer?.Dispose();
    }
}
```
应仅限于短期任务，因为托管服务是按顺序运行的，在 StartAsync 运行完成之前不会启动其他服务。
- 已配置应用的请求处理管道。
- 已启动服务器且已触发 IApplicationLifetime.ApplicationStarted。

如果应用意外关闭（例如，应用的进程失败），则可能不会调用 StopAsync。 因此，在 StopAsync 中执行的任何方法或操作都可能不会发生。

### BackgroundService 是用于实现长时间运行的 IHostedService 的基类。

调用 ExecuteAsync(CancellationToken) 来运行后台服务。 实现返回一个 Task，其表示后台服务的整个生存期。

在 ExecuteAsync 变为异步（例如通过调用 await）之前，不会启动任何其他服务。 避免在 ExecuteAsync 中执行长时间的阻塞初始化工作。 

StopAsync(CancellationToken) 中的主机块等待完成 ExecuteAsync。

调用 IHostedService.StopAsync 时，将触发取消令牌。 当激发取消令牌以便正常关闭服务时，ExecuteAsync 的实现应立即完成。 否则，服务将在关闭超时后不正常关闭。

StartAsync 应仅限于短期任务，因为托管服务是按顺序运行的，在 StartAsync 运行完成之前不会启动其他服务。 长期任务应放置在 ExecuteAsync 中。

## BackGroundService源码
 ``` 
public abstract class BackgroundService : IHostedService, IDisposable
{
    private Task _executingTask;
    private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();

    /// <summary>
    /// This method is called when the <see cref="IHostedService"/> starts. The implementation should return a task that represents
    /// the lifetime of the long running operation(s) being performed.
    /// /// </summary>
    /// <param name="stoppingToken">Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is called.</param>
    /// <returns>A <see cref="Task"/> that represents the long running operations.</returns>
    protected abstract Task ExecuteAsync(CancellationToken stoppingToken);

    /// <summary>
    /// Triggered when the application host is ready to start the service.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        // Store the task we're executing
        _executingTask = ExecuteAsync(_stoppingCts.Token);

        // If the task is completed then return it, this will bubble cancellation and failure to the caller
        if (_executingTask.IsCompleted)
        {
            return _executingTask;
        }

        // Otherwise it's running
        return Task.CompletedTask;
    }

    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
        // Stop called without start
        if (_executingTask == null)
        {
            return;
        }

        try
        {
            // Signal cancellation to the executing method
            _stoppingCts.Cancel();
        }
        finally
        {
            // Wait until the task completes or the stop token triggers
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }

    }

    public virtual void Dispose()
    {
        _stoppingCts.Cancel();
    }
}
```

```
public class TaskWorkService : ITaskWorkService
{
    public async Task TaskWorkAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            //执行任务
            Console.WriteLine($"{DateTime.Now}");

            //周期性任务，于上次任务执行完成后，等待5秒，执行下一次任务
            await Task.Delay(500);
        }
    }
}
```
　创建后台服务类，继承基类 BackgroundService，这里需要注意的是，要在 BackgroundService 中使用有作用域的服务，请创建作用域， 默认情况下，不会为托管服务创建作用域，得自己管理服务的生命周期，切记！于构造函数中注入 IServiceProvider即可。
 
 ```
 public class BackgroundServiceDemo : BackgroundService
{
    private readonly IServiceProvider _services;

    public BackgroundServiceDemo(IServiceProvider services)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _services.CreateScope();

        var taskWorkService = scope.ServiceProvider.GetRequiredService<ITaskWorkService>();

        await taskWorkService.TaskWorkAsync(stoppingToken);
    }
}
```
注册
```
builder.Services.AddHostedService<BackgroundServiceDemo>();
```
