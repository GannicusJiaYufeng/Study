using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;

namespace RpCater.Bll
{
    public class RoomInfoBLL
    {




        RoomInfoDAL rDal = new RoomInfoDAL();


        /// <summary>
        /// 根据房间的id删除该房间
        /// </summary>
        /// <param name="roomId">房间的id</param>
        /// <returns>受影响的行数</returns>
        public bool SoftDeleteRoomInfoByRoomId(int roomId)
        {
            return rDal.SoftDeleteRoomInfoByRoomId(roomId) > 0;
        }

        /// <summary>
        /// 新增或者修改房间信息
        /// </summary>
        /// <param name="r">房间对象</param>
        /// <param name="temp">标识:1---新增,2----修改</param>
        /// <returns>是否成功</returns>
        public bool AddOrUpdateRoomInfo(RoomInfo r, int temp)
        {
            if (temp == 1)//新增
            {
                return rDal.AddRomInfo(r) > 0;
            }
            else if (temp == 2)//修改
            {
                return rDal.UpdateRoomInfi(r) > 0;
            }
            return false;
        }
        /// <summary>
        /// 根据删除标识查询所有的房间的信息
        /// </summary>
        /// <param name="delFlag">删除标识---0====未删除,1====已经删除</param>
        /// <returns>房间对象的集合</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            return rDal.GetAllRoomInfoByDelFlag(delFlag);
        }
    }
}
