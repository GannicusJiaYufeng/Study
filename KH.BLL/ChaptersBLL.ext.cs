using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class ChaptersBLL
    {
        /// <summary>
        /// 修改时  根据此处的sqlno相应修改其他的sqlno，或者不修改
        /// </summary>
        /// <param name="sqlno"></param>
        public void EditChapterSeqNo(int sqlno,int sqlnoyuanzhi)
        {
            if (IsHaveSqlNo(sqlno))
            {
        
                dal.EditChapterSeqNo(sqlno,sqlnoyuanzhi);
            }

        }
        /// <summary>
        /// 新增时  根据此处的sqlno相应修改其他的sqlno，或者不修改
        /// </summary>
        /// <param name="sqlno"></param>
        public void AddNewChapterSeqNo(int sqlno)
        {
            if (IsHaveSqlNo(sqlno))
            {

                dal.AddNewChapterSeqNo(sqlno);
            }

        }
        /// <summary>
        /// 是否有这种sqlno的章节
        /// </summary>
        /// <param name="sqlno"></param>
        /// <returns></returns>
        public  bool IsHaveSqlNo(int sqlno)
        {
            return dal.IsHaveSqlNo(sqlno) > 0;
        }
        /// <summary>
        /// 是不是有这个章节名了
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsHaveName(string name)
        {
            return dal.IsHaveName(name) > 0;
        }
        /// <summary>
        /// 判断是否有属于某个课程的章节
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool  IsHaveCourseId(long courseId)
        {
            return dal.IsHaveCourseId(courseId) > 0;
        }
        /// <summary>
        /// 从缓存中获取章节列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<KH.Model.Chapters> GetModelListByCache(string where)
        {
            string cacheKey = "ChaptersBLL.GetModelListByCache."+where;//避免重复，一个标志
            object objModel = Maticsoft.Common.DataCache.GetCache(cacheKey);
            if (objModel == null)
            {
                 objModel = GetModelList(where);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(cacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }      
            }
            return (List<KH.Model.Chapters>)objModel;
        }
    }
}
