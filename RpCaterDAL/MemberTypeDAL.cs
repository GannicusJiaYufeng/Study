using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RpCater.Model;
namespace RpCater.DAL
{
   
    public class MemberTypeDAL
    {
        /// <summary>
        /// 根据删除标识查询所有会员类别信息
        /// </summary>
        /// <param name="delFlag">0--未删除，1---已删除</param>
        /// <returns>会员类别对象集合</returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            string sql = "select *from MemberType where DelFlag=" + delFlag;
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            List<MemberType> list=new List<MemberType>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberTypeByDataRow(dr));
                }
            }
            return list;
        
        }
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private MemberType RowToMemberTypeByDataRow(DataRow dr)
        {
            MemberType mt = new MemberType();
            mt.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            mt.MemType = Convert.ToInt32(dr["MemType"]);
            mt.MemTypeDesc = dr["MemTypeDesc"].ToString();
            mt.MemTypeName = dr["MemTypeName"].ToString();
            mt.SubBy = Convert.ToInt32(dr["SubBy"]);
            return mt;
        }
    }
}
