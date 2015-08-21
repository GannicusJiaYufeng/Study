using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpCater.DAL;
using RpCater.Model;
namespace RpCater.Bll
{
    public class DeskInfoBLL
    {
        DeskInfoDAL dkDal = new DeskInfoDAL();
        /// <summary>
        /// 根据餐桌的id改变餐桌的状态
        /// </summary>
        /// <param name="deskId">餐桌的id</param>
        /// <param name="state">状态：----0------空闲状态,1-----就餐状态</param>
        /// <returns></returns>
        public bool UpdateDeskInfoStateByDeskId(int deskId, int state)
        {
            return dkDal.UpdateDeskInfoStateByDeskId(deskId, state) > 0;
        }



        public bool AddOrUpdateDeskInfo(DeskInfo dk,int temp)
        {

            if (temp == 1)
            {
                return dkDal.AddDeskInfo(dk) > 0;
            }
            else if (temp == 2)
            {
                return dkDal.UpdateDeskInfo(dk) > 0;
            }
            return false;
        }


        /// <summary>
        /// 根据房间的id查找该房间下所有的餐桌
        /// </summary>
        /// <param name="roomId">房间的id</param>
        /// <returns>餐桌对象的集合</returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            return dkDal.GetAllDeskInfoByRoomId(roomId);
        }

        /// <summary>
        /// 根据餐桌的id删除该餐桌
        /// </summary>
        /// <param name="id">餐桌的id</param>
        /// <returns>受影响的行数</returns>
        public bool SoftDeleteDeskByDeskId(int id)
        {
            return dkDal.SoftDeleteDeskByDeskId(id) > 0;
        }
        /// <summary>
        /// 根据房间的id查询该房间下有没有餐桌
        /// </summary>
        /// <param name="id">房间的id</param>
        /// <returns>餐桌的数量</returns>
        public int GetDeskInfoCountByRoomId(int id)
        {
            return Convert.ToInt32(dkDal.GetDeskInfoCountByRoomId(id));
        }

        /// <summary>
        /// 根据删除标识查询所有的餐桌信息
        /// </summary>
        /// <param name="delFlag">删除标识:0=====未删除,1----已经删除</param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            return dkDal.GetAllDeakInfoByDelFlag(delFlag);
        }
    }
}
