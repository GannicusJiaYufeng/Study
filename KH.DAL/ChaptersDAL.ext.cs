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
    public partial class ChaptersDAL
    {
        /// <summary>
        /// 是否有这种sqlno的章节
        /// </summary>
        /// <param name="sqlno"></param>
        /// <returns></returns>
        public int IsHaveSqlNo(int sqlno)
        {
            int i = (int)DbHelperSQL.GetSingle("Select count(*) from T_Chapters where seqno=@no", new SqlParameter("@no", sqlno));
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
                DbHelperSQL.ExecuteSql("update T_Chapters set seqno+=1" + "where seqno>=" + sqlno + " and seqno<" + sqlnoyuanzhi);
                return;
            }
            else if (sqlno > sqlnoyuanzhi)
            {
                DbHelperSQL.ExecuteSql("update T_Chapters set seqno+=1" + "where seqno>" + sqlnoyuanzhi + " and seqno<=" + sqlno);
                return;
            }
        }
        /// <summary>
        /// 新增时  根据此处的sqlno相应修改其他的sqlno，或者不修改
        /// </summary>
        /// <param name="sqlno"></param>
        public void AddNewChapterSeqNo(int sqlno)
        {
           DbHelperSQL.ExecuteSql("update T_Chapters set seqno+=1"+ "where seqno>="+sqlno );
        }

        /// <summary>
        /// 是不是有这个章节名了
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IsHaveName(string name)
        {
            int i = (int)SQLHelperJYF.ExecuteScalar("select count(*) from T_Chapters where name=@name", new SqlParameter("@name", name));
            return i;
        }

        /// <summary>
        /// 判断是否有属于某个课程的章节
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public int IsHaveCourseId(long courseId)
        {
            int i = (int)SQLHelperJYF.ExecuteScalar("select count(*) from T_Chapters where CourseId=@id", new SqlParameter("@id", courseId));
            return i;
        }
    }
}
