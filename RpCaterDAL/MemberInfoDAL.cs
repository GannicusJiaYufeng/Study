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

    public class MemberInfoDAL
    {



        public void AddMemberInfo(List<MemberInfo> list)
        {

            //创建连接对象
            using (SqlConnection con = new SqlConnection(SqlHelper.str))
            {
                con.Open();
                SqlTransaction sqlTran = con.BeginTransaction();//开启
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        MemberInfo member = list[i];
                        string sql = "insert into MemberInfo( MemName, MemMobilePhone, DelFlag)values( @MemName, @MemMobilePhone, @DelFlag)";
                        SqlParameter[] ps = {
                                    new SqlParameter("@MemName",member.MemName),   
                                    new SqlParameter("@MemMobilePhone",member.MemMobilePhone),   
                                    new SqlParameter("@DelFlag",member.DelFlag)
                                        };
                        SqlHelper.ExecuteNonQuery(con, sqlTran, sql, ps);
                    }
                    sqlTran.Commit();//提交
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();//回滚
                    throw;
                }
            }
        }







        /// <summary>
        /// 根据会员的id更新会员的金额
        /// </summary>
        /// <param name="memId">会员的id</param>
        /// <param name="money">会员的金额</param>
        /// <returns></returns>
        public int UpdateMemberMoneyById(int memId, double money)
        {
            string sql = "update MemberInfo set MemMoney=@MemMoney where MemberId=@MemberId";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@MemMoney", money), new SqlParameter("@MemberId", memId));
        }
        //新增
        public int AddMemberInfo(MemberInfo member)
        {
            string sql = "insert into MemberInfo( MemName, MemMobilePhone, MemAddress, MemType, MemNum, MemGender, MemDiscount, MemMoney, DelFlag, SubTime, MemIntegral, MemEndTime, MemBirthday)values( @MemName, @MemMobilePhone, @MemAddress, @MemType, @MemNum, @MemGender, @MemDiscount, @MemMoney, @DelFlag, @SubTime, @MemIntegral, @MemEndTime, @MemBirthday)";
            return AddOrUpdateMemberInfo(member, sql, 1);
        }
        //修改
        public int UpdateMemberInfo(MemberInfo member)
        {
            string sql = "update MemberInfo set MemName=@MemName, MemMobilePhone=@MemMobilePhone, MemAddress=@MemAddress, MemType=@MemType, MemNum=@MemNum, MemGender=@MemGender, MemDiscount=@MemDiscount, MemMoney=@MemMoney, MemIntegral=@MemIntegral, MemEndTime=@MemEndTime, MemBirthday=@MemBirthday where MemberId=@MemberId";
            return AddOrUpdateMemberInfo(member, sql, 2);
        }
        //新增和修改公用的一个方法
        private int AddOrUpdateMemberInfo(MemberInfo member, string sql, int temp)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter[] ps ={
                new SqlParameter("@MemName",member.MemName),   
                  new SqlParameter("@MemMobilePhone",member.MemMobilePhone),  
                  new SqlParameter("@MemAddress",member.MemAddress),  
                  new SqlParameter("@MemType",member.MemType),  
                  new SqlParameter("@MemNum",member.MemNum),  
                  new SqlParameter("@MemGender",member.MemGender),  
                  new SqlParameter("@MemDiscount",member.MemDiscount),  
                  new SqlParameter("@MemMoney",member.MemMoney),  
                  new SqlParameter("@MemIntegral",member.MemIntegral),  
                  new SqlParameter("@MemEndTime",member.MemEndTime),  
                  new SqlParameter("@MemBirthday",member.MemBirthday),                      
                             };
            list.AddRange(ps);
            if (temp == 1)
            {
                //新增
                list.Add(new SqlParameter("@DelFlag", member.DelFlag));
                list.Add(new SqlParameter("@SubTime", member.SubTime));

            }
            else if (temp == 2)
            {
                //修改
                list.Add(new SqlParameter("@MemberId", member.MemberId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }
        /// <summary>
        /// 根据ID改变会员删除标识
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="delFlag">删除标识：0---未删除，1---删除，2---回收站中删除</param>
        /// <returns>受影响行数</returns>

        public int SoftDeleteMemberByMemberId(int memberId, int delFlag)
        {
            string sql = "update MemberInfo set DelFlag=@DelFlag where MemberId=" + memberId;
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@DelFlag", delFlag));


        }


        /// <summary>
        /// 根据会员名字做模糊查询
        /// </summary>
        /// <param name="name">名字</param>
        /// <returns>会员信息集合</returns>
        public List<MemberInfo> GetMenmberInfoByLikeMemName(string name)
        {
            string sql = "select *from MemberInfo where DelFlag=0 and MemName Like @MemName";
            DataTable dt = SqlHelper.ExecuteQuery(sql, new SqlParameter("@MemName", "%" + name + "%"));
            List<MemberInfo> list = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberInfoByDatarow(dr));
                }
            }
            return list;

        }






        /// <summary>
        /// 根据删除标志查询所有会员信息
        /// </summary>
        /// <param name="delFlag">1：已删除  0：没删除</param>
        /// <returns>会员对象信息集合</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            string sql = "select *from MemberInfo where DelFlag=" + delFlag;
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            List<MemberInfo> listMember = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listMember.Add(RowToMemberInfoByDatarow(dr));
                }

            }
            return listMember;
        }

        //关系转对象
        private MemberInfo RowToMemberInfoByDatarow(DataRow dr)
        {
            MemberInfo mem = new MemberInfo();
            mem.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            mem.MemAddress = dr["MemAddress"].ToString();
            mem.MemberId = Convert.ToInt32(dr["MemberId"]);
            mem.MemBirthday = Convert.ToDateTime(dr["MemBirthday"]);
            mem.MemDiscount = Convert.ToDouble(dr["MemDiscount"]);
            mem.MemEndTime = Convert.ToDateTime(dr["MemEndTime"]);
            mem.MemGender = dr["MemGender"].ToString();
            mem.MemIntegral = Convert.ToInt32(dr["MemIntegral"]);
            mem.MemMobilePhone = dr["MemMobilePhone"].ToString();
            mem.MemMoney = Convert.ToDouble(dr["MemMoney"]);
            mem.MemName = dr["MemName"].ToString();
            mem.MemNum = dr["MemNum"].ToString();
            mem.MemType = Convert.ToInt32(dr["MemType"]);
            mem.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return mem;
        }
    }
}
