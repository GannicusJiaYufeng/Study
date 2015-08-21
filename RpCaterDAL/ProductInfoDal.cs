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
    public class ProductInfoDal
    {

        /// <summary>
       /// 根据拼音或者编号搜索---模糊查询
       /// </summary>
       /// <param name="temp">标识：1---拼音搜索,----2-----编号搜索</param>
       /// <param name="name">拼音或者编号</param>
       /// <returns>产品对象的集合</returns>
       public List<ProductInfo> GetProductByProSpellOrProNum(int temp, string name)
       {
           string sql = "select * from productinfo where DelFlag=0";
           if (temp==1)//拼音搜索
           {
               sql += " and ProSpell like @name";
           }
           else if (temp==2)//编号搜索
           {
               sql += " and ProNum like @name";
           }
           DataTable dt= SqlHelper.ExecuteQuery(sql,new SqlParameter("@name","%"+name+"%"));
           List<ProductInfo> list = new List<ProductInfo>();
           if (dt.Rows.Count>0)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   list.Add(RowToProductInfoByDataRow(dr));
               }
           }
           return list;
           }
        /// <summary>
        /// 根据商品的类别的id查询该类别下的所有的没删除的产品
        /// </summary>
        /// <param name="cId">商品类别的id</param>
        /// <returns>产品对象的集合</returns>
        public List<ProductInfo> GetProductInfoByCId(int cId)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and CId=" + cId;
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            List<ProductInfo> list = new List<ProductInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfoByDataRow(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据餐桌的id删除该餐桌
        /// </summary>
        /// <param name="id">餐桌的id</param>
        /// <returns>受影响的行数</returns>
        public int SoftDeleteDeskByDeskId(int id)
        {
            string sql = "update DeskInfo set DelFlag=1 where DeskId=" + id;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据商品类别的id查询产品表中是否有该类别的产品
        /// </summary>
        /// <param name="cId">商品类别的id</param>
        /// <returns>产品的个数</returns>
        public object GetProductInfoCountByCId(int cId)
        {
            string sql = "select count(*) from ProductInfo where CId=" + cId+"and DelFlag=0";
            return SqlHelper.ExecuteScalar(sql);
        }

        /// <summary>
        /// 删除产品信息
        /// </summary>
        /// <param name="proId">产品的id</param>
        /// <returns>受影响的行数</returns>
        public int SoftDeleteByProId(int proId)
        {
            string sql = "update ProductInfo set DelFlag=1 where ProId=" + proId;
            return SqlHelper.ExecuteNonQuery(sql);
        }
        //新增
        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo( CId, ProName, ProCost, ProSpell, ProPrice, ProUnit, Remark, DelFlag, SubTime, ProStock, ProNum, SubBy)values( @CId, @ProName, @ProCost, @ProSpell, @ProPrice, @ProUnit, @Remark, @DelFlag, @SubTime, @ProStock, @ProNum, @SubBy)";
            return AddOrUpdateProductInfo(pro, sql, 1);//新增
        }
        //修改
        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CId=@CId, ProName=@ProName, ProCost=@ProCost, ProSpell=@ProSpell, ProPrice=@ProPrice, ProUnit=@ProUnit, Remark=@Remark,   ProStock=@ProStock, ProNum=@ProNum where ProId=@ProId";
            return AddOrUpdateProductInfo(pro, sql, 2);
        }
        //temp 1---新增,2---修改
        private int AddOrUpdateProductInfo(ProductInfo pro, string sql, int temp)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = {
                  new SqlParameter("@CId",pro.CId),
                  new SqlParameter("@ProName",pro.ProName),
                  new SqlParameter("@ProCost",pro.ProCost),
                  new SqlParameter("@ProSpell",pro.ProSpell),
                  new SqlParameter("@Remark",pro.Remark),
                  new SqlParameter("@ProStock",pro.ProStock),
                  new SqlParameter("@ProNum",pro.ProNum),
                   new SqlParameter("@ProPrice",pro.ProPrice),
                   new SqlParameter("@ProUnit",pro.ProUnit)
                               };
            list.AddRange(ps);//参数存放到集合中

            if (temp == 1)
            {
                list.Add(new SqlParameter("@DelFlag", pro.DelFlag));
                list.Add(new SqlParameter("@SubTime", pro.SubTime));
                list.Add(new SqlParameter("@SubBy", pro.SubBy));

            }
            else if (temp == 2)
            {
                list.Add(new SqlParameter("@ProId", pro.ProId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据删除标识查询所有的产品信息
        /// </summary>
        /// <param name="delFlag">删除标识,0---未删除,1---已经删除了</param>
        /// <returns>产品对象集合</returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            string sql = "select * from ProductInfo where DelFlag=" + delFlag;
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfoByDataRow(dr));
                }
            }
            return list;
        }
        //关系转对象
        private ProductInfo RowToProductInfoByDataRow(DataRow dr)
        {
            ProductInfo pro = new ProductInfo();
            pro.CId = Convert.ToInt32(dr["CId"]);
            pro.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            pro.ProCost = Convert.ToDouble(dr["ProCost"]);
            pro.ProId = Convert.ToInt32(dr["ProId"]);
            pro.ProName = dr["ProName"].ToString();
            pro.ProNum = dr["ProNum"].ToString();
            pro.ProPrice = Convert.ToDouble(dr["ProPrice"]);
            pro.ProSpell = dr["ProSpell"].ToString();
            pro.ProStock = Convert.ToInt32(dr["ProStock"]);
            pro.ProUnit = dr["ProUnit"].ToString();
            pro.Remark = dr["Remark"].ToString();
            pro.SubBy = Convert.ToInt32(dr["SubBy"]);
            pro.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return pro;
        }
    }
}
