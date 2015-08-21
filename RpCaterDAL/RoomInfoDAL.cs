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
    public class RoomInfoDAL
    {



        /// <summary>
        /// 根据房间的id删除该房间
        /// </summary>
        /// <param name="roomId">房间的id</param>
        /// <returns>受影响的行数</returns>
        public int SoftDeleteRoomInfoByRoomId(int roomId)
        {
            string sql = "update RoomInfo set DelFlag=1 where RoomId=" + roomId;
            return SqlHelper.ExecuteNonQuery(sql);
        }



        //新增
        public int AddRomInfo(RoomInfo room)
        {
            string sql = "insert into RoomInfo( RoomName, RoomType, RoomMinMoney, RoomMaxNum, IsDefault, DelFlag, SubTime, SubBy)values( @RoomName, @RoomType, @RoomMinMoney, @RoomMaxNum, @IsDefault, @DelFlag, @SubTime, @SubBy)";
            return AddOrUpdate(room, sql, 1);//新增
        }
        //修改
        public int UpdateRoomInfi(RoomInfo room)
        {
            string sql = "update RoomInfo set RoomName=@RoomName, RoomType=@RoomType, RoomMinMoney=@RoomMinMoney, RoomMaxNum=@RoomMaxNum, IsDefault=@IsDefault where RoomId=@RoomId";
            return AddOrUpdate(room, sql, 2);//修改
        }
        //新增或者修改
        private int AddOrUpdate(RoomInfo room, string sql, int temp)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = { 
                  new SqlParameter("@RoomName",room.RoomName),
                  new SqlParameter("@RoomType",room.RoomType),
                  new SqlParameter("@RoomMinMoney",room.RoomMinMoney),
                  new SqlParameter("@RoomMaxNum",room.RoomMaxNum),
                  new SqlParameter("@IsDefault",room.IsDefault)
                               };

            list.AddRange(ps);

            if (temp == 1)//新增
            {
                list.Add(new SqlParameter("@DelFlag", room.DelFlag));
                list.Add(new SqlParameter("@SubTime", room.SubTime));
                list.Add(new SqlParameter("@SubBy", room.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("@RoomId", room.RoomId));
            }


            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }
        /// <summary>
        /// 根据删除标识查询所有的房间的信息
        /// </summary>
        /// <param name="delFlag">删除标识---0====未删除,1====已经删除</param>
        /// <returns>房间对象的集合</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            string sql = "select * from RoomInfo where DelFlag=" + delFlag;
            List<RoomInfo> list = new List<RoomInfo>();
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToRoomInfoByDataRow(dr));
                }
            }
            return list;
        }
        //查询出来是一个表的集合，把他转换到一个对象中
        private RoomInfo RowToRoomInfoByDataRow(DataRow dr)
        {
            RoomInfo r = new RoomInfo();
            r.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            r.IsDefault = dr["IsDefault"].ToString();
            r.RoomId = Convert.ToInt32(dr["RoomId"]);
            r.RoomMaxNum = Convert.ToInt32(dr["RoomMaxNum"]);
            r.RoomMinMoney = Convert.ToDouble(dr["RoomMinMoney"]);
            r.RoomName = dr["RoomName"].ToString();
            r.RoomType = Convert.ToInt32(dr["RoomType"]);
            r.SubBy = Convert.ToInt32(dr["SubBy"]);
            r.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return r;
        }
    }
}
