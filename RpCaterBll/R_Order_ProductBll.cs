using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.DAL;
using RpCater.Model;

namespace RpCater.Bll
{
    public class R_Order_ProductBll
    {
        R_Order_ProductDAL ropDal = new R_Order_ProductDAL();
        /// <summary>
        /// 根据订单的id更新该订单中所有的菜删除
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool UpdateR_Order_ProductDelFlagByOrderId(int orderId)
        {
            return ropDal.UpdateR_Order_ProductDelFlagByOrderId(orderId) > 0;
        }
        
        /// <summary>
        /// 根据中间表的主键id删除选中的菜
        /// </summary>
        /// <param name="rOrderProId">中间表的主键的id</param>
        /// <returns>是否成功</returns>
        public bool SoftDeleteR_Order_ProductByROrderProId(int rOrderProId)
        {
            return ropDal.SoftDeleteR_Order_ProductByROrderProId(rOrderProId) > 0;
        }

        /// <summary>
        /// 根据订单的id查询该餐桌点了多少个菜,总金额
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <returns>中间表的对象---数量和总金额</returns>
        public R_Order_Product GetCountAndSumMoney(int orderId)
        {
            return ropDal.GetCountAndSumMoney(orderId);
        }
        /// <summary>
        /// 根据订单的id查询该订单点的菜
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <returns>点的菜的对象的集合</returns>
        public List<R_Order_Product> GetR_Order_ProductByOrderId(int orderId)
        {
            return ropDal.GetR_Order_ProductByOrderId(orderId);
        }
        /// <summary>
        /// 添加一个菜--中间的对象
        /// </summary>
        /// <param name="rop">中间表的对象---订单和菜</param>
        /// <returns>添加成功还是失败</returns>
        public bool AddR_Order_Product(R_Order_Product rop)
        {
            return ropDal.AddR_Order_Product(rop) > 0;
        }
    }
}
