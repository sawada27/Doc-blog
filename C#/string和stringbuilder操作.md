# 截取 
```
  1  string str3 = "123abc456";
 2 
 3  //str3 = str3.Substring(0, i);  //从左边开始取字符串的前i个字符(str3 = str3.Remove(i, str3.Length - i);)
 4  str3 = str3.Substring(0, 3);
 5  str3 = str3.Remove(3, str3.Length - 3);
 6  //输出："123"
 7 
 8  //str3 = str3.Substring(i);     //从左边开始去掉字符串的前i个字符(str3=str3.Remove(0,i);)
 9  str3 = str3.Substring(3);
10  //输出："abc456"11 
12  //str3 = str3.Substring(str3.Length - i);  //从右边开始取i个字符(str3=str3.Remove(0,str3.Length-i))
13  str3 = str3.Substring(str3.Length - 3);
14  //输出："456"
15 
16  //str3 = str3.Substring(0, str3.Length - i); //从右边开始去掉i个字符(str3=str3.Remove(str3.Length-i,i))
17  str3 = str3.Substring(0, str3.Length - 3);
18  //输出："123abc"
```
# Trim去空格
```
 1   string str = " I Believe You Very Much! ";
 2   str = str.TrimStart();                                  //截取掉字符串首部的空格
 3   //输出："I Believe You Very Much! "
 4 
 5   str = str.TrimStart('I');                               //截取掉字符串第一个字符
 6   //输出："Believe You Very Much! "
 7 
 8   str = str.TrimStart().TrimStart("Beli".ToCharArray());  //截取掉字符串首部及尾部出现的B或e或l或i字符,删除的过程直到碰到一个既不是B也不是e也不是l也不是i的字符才结束。
 9   //输出："ve You Very Much! "
10             
11   string str1 = " I Believe You Very Much! ";
12   str = str1.Trim();                                      //截取掉字符串首部和尾部的空格
13   //输出："I Believe You Very Much!"
14             
15   //TrimEnd的方法和TrimStart原理一样不多赘述
16   string str2 = " I Believe You Very Much! ";
17   str = str2.TrimEnd();                                   //截取掉字符串首部和尾部的空格
18   //输出：" I Believe You Very Much!"
```
# 替换
```
1   string str5 = "123abc456efg";
2   str5 = str5.Replace("efg", "EFG");
3   //输出："123abc456EFG"
```
# 分割-字符串数组
1    string str6 = "123,abc,456,efg";
2    string[] str6s = str6.Split(',');
3    foreach (var item in str6s)
4    {
5          ConsoleStr(item);
6    }
7    //输出："123 abc 789 efg"

# 链接
```
1 //结合split里面的字符串数组str6s
2 string str7 = string.Join("-", str6s);
3 //输出："123-abc-456-efg"
```
# 转换大小写
```
1  string str8 = "abcdefgHIJK";
2  str8 = str8.ToUpper();
3  //输出："ABCDEFGHIJK"
4 
5  str8 = str8.ToLower();
6  //输出："abcdefghijk"
7 
8  bool isUpper = char.IsUpper(str8, 8);
9  //输出："True"
```
# 比较
```
 1   string str10 = "abackhdk";
 2 
 3   string str9 = "abac";
 4   int aa = str9.CompareTo(str10);
 5    //输出："-1"
 6 
 7   string str11 = "b";
 8   int bb = str11.CompareTo(str10);
 9   //输出："1"
10 
11   string str12 = "abackhdk";
12   int cc = str12.CompareTo(str10);
13   //输出："0"
```
# 查找
```
1 str.IndexOf(子串，查找其实位置) ;
2 str.LastIndexOf(子串) ;最后一次出现的位置
3 str.IndexOf("ab",0);
```
# 插入
```
1 str.Insert(插入位置，插入子串) ;
2 s.Insert(2,"ab");
```
# 移除
```
1 str.Remove（其实位置，移出数）;
2 s.Remove(3,2);
```
# 关于stringbuilder
```
　　StringBuilder sb=new StringBuilder(”Hello,Welcome”,100);//初始化对象并设置初始容量为100
       sb.Append(” to www.sinory.com”);
       sb.Replace(old,new);//将old替换为new,作用与String.Replace()一样只是不需要在过程中复制字符。


　　StringBuilder的成员：
     　　StringBuilder sb=new StringBuilder(”www.google.com”);//定义初值为www.google.com的对象。
     　　StringBuilder sb=new StringBuilder(20);//初始化容量为20的空对象。
　　另外StringBuilder还有MaxCapacity属性用来限定对象可以使用的最大容量。默认大约是int.MaxValue（20亿）
     可以在使用过程中定义sb.MaxCapacity=value;
     sb.Append()——给当前字符串追加字符串。
     sb.AppendFormat()——添加特定格式的字符串
     sb.Insert()——插入一个子字符串
     sb.Remove()——从当前字符串删除字符
     sb.Replace()——替换字符串中指定的字符
     sb.ToString()——将sb转化为String 对象
```
