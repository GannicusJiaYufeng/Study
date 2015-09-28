using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace KHCommons
{
    public class AjaxHelper
    {
        /// <summary>
        /// .net对象转换为json字符串返回
        /// </summary>
        /// <param name="response"></param>
        /// <param name="status1"></param>返回给浏览器的状态码
        /// <param name="msg1"></param>返回给浏览器的信息
        /// <param name="data1"></param>返回给浏览器的对象数据
        public static void WriteJson(HttpResponse response,string status1,string msg1,object data1=null)
        {
            response.ContentType = "application/json";
            var obj = new { status = status1, msg = msg1, data = data1 };
            string json = new JavaScriptSerializer().Serialize(obj);
            response.Write(json);
        }


    }
}
