# 测试数据
```
List<string> li1 = new List<string> { "8", "8", "9", "9" ,"0","9"};
List<string> li2 = new List<string> { "张三", "张三", "李四", "张三", "王五", "李四" };
List<string> li3 = new List<string> { "A", "A", "C", "A", "C", "D" };
List<string> li4 = new List<string> { "12", "18", "19", "19", "10", "19" };
```

## 方法1：hashset
```
HashSet<string> hs = new HashSet<string>(li1); //此时已经去掉重复的数据保存在hashset中
```
 
## 方法2:循环比较

```
for (int i = 0; i < li2.Count; i++)  //外循环是循环的次数
            {
                for (int j = li2.Count - 1 ; j > i; j--)  //内循环是 外循环一次比较的次数
                {

                    if (li2[i] == li2[j])
                    {
                        li2.RemoveAt(j);
                    }

                }
            }
```
            
## 方法3
```
 List<string> li1 = new List<string> { "8", "8", "9", "8", "0", "9" };
            li1 = li1.Distinct().ToList();

```
