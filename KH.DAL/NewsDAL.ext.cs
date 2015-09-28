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
    public partial class NewsDAL
    {
        /// <summary>
        /// 获取categoryId=categoryId的数据，根据id排序，
        /// rownum>=startRowNum&&rownum<=endRowNum
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="startRowNum"></param>
        /// <param name="endRowNum"></param>
        /// <returns></returns>
        public List<News> GetPagedNews(long categoryId, long startRowNum, long endRowNum)
        {
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.AppendLine("select * from(");
            sbSQL.AppendLine("select ROW_NUMBER() over(order by Id) rownum,*");
            sbSQL.AppendLine("from T_News) t");
            sbSQL.AppendLine("where  t.rownum>=@startRowNum and t.rownum<=@endRowNum");
            DataSet ds = DbHelperSQL.Query(sbSQL.ToString(), new SqlParameter("@startRowNum", startRowNum)
                , new SqlParameter("@endRowNum", endRowNum));

            List<News> list = new List<News>();
            foreach (DataRow datarow in ds.Tables[0].Rows)
            {
                list.Add(this.DataRowToModel(datarow));
            }
            return list;
        }
    }
}
