using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class NewsCategoriesBLL
    {
        /// <summary>
        /// 判断有没有这个名字的类别了
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         public bool IsHaveName( string name)
        {
           return dal.IsHaveName(name)>0;
        }
    }
}
