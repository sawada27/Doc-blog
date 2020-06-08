using System;
using Newtonsoft.Json.Linq;

namespace ChatPay
{
    class JsonStudy
    {
        public void demo()
        {
            string jsonStr = "";//Json Str字符串
            JToken json = JToken.Parse(jsonStr);//转化为JToken（JObject基类）

            string xx = json.Value<string>("xx");//获取Json里xx键的值

            JToken arr = json["arr"];//获取Json里的数组  {arr:[{yy:1,zz:2},{yy:3,zz:4}]}

            foreach (JToken baseJ in arr)//遍历数组
            {
                int yy = baseJ.Value<int>("yy");
            }

            string yy1 = json["arr"][0].Value<string>("yy");//也可以多层的获取

            string yy2 = json["arr"][0]["yy"] != null ? json["arr"][0]["yy"].ToString() : "";//这个和上面句等价,不要直接ToString，容易报错


            /*JToken 不能实例化，若要生成新的Json，使用Jobject*/

            JObject newJson = new JObject();
            newJson["aa"] = "xxxx";//输入键值，赋值时键不能重复调用,如newJson["aa"]["bb"]酱紫不行

            JObject newJson2 = new JObject();
            newJson2["cc"] = "vbbb";
            newJson2["bb"]="dd";

            newJson["dd"] = newJson2;//完成多层Json的生成

        }

    }
}
