using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class RolePowersBLL
    {
        /// <summary>
        /// 给roleId这个角色，设定权限为powerIds
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="powerIds"></param>
        public void AddRolePowers(long roleId,IEnumerable<long> powerIds)
        {
            foreach (var powerId in powerIds)
            {
                RolePowers rolepower = new RolePowers();
                rolepower.RoleId = roleId;
                rolepower.PowerId = powerId;
                new RolePowersBLL().Add(rolepower);
            }
        }

        /// <summary>
        /// 删除指定id的角色的所有权限
        /// </summary>
        /// <param name="roleId"></param>
         public void CleraRolePowers(long roleId)
        {
            dal.CleraRolePowers(roleId);
        }
        /// <summary>
        /// 查询角色权限表中是否有该角色
        /// </summary>
        /// <param name="id"></param>
        public bool IsHaveRole(long id)
         {
             return dal.IsHaveRole(id) > 0;
         }
        /// <summary>
        /// 判断角色权限表中是否有该权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsHavePower(long id)
        {
            return dal.IsHavePower(id) > 0;
        }
    }
}
