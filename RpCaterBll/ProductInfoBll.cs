using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;

namespace RpCater.Bll
{
    public class ProductInfoBll
    {
        ProductInfoDal proDal=new ProductInfoDal();
        

         /// <summary>
       /// 根据拼音或者编号搜索---模糊查询
       /// </summary>
       /// <param name="temp">标识：1---拼音搜索,----2-----编号搜索</param>
       /// <param name="name">拼音或者编号</param>
       /// <returns>产品对象的集合</returns>
        public List<ProductInfo> GetProductByProSpellOrProNum(int temp, string name)
        {

            return proDal.GetProductByProSpellOrProNum(temp, name);
        }
        /// <summary>
        /// 根据商品的类别的id查询该类别下的所有的没删除的产品
        /// </summary>
        /// <param name="cId">商品类别的id</param>
        /// <returns>产品对象的集合</returns>
        public List<ProductInfo> GetProductInfoByCId(int cId)
        {

            return proDal.GetProductInfoByCId(cId);
        }
         /// <summary>
        /// 根据商品类别的id查询产品表中是否有该类别的产品
        /// </summary>
        /// <param name="cId">商品类别的id</param>
        /// <returns>产品的个数</returns>
        public int GetProductInfoCountByCId(int cId)
        {
            return Convert.ToInt32(proDal.GetProductInfoCountByCId(cId));  
        }


        /// <summary>
        /// 删除产品信息
        /// </summary>
        /// <param name="proId">产品的id</param>
        /// <returns>受影响的行数</returns>
        public bool SoftDeleteByProId(int proId) 
        {
            return proDal.SoftDeleteByProId(proId) > 0;
        
        }
        /// <summary>
        /// 新增或者修改产品信息
        /// </summary>
        /// <param name="pro">产品信息对象</param>
        /// <param name="temp">标识：1----新增,2----修改</param>
        /// <returns>是否成功</returns>
        public bool AddOrUpdateProductInfo(ProductInfo pro, int temp)
        {

            if (temp == 1)//新增
            {

                return proDal.AddProductInfo(pro) > 0;
            }
            else if (temp == 2)//修改
            {
                return proDal.UpdateProductInfo(pro) > 0;
            }
            return false;
        }

        /// <summary>
        /// 根据删除标识查询所有的产品信息
        /// </summary>
        /// <param name="delFlag">删除标识,0---未删除,1---已经删除了</param>
        /// <returns>产品对象集合</returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            return proDal.GetAllProductInfoByDelFlag(delFlag);
        }
    }
}
