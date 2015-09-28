using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class AdminUserRolesBLL
    {
        /// <summary>
        /// 增加数据到用户角色表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleIds"></param>
        public void AddAdminUserRoles(long userId, IEnumerable<long> roleIds)
        {
            foreach (var id in roleIds)
            {
                AdminUserRoles adminuserrole = new AdminUserRoles()
                {
                    AdminUserId = userId,
                    RoleId = id,
                };

                Add(adminuserrole);
            }
        }
        /// <summary>
        /// 清除指定id的用户的所有角色
        /// </summary>
        public void ClearRoles(long id)
        {
            dal.ClearRoles(id);
        }
        /// <summary>
        /// 给Id这个用户，设定角色为rolesIds
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="rolesIds"></param>
        public void AddRolePowers(long Id, IEnumerable<long> rolesIds)
        {
            foreach (var roleId in rolesIds)
            {
                AdminUserRoles ur = new AdminUserRoles();
                ur.AdminUserId = Id;
                ur.RoleId = roleId;
                Add(ur);
            }
        }
        /// <summary>
        /// 判断用户角色表是否含有这个用户
        /// </summary>
        /// <param name="id"></param>
        public bool IsHaveUser(long id)
        {
            return dal.IsHaveUser(id) > 0;
        }
        /// <summary>
        /// 判断用户角色表是否含有这个角色
        /// </summary>
        /// <param name="id"></param>
        public bool IsHaveRole(long id)
        {
            return dal.IsHaveRole(id) > 0;
        }
    }
}
