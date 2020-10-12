# EFcore多线程解决方案

### 方案一：使用using从ioc容器中创建新的dbcontext 。然后用完立即释放。这样就不会占用主线程的dbContext了。
```
/// <summary>
        /// 执行未发布成功的信息
        /// </summary>
        public void ToBePublishs()
        {
            Console.WriteLine("开始执行未发布任务");
            using (var _eventClientDbContext = (EventClientDbContext)ServiceProvider.CreateScope().ServiceProvider.GetService(typeof(EventClientDbContext)))
            {
                var PublishsList = _eventClientDbContext.Publishs.Where(a => a.PublishStatus == false).ToList();
                List<Publishs> publishsList = PublishsList.ToList();
                if (publishsList.Count > 0)
                {
                    Console.WriteLine("开始执行未发布任务,本次任务执行条数为：" + publishsList.Count());
                    using (var tran = _eventClientDbContext.Database.BeginTransaction())
                    {
                        foreach (var PublishsInfo in publishsList)
                        {
                            //var Result = ClientPost(ClientType.Publishs, PublishsInfo);
                            var Result = string.Empty;
                            try
                            {
                                Result = ClientPost(ClientType.Publishs, PublishsInfo);
                                if (Result.Contains("Success"))
                                {
                                    PublishsInfo.PublishStatus = true;
                                    PublishsInfo.ModifyTime = DateTime.Now;
                                    _eventClientDbContext.Publishs.Update(PublishsInfo);
                                    _eventClientDbContext.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("执行未发布成功的信息抛出异常：" + ex.StackTrace + ex.Message);
                                continue;
                            }
                        }
                        tran.Commit();
                    }
                }
            }
            Console.WriteLine("未发布任务End");
        }
```
