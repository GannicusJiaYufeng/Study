using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class SegmentsBLL
    {
        /// <summary>
        /// 是否已经有这样的段落名了
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsHaveName(string name)
        {
            return dal.IsHaveName(name) > 0;
        }
        /// <summary>
        /// 是否含有这种的seqno
        /// </summary>
        /// <param name="seqno"></param>
        /// <returns></returns>
        public bool IsSeqNo(int seqno)
        {
            return dal.IsSeqNo(seqno) > 0;
        }
          /// <summary>
        /// 新增时  根据此处的sqlno相应修改其他的sqlno，或者不修改
        /// </summary>
        /// <param name="sqlno"></param>
        public void AddNewChapterSeqNo(int seqno) 
        {
            if (IsSeqNo(seqno))
            {
                dal.AddNewChapterSeqNo(seqno);
            }
        }
         /// <summary>
        /// 修改时  根据此处的sqlno相应修改其他的sqlno，或者不修改
        /// </summary>
        /// <param name="seqno"></param>
        public void EditChapterSeqNo(int seqno,int oldseqno)
        {
            if (IsSeqNo(seqno))
            {
                dal.EditChapterSeqNo(seqno, oldseqno);
            }
        }
        /// <summary>
        /// 删除时  修改其余的seqno
        /// </summary>
        /// <param name="seqno"></param>
        public void DeleteChapterSeqNo(int seqno)
        {
            dal.DeleteChapterSeqNo(seqno);
        }
        /// <summary>
        /// 看段落中是否存在这个段落的id：chapterid
        /// </summary>
        /// <param name="chapterId"></param>
        public bool IsHaveChapterId(long chapterId)
        {
            return dal.IsHaveChapterId(chapterId) > 0;
        }


        /// <summary>
        /// 从缓存中获取段落列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<KH.Model.Segments> GetModelListByCache(string where)
        {
            string cacheKey = "SegmentsBLL.GetModelListByCache." + where;//避免重复，一个标志
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
            return (List<KH.Model.Segments>)objModel;
        }
    }
}
