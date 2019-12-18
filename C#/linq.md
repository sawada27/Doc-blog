1.判断是否为空或者null

string.IsNullOrEmpty(des.PlateNum)————————>sql server的PlateNum is null的判断

from des in db.ModelsVehicleRecognition where (!string.IsNullOrEmpty(des.PlateNum)) select new { plateMun = des.PlateNum }

等同于

SELECT PlateNum FROM VehicleRecognition WHERE PlateNum IS NOT NULL

2.普通包含模糊查询

1）以某字符串开头的模糊查询

des.PlateNum.StartsWith("皖A8") ————————>sql server 的   like '皖A8%'

from des in db.ModelsVehicleRecognition where (des.PlateNum.StartsWith("皖A8")) select new { plateMun = des.PlateNum }

等同于

SELECT PlateNum FROM VehicleRecognition WHERE PlateNum  like '皖A8%'

2）以某字符串结尾的模糊查询

des.PlateNum.EndsWith("68T") ————————>sql server 的   like '%68T'

from des in db.ModelsVehicleRecognition where (des.PlateNum.EndsWith("68T")) select new { plateMun = des.PlateNum }

等同于

SELECT PlateNum FROM VehicleRecognition WHERE PlateNum  like '%68T'

3）包含某字符串的模糊查询

des.PlateNum.Contains("A3") ————————>sql server 的   like '%A3%'

from des in db.ModelsVehicleRecognition where (des.PlateNum.Contains("A3")) select new { plateMun = des.PlateNum }

等同于

SELECT PlateNum FROM VehicleRecognition WHERE PlateNum  like '%A3%'

3.精确到字符串对应位数字符的模糊查询（*重点）

SqlFunctions.PatIndex("_a__3%", des.PlateNum) > 0————————>sql server 的   like '_a__3%'

from des in db.ModelsVehicleRecognition where (SqlFunctions.PatIndex("_a__3%", des.PlateNum) > 0) select new { plateMun = des.PlateNum }

等同于

SELECT PlateNum FROM VehicleRecognition WHERE PlateNum  like '_a__3%'

说明：'_a__3%' 中的下划线“_”表示一个字符，'_a__3%' 这个字符串查询意思就是第二个字符是a,第五个字符是3的字符串

       因为a和3之间有两个下划线“_”所以查询出的结果也要满足a和3之间有两个字符才行，

       也就是说两个精确字符之间隔了几个字符，在查询的时候就要写几个下划线“_”。
