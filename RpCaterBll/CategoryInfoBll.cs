using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;

namespace RpCater.Bll
{
    public class CategoryInfoBll
    {
        CategoryInfoDAL cDal = new CategoryInfoDAL();



        // <summary>
        /// 根据商品类别的id删除该类别
        /// </summary>
        /// <param name="cId">类别的id</param>
        /// <returns>受影响的行数</returns>
        public bool SoftDeleteCategoryByCId(int cId)
        {

            return cDal.SoftDeleteCategoryByCId(cId) > 0;
        }



        /// <summary>
        /// 新增或者是修改商品类别信息
        /// </summary>
        /// <param name="c">商品类别对象</param>
        /// <param name="temp">标识:1----新增,2----修改</param>
        /// <returns>是否成功</returns>
        public bool AddOrUpdateCategoryInfo(CategoryInfo c, int temp)
        {
            if (temp == 1)//新增
            {
                return cDal.AddCategoryInfo(c) > 0;
            }
            else if (temp == 2)//修改
            {
                return cDal.UpdateCategoryInfo(c) > 0;
            }
            return false;
        }




         /// <summary>
        /// 根据删除标识查询所有的商品类别信息
        /// </summary>
        /// <param name="delFlag">删除标识:---0----未删除,1----已经删除</param>
        /// <returns>商品类别对象的集合</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
           return  cDal.GetAllCategoryInfoByDelFlag(delFlag);
         
        }
    }
}
