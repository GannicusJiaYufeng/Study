using KH.Model;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.DAL
{
    public partial class LearnCardsDAL
    {
        public LearnCards GetByCardNum(string cardNum)
        {
            //在数据库中CardNum加上了唯一约束  唯一键   
            DataSet ds = DbHelperSQL.Query("select * from T_LearnCards where CardNum=@num",
                new SqlParameter("@num", cardNum));
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count <= 0)//没找到学习卡
            {
                return null;
            }
            if (dt.Rows.Count > 1)//多加几道防护，虽然麻烦，但是更安全
            {
                throw new Exception("查到多张学习卡");
            }
            DataRow row = dt.Rows[0];
            return this.DataRowToModel(row);
        }

        /// <summary>
        /// 返回值表示是否生成成功，learnCards接收生成的学习卡
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="cardNumPrefix"></param>
        /// <param name="expireDays"></param>
        /// <param name="startNo"></param>
        /// <param name="endNo"></param>
        /// <param name="learnCards"></param>
        /// <returns></returns>
        public bool GenerateCards(long courseId, string cardNumPrefix, int expireDays,
            int startNo, int endNo, List<LearnCards> learnCards)
        {
            if (endNo < startNo)
            {
                throw new Exception("结束号码不能小于起始号码");
            }
            if (string.IsNullOrEmpty(cardNumPrefix)||learnCards==null)
            {
                throw new Exception("参数不能为空");
            }
            //通过数据库事务保证卡号冲突时已经生成的卡号回滚
            //CardNum是数据库唯一约束
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    try    //一张插入失败  整个都要回滚 
                    {
                        cmd.Transaction = tx;//使用sqlserver事务的时候要注意
                        cmd.CommandText = "Insert into T_LearnCards(CouseId,CardNum,ExpireDays,Password) output inserted.Id values(@CouseId,@CardNum,@ExpireDays,@Password)";
                        Random random = new Random();
                        for (int i = startNo; i <= endNo; i++)
                        {
                            string cardNum = cardNumPrefix + i;
                            string password = generatePassword(random);//生成随机密码
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@CouseId", courseId);
                            cmd.Parameters.AddWithValue("@CardNum", cardNum);
                            cmd.Parameters.AddWithValue("@ExpireDays", expireDays);
                            cmd.Parameters.AddWithValue("@Password", password);
                            long id = (long)cmd.ExecuteScalar();//得到新增自增主键的值（上面写了  output  inserted.Id）
                            LearnCards card = new LearnCards();
                            card.Id = id;
                            card.CardNum = cardNum;
                            card.CourseId = courseId;
                            card.ExpireDays = expireDays;
                            card.Password = password;
                            learnCards.Add(card);
                        }
                        tx.Commit();//提交
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();//回滚
                        //todo:把异常信息记录到日志
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 生成一个随机密码
        /// </summary>
        /// <param name="rand">Random 是由时间为引子的，由外面传出来更好，避免重复</param>
        /// <returns></returns>
        private static string generatePassword(Random rand)
        {
            StringBuilder sb = new StringBuilder();
            //把1、o、0这些易混淆字符排除掉
            char[] chars = { '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            for (int i = 0; i < 9; i++)
            {
                int index = rand.Next(0, chars.Length);//随机取一个chars的位置
                char ch = chars[index];
                sb.Append(ch);
            }
            return sb.ToString();
            //return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
