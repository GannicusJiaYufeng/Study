using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;

namespace RpCater.Bll
{
    public class MemberTypeBll
    {
        MemberTypeDAL mtDal = new MemberTypeDAL();
        /// <summary>
        /// 根据删除标识查询所有会员类别信息
        /// </summary>
        /// <param name="delFlag">0--未删除，1---已删除</param>
        /// <returns>会员类别对象集合</returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            return mtDal.GetAllMemberTypeByDelFlag(delFlag);
        
        }
    }
}
