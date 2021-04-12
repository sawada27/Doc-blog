# Mysql区分大小写
mysql可以在SQL语句中加入 binary来区分大小写。BINARY不是函数，是类型转换运算符，它用来强制它后面的字符串为一个二进制字符串，可以理解为在字符串比较的时候区分大小写。

## 查询语句上加binary

```
    select
    *
    from users
    WHERE binary user_name = '张三'
    AND status != 0
```

## 建表时加binary

```
    create table t{
    code varchar(10)  binary
    }
```
