using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class RolesBLL
    {
        /// <summary>
        /// 判断是否存在这个名字的Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsHaveRole(string name)
        {
            return dal.IsHaveRole(name) > 0;
        }
    }
}
