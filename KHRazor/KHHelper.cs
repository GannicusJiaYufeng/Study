﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Text;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Web;

namespace KHRazor
{
    //piblic才可以在其他项目（程序集）中引用
    //否则只能在当前程序集使用
    public class KHHelper
    {
        public static string ParseRazor(HttpContext context,
           string csHtmlVirtualPath, object model = null)
        {
            string fullpath = context.Server.MapPath(csHtmlVirtualPath);
            string cshtml = File.ReadAllText(fullpath);
            string cacheName = fullpath + File.GetLastWriteTime(fullpath);
            string html = Razor.Parse(cshtml, model, cacheName);
            return html;
        }

        //偷懒  调用上面，输出语句都省了
        public static void OutputRazor(HttpContext context,
            string csHtmlVirtualPath, object model = null)
        {
            string html = ParseRazor(context, csHtmlVirtualPath, model);
            context.Response.Write(html);
        }

        public static RawString Raw(string str)
        {
            return new RawString(str);
        }
        public static RawString Include(string virtualPath)
        {
            string filepath = HttpContext.Current.Server.MapPath(virtualPath);
            string html = File.ReadAllText(filepath, System.Text.Encoding.UTF8);
            return Raw(html);
        }

        //说明：参数默认值：object extProperties=null
        public static RawString CheckBox(bool isChecked, object extProperties = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type='checkbox' ");
            if (extProperties != null)
            {
                sb.Append(RenderExtendProperties(extProperties));
            }
            if (isChecked)
            {
                sb.Append(" checked");
            }
            sb.Append(" />");
            return new RawString(sb.ToString());
        }

