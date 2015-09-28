using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;

namespace KH.DAL
{
    public partial class SegmentsDAL
    {
        /// <summary>
        /// 是否已经有这样的段落名了
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IsHaveName(string name)
        {
            int i = (int)SQLHelperJYF.ExecuteScalar("select count(*)from T_Segments where Name=@name", new SqlParameter("@name", name));
            return i;
        }
        /// <summary>
        /// 是否含有这种的seqno
        /// </summary>
        /// <param name="seqno"></param>
        /// <returns></returns>
        public int IsSeqNo(int seqno)
        {
            int i = (int)SQLHelperJYF.ExecuteScalar("select count(*)from T_Segments where SeqNo=@no", new SqlParameter("@no", seqno));
            return i;
        }

        /// <summary>
        /// 修改时  根据此处的sqlno相应修改其他的sqlno，或者不修改
        /// </summary>
        /// <param name="sqlno"></param>
        public void EditChapterSeqNo(int sqlno, int sqlnoyuanzhi)
        {
                if (sqlno < sqlnoyuanzhi)
                {
                    DbHelperSQL.ExecuteSql("update T_Segments set seqno+=1"  + "where seqno>=" + sqlno + " and seqno<" + sqlnoyuanzhi);
                    return;
                }
                else if (sqlno > sqlnoyuanzhi)
                {
                    DbHelperSQL.ExecuteSql("update T_Segments set seqno+=1" + "where seqno>" + sqlnoyuanzhi + " and seqno<=" + sqlno);
                    return;
                }
        }
        /// <summary>
        /// 新增时  根据此处的sqlno相应修改其他的sqlno，或者不修改
        /// </summary>
        /// <param name="sqlno"></param>
        public void AddNewChapterSeqNo(int sqlno)
        {
            DbHelperSQL.ExecuteSql("update T_Segments set seqno+=1" + "where seqno>=" + sqlno);
        }
        /// <summary>
        /// 看段落中是否存在这个段落的id：chapterid
        /// </summary>
        /// <param name="chapterId"></param>
        public int IsHaveChapterId(long chapterId)
        {
            int i = (int)SQLHelperJYF.ExecuteScalar("select count(*)from T_Segments where ChapterId=@id", new SqlParameter("@id", chapterId));
            return i;
        }
    }
}
