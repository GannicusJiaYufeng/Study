using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class CoursesBLL
    {
        /// <summary>
        /// 是不是有这个名字的课程了
        /// </summary>
        public bool IsHaveName(string name)
        {
            return dal.IsHaveName(name) > 0;
        }
    }
}