        public static string RenderExtendProperties(object extenedProperties)
        {
            StringBuilder sb = new StringBuilder();
            Type extenedPropertiesType = extenedProperties.GetType();
            PropertyInfo[] extPropInfos = extenedPropertiesType.GetProperties();//获得类型的属性
            foreach (var extPropInfo in extPropInfos)
            {
                string extPropName = extPropInfo.Name;//属性名
                object extPropValue = extPropInfo.GetValue(extenedProperties);//属性值
                sb.Append(" ").Append(extPropName).Append("='").Append(extPropValue).Append("' ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 判断value是否在items中存在
        /// </summary>
        /// <param name="items"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool Contains(IEnumerable items, object value)
        {
            foreach (var item in items)
            {
                if (object.Equals(value, item))  //判断对象实例是否相等
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items">checkbox有哪些项</param>
        /// <param name="valuePropName"></param>
        /// <param name="textPropName"></param>
        /// <param name="selectedValues">被选中的值</param>
        /// <param name="name">checkbox的name属性</param>
        /// <returns></returns>
        public static RawString CheckBoxList(IEnumerable items, string valuePropName, string textPropName,
            IEnumerable selectedValues, string name)
        {
            StringBuilder sb = new StringBuilder();
            //下面生成option
            int i = 0;
            foreach (Object item in items)
            {
                Type itemType = item.GetType();//获得对象的类型描述

                PropertyInfo valuePropInfo = itemType.GetProperty(valuePropName);//拿到valuePropName("Id")的属性描述
                object itemValueValue = valuePropInfo.GetValue(item);//获得的就是item 对象的"Id"的值(具体id的值)

                PropertyInfo textPropInfo = itemType.GetProperty(textPropName);//拿到"Name"的属性
                object itemTextValue = textPropInfo.GetValue(item);//拿到itme的"Name"属性的值（具体name的值）

                //等于selectedValue的项增加一个"selected"属性，它被选中
                string inputId = name + i;
                sb.Append("<input type='checkbox' id='" + inputId + "' name='" + name + "'  value='").Append(itemValueValue).Append("'");
                if (Contains(selectedValues, itemValueValue))
                {
                    sb.Append(" checked");
                }
                sb.Append("/>").Append("<label for='" + inputId + "'>" + itemTextValue + "</label>");

                i++;
            }
            return new RawString(sb.ToString());
        }


        //Person[] persons = ....
        //DowDownList(persons,"Id","Name",3,new{id="managerId",name="m1",style="color:red"});
        //<select id="managerId" name="m1" style="color:red">
        //  <option value="1">rupeng</option>
        //</select>
        public static RawString DropDownList(IEnumerable items, string valuePropName, string textPropName,
            object selectedValue, object extenedProperties = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<select ");

            /*
            //扩展属性可以各个控件通用
            //下面用来生成扩展属性
            Type extenedPropertiesType = extenedProperties.GetType();
            PropertyInfo[] extPropInfos = extenedPropertiesType.GetProperties();//获得类型的属性
            foreach (var extPropInfo in extPropInfos)
            {
                string extPropName = extPropInfo.Name;//属性名
                object extPropValue = extPropInfo.GetValue(extenedProperties);//属性值
                sb.Append(" ").Append(extPropName).Append("='").Append(extPropValue).Append("' ");
            }*/
            if (extenedProperties != null)
            {
                sb.Append(RenderExtendProperties(extenedProperties));
            }

            sb.Append(">");
            foreach (Object item in items)
            {
                Type itemType = item.GetType();//获得对象的类型描述

                PropertyInfo valuePropInfo = itemType.GetProperty(valuePropName);//拿到valuePropName("Id")的属性描述
                object itemValueValue = valuePropInfo.GetValue(item);//获得的就是item 对象的"Id"的值

                PropertyInfo textPropInfo = itemType.GetProperty(textPropName);//拿到"Name"的属性
                object itemTextValue = textPropInfo.GetValue(item);//拿到itme的"Name"属性的值

                //等于selectedValue的项增加一个"selected"属性，它被选中
                sb.Append("<option value='").Append(itemValueValue).Append("'");
                if (Object.Equals(itemValueValue, selectedValue))
                {
                    sb.Append(" selected");
                }
                sb.Append(">").Append(itemTextValue).Append("</option>");

            }
            sb.Append("</select>");
            return new RawString(sb.ToString());
        }
        /// <summary>
        /// 生成页码的html
        /// </summary>
        /// <param name="urlFormat">超链接的格式。list.ashx?pagenum={pagenum}。地址中用{pagenum}做为当前页码的占位符</param>
        /// <param name="totalSize">总数据条数</param>
        /// <param name="pageSize">每页多少条数据 </param>
        /// <param name="currentPage">当前页的页码</param>
        /// <returns></returns>
        public static RawString Pager(string urlFormat, long totalSize,
            long pageSize, long currentPage)
        {
            StringBuilder sb = new StringBuilder();  //currentPage当前页的页面。在当前页之前显示最多5个、之后显示最多5个。
            // 15,16,17,18,19,(20),21,22,23,24,25
            // 1,2,(3),4,5,6,7,8
            //一共50页， 43,44,45,46,,47(48),49,50
            //for(int i=)

            //总页数
            long totalPageCount = (long)Math.Ceiling((totalSize * 1.0f) / (pageSize * 1.0f));
            //58*1.0f/10*1.0f=5.8，6
            //60*1.0f/10*.1.f=6
            //61*1.0f/10*1.0f=6.1=7
            //在当前页面前后各最多显示5个页码
            //计算页码条中第一条的页码
            long firstPageNum = Math.Max(currentPage - 5, 1);
            //计算页码条中最后一条的页码
            long lastPageNum = Math.Min(currentPage + 5, totalPageCount);
            sb.AppendLine("<li><a href='" +
                urlFormat.Replace("{pagenum}", "1") + "'>首页</a></li>");
            for (long i = firstPageNum; i <= lastPageNum; i++)
            {
                string url = urlFormat.Replace("{pagenum}", i.ToString());
                if (i == currentPage)
                {
                    sb.Append("<li class='active'><a>" + i + "</a></li>");
                }
                else
                {
                    sb.Append("<li><a href='" + url + "'>" + i + "</a></li>");
                }
            }
            sb.AppendLine("<li><a href='" +urlFormat.Replace("{pagenum}", totalPageCount.ToString()) + "'>末页</a></li>");
            return new RawString(sb.ToString());
        } 
    }
}
