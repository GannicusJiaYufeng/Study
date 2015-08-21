using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using System.Data.SqlClient;
using System.Data;

namespace RpCater.DAL
{
    public class DeskInfoDAL
    {



        /// <summary>
        /// 根据餐桌的id改变餐桌的状态
        /// </summary>
        /// <param name="deskId">餐桌的id</param>
        /// <param name="state">状态：----0------空闲状态,1-----就餐状态</param>
        /// <returns></returns>
        public int UpdateDeskInfoStateByDeskId(int deskId, int state)
        {
            string sql = "update DeskInfo set DeskState=@DeskState where DelFlag=0 and DeskId=@DeskId";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@DeskId", deskId), new SqlParameter("@DeskState", state));
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
        //新增
        public int AddDeskInfo(DeskInfo dk)
        {
            string sql = "insert into DeskInfo(RoomId, DeskName, DeskRemark, DeskRegion, DeskState, DelFlag, SubTime, SubBy )values( @RoomId, @DeskName, @DeskRemark, @DeskRegion, @DeskState, @DelFlag, @SubTime, @SubBy)";
            return AddOrUpdate(dk, sql, 1);//新增
        }
        // 修改
        public int UpdateDeskInfo(DeskInfo dk)
        {
            string sql = "update DeskInfo set RoomId=@RoomId, DeskName=@DeskName, DeskRemark=@DeskRemark, DeskRegion=@DeskRegion where DeskId=@DeskId";
            return AddOrUpdate(dk, sql, 2);//修改
        }
        private int AddOrUpdate(DeskInfo dk, string sql, int temp)
        {
            SqlParameter[] ps = {
                new SqlParameter("@RoomId",dk.RoomId),
                new SqlParameter("@DeskName",dk.DeskName),
                new SqlParameter("@DeskRemark",dk.DeskRemark),
                new SqlParameter("@DeskRegion",dk.DeskRegion)
                               };
            List<SqlParameter> list = new List<SqlParameter>();
            list.AddRange(ps);
            if (temp == 1)//新增
            {
                list.Add(new SqlParameter("@DelFlag", dk.DelFlag));
                list.Add(new SqlParameter("@SubTime", dk.SubTime));
                list.Add(new SqlParameter("@SubBy", dk.SubBy));
                list.Add(new SqlParameter("@DeskState", dk.DeskState));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("@DeskId", dk.DeskId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据房间的id查找该房间下所有的餐桌
        /// </summary>
        /// <param name="roomId">房间的id</param>
        /// <returns>餐桌对象的集合</returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            string sql = "select * from DeskInfo where DelFlag=0 and RoomId=" + roomId;
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            List<DeskInfo> list = new List<DeskInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToDeskInfoByDataRow(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据房间的id查询该房间下有没有餐桌
        /// </summary>
        /// <param name="id">房间的id</param>
        /// <returns>餐桌的数量</returns>
        public object GetDeskInfoCountByRoomId(int id)
        {
            string sql = "select count(*) from deskinfo where DelFlag=0 and roomid=" + id;
            return SqlHelper.ExecuteScalar(sql);
        }

        /// <summary>
        /// 根据删除标识查询所有的餐桌信息
        /// </summary>
        /// <param name="delFlag">删除标识:0=====未删除,1----已经删除</param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeakInfoByDelFlag(int delFlag)
        {
            string sql = "select * from DeskInfo where DelFlag=" + delFlag;
            DataTable dt= SqlHelper.ExecuteQuery(sql);
            List<DeskInfo> list = new List<DeskInfo>();
            if (dt.Rows.Count > 0)   //记得判断
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToDeskInfoByDataRow(dr));
                }
            }
            return list;
        }

   
        private DeskInfo RowToDeskInfoByDataRow(DataRow dr)
        {
            DeskInfo dk = new DeskInfo();
            dk.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            dk.DeskId = Convert.ToInt32(dr["DeskId"]);
            dk.DeskName = dr["DeskName"].ToString();
            dk.DeskRegion = dr["DeskRegion"].ToString();
            dk.DeskRemark = dr["DeskRemark"].ToString();
            dk.DeskState = Convert.ToInt32(dr["DeskState"]);
            dk.RoomId = Convert.ToInt32(dr["RoomId"]);
            dk.SubBy = Convert.ToInt32(dr["SubBy"]);
            dk.SubTime = Convert.ToDateTime(dr["SubTime"]);
            dk.DeskStateString = dk.DeskState == 0 ? "空闲" : "就餐";
            return dk;
        }
    }
}
