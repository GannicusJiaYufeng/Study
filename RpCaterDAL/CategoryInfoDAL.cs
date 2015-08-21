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
    public class CategoryInfoDAL
    {

        // <summary>
        /// 根据商品类别的id删除该类别
        /// </summary>
        /// <param name="cId">类别的id</param>
        /// <returns>受影响的行数</returns>
        public int SoftDeleteCategoryByCId(int cId)
        {
            string sql = "update CategoryInfo set DelFlag=1 where CId=" + cId;
            return SqlHelper.ExecuteNonQuery(sql);
        }
        //新增
        public int AddCategoryInfo(CategoryInfo c)
        {
            string sql = "insert into CategoryInfo(CName, CNum, CRemark, DelFlag, SubTime, SubBy)values(@CName, @CNum, @CRemark, @DelFlag, @SubTime, @SubBy)";
            return AddOrUpdateCategoryInfo(c, sql, 1);//新增
        }
        //修改
        public int UpdateCategoryInfo(CategoryInfo c)
        {
            string sql = "update CategoryInfo set CName=@CName, CNum=@CNum, CRemark=@CRemark where CId=@CId";
            return AddOrUpdateCategoryInfo(c, sql, 2);//新增
        }
        private int AddOrUpdateCategoryInfo(CategoryInfo c, string sql, int temp)
        {

            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = { 
                   new SqlParameter("@CName",c.CName),   
                   new SqlParameter("@CNum",c.CNum), 
                   new SqlParameter("@CRemark",c.CRemark)
                               };
            list.AddRange(ps);
            if (temp == 1)//新增
            {
                list.Add(new SqlParameter("@DelFlag", c.DelFlag));
                list.Add(new SqlParameter("@SubTime", c.SubTime));
                list.Add(new SqlParameter("@SubBy", c.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("@CId", c.CId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }


        /// <summary>
        /// 根据删除标识查询所有的商品类别信息
        /// </summary>
        /// <param name="delFlag">删除标识:---0----未删除,1----已经删除</param>
        /// <returns>商品类别对象的集合</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            string sql = "select * from CategoryInfo where DelFlag=" + delFlag;
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            List<CategoryInfo> list = new List<CategoryInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToCategoryInfoByDataRow(dr));
                }
            }
            return list;
        }
        //关系转对象
        private CategoryInfo RowToCategoryInfoByDataRow(DataRow dr)
        {
            CategoryInfo c = new CategoryInfo();
            c.CId = Convert.ToInt32(dr["CId"]);
            c.CName = dr["CName"].ToString();
            c.CNum = dr["CNum"].ToString();
            c.CRemark = dr["CRemark"].ToString();
            c.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            c.SubBy = Convert.ToInt32(dr["SubBy"]);
            c.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return c;
        }

    }
}
