using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class UserCoursesBLL
    {
        /// <summary>
        /// 获得userid这个用户所有的有效期内的课程数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserCourses> GetUsableCourses(long userId)
        {
            return dal.GetUsableCourses(userId);
        }
    }
}
