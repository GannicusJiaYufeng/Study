using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class NewsBLL
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
            return dal.GetPagedNews(categoryId, startRowNum, endRowNum);
        }
        /// <summary>
        ///是否有新闻属于这个新闻类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsHaveCategoryId(long id)
        {
            return dal.IsHaveCategoryId(id) > 0;
        }
        /// <summary>
        /// 查询是不是已经有这个标题的新闻了
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsHaveThisTitle(string title)
        {
            return dal.IsHaveThisTitle(title) > 0;
        }
    }
}
