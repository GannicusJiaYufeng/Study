using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KH.Admin
{
    [AttributeUsage(AttributeTargets.Method)]  //这让这个Attribute只能作用于方法上
    public class PowerActionAttribute:Attribute
    {
        public string Name { get; set; }
        public PowerActionAttribute(string name)
        {
            this.Name = name;
        }
    }
}