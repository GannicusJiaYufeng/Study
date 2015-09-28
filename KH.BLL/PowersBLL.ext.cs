using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class PowersBLL
    {
        /// <summary>
        /// 根据权限名获取权限信息
        /// </summary>
        /// <param name="powername"></param>
        /// <returns></returns>
        public Powers GetByUserName(string powername)
        {
            return dal.GetByUserName(powername);
        }
        /// <summary>
        /// 判断用户名是否存在
        /// </summary> 
        /// <returns></returns>
        public bool IsPowerExists(string powername)
        {
            return GetByUserName(powername) != null;
        }
    }
}
