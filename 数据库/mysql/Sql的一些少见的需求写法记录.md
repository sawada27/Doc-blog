# Sql的一些少见的需求写法记录

## 区分大小写

mysql可以在SQL语句中加入 binary来区分大小写。BINARY不是函数，是类型转换运算符，它用来强制它后面的字符串为一个二进制字符串，可以理解为在字符串比较的时候区分大小写。

### 查询语句上加binary

```
    select
    *
    from users
    WHERE binary user_name = '张三'
    AND status != 0
```

### 建表时加binary

```
    create table t{
    code varchar(10)  binary
    }
```

## 按字段指定顺序排序 
### Field函数

```
order by FIELD(COLUMNNAME,col1,col2,col3);
order by FIELD(ADDRESS,'北京','上海','广东','深圳') desc
```
数据结果按照指定的列（字段排序） 上面例子按北上广深的顺序排 desc表示置顶

### locate函数
locate的用法和field很相似，只是locate是判断字符串的内容是否包含在指定的字符串里。下面是详细讲解
```
locate(subString,string)
order by locate(ADDRESS,'北京,上海,广东,深圳')
```
判断字符串string是否包含另一个字符串subStr，函数返回subStr在string中的位置
以北上广深在这个字符串中的位置进行排序 排序顺序按字符串中的位置决定

