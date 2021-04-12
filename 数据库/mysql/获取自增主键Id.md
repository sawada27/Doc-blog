# MAX 
容易出现并发问题 弃用

# @@Identity
单次连接有效 限制Insert
```
Insert into servers(`InstanceId`,`IPAddress`,`Cluster`,`AppType`,`Environment`) values ('test','test','test','test','test1');
select @@IDENTITY;
```
# last_insert_id();
产生的ID 每次连接后保存在服务器中。
这意味着函数向一个给定客户端返回的值是该客户端产生对影响AUTO_INCREMENT列的最新语句第一个 AUTO_INCREMENT值的。
这个值不能被其它客户端影响，即使它们产生它们自己的 AUTO_INCREMENT值。这个行为保证了你能够找回自己的 ID 而不用担心其它客户端的活动，而且不需要加锁或处理。 
每次mysql_query操作在mysql服务器上可以理解为一次“原子”操作, 写操作常常需要锁表的， 是mysql应用服务器锁表不是我们的应用程序锁表。
值得注意的是，如果你一次插入了多条记录，这个函数返回的是第一个记录的ID值。
因为LAST_INSERT_ID是基于Connection的，只要每个线程都使用独立的Connection对象，LAST_INSERT_ID函数 将返回该Connection对AUTO_INCREMENT列最新的insert or update操作生成的第一个record的ID。

这个值不能被其它客户端（Connection）影响，保证了你能够找回自己的 ID 而不用担心其它客户端的活动，而且不需要加锁。使用单INSERT语句插入多条记录,  LAST_INSERT_ID返回一个列表。
LAST_INSERT_ID 是与table无关的，如果向表a插入数据后，再向表b插入数据，LAST_INSERT_ID会改变。
```
select last_insert_id();
```
