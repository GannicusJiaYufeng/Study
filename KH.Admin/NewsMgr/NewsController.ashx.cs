using KH.BLL;
using KH.Model;
using KHCommons;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace KH.Admin.NewsMgr
{
    /// <summary>
    /// NewsController 的摘要说明
    /// </summary>
    public class NewsController : BaseHandler
    {
        public void categoryList(HttpContext context)
        {
            string strParentId = context.Request["parentId"];
            long parentId = -1;//根类别
            if (!string.IsNullOrEmpty(strParentId))
            {
                parentId = Convert.ToInt32(strParentId);
            }
            var categories = new NewsCategoriesBLL().GetModelList("ParentId=" + parentId);
            KHHelper.OutputRazor(context, "~/NewsMgr/CategoryList.cshtml", new { categories = categories, parentId = parentId });
        }

        public void addnewCategory(HttpContext context)
        {

        }
        public void newsList(HttpContext context)
        {
            long categoryId = Convert.ToInt64(context.Request["id"]); //类别id
            var news = new NewsBLL().GetModelList("CategoryId=" + categoryId);
            KHHelper.OutputRazor(context, "~/NewsMgr/NewsList.cshtml",
                new { categoryId = categoryId, news = news });
        }
        public void addnewNews(HttpContext context)
        {
            long categoryId = Convert.ToInt64(context.Request["categoryId"]);
            KHHelper.OutputRazor(context, "~/NewsMgr/AddNewNews.cshtml",
                new { categoryId = categoryId });
        }

        public void addnewNewsSave(HttpContext context)
        {
            long categoryId = Convert.ToInt64(context.Request["categoryId"]);
            string title = context.Request["title"];
            string body = context.Request["body"];
            if (string.IsNullOrEmpty(title)||string.IsNullOrEmpty(body))
              {
                  AjaxHelper.WriteJson(context.Response, "error", "标题和正文都不能为空"); return;
              }
            //title长度最长250
            if (title.Length > 250)
            {
                AjaxHelper.WriteJson(context.Response, "error", "标题太长，不能超过250");
                return;
            }
            News news = new News();
            news.Body = body;
            news.CategoryId = categoryId;
            news.PostDateTime = DateTime.Now;
            news.Title = title;
            long newsId = new NewsBLL().Add(news);//插入，并且获得新增文章的id
            //生成静态化页面
            //页面静态化
            createNewsStaticPage(newsId, categoryId, title, body);
            createNewsListStaticPage(categoryId); //每次新增文章都把该类别下所有的文章列表页面生成
            AjaxHelper.WriteJson(context.Response, "ok", "");
        }

        /// <summary>
        /// 为categoryId类别下的文章列表生成静态页
        /// </summary>
        /// <param name="categoryId"></param>
        private static void createNewsListStaticPage(long categoryId)
        {
            NewsCategoriesBLL catBll = new NewsCategoriesBLL();
            var newsCat = catBll.GetModel(categoryId);
            string categoryName = newsCat.Name;

            NewsBLL newsbll = new NewsBLL();
            //类别下文章的总条数
            int totalSize = newsbll.GetRecordCount("CategoryId=" + categoryId);
            int pageSize = 10;//每页10条
            //56/10,6
            int pageCount = (int)Math.Ceiling((totalSize * 1.0f) / (pageSize * 1.0f));
            //逐页生成列表文件
            for (int i = 1; i <= pageCount; i++)
            {
                string newsStaticDir = ConfigurationManager.AppSettings["NewsStaticDir"];  //避免静态页面保存地址被写死
                string filename = categoryId + @"\index_" + i + ".shtml";//\ /
                //i=1,1,10
                //i=2,11,20
                //当前页的数据
                var newsItems = newsbll.GetPagedNews(categoryId, (i - 1) * 10 + 1, i * 10);
                string html = KHHelper.ParseRazor(HttpContext.Current, "~/NewsMgr/NewsListStatic.cshtml",
                    new
                    {
                        CategoryName = categoryName,
                        News = newsItems,
                        CategoryId = categoryId,
                        TotalSize = totalSize,
                        CurrentPage = i
                    });
                string htmlFullPath = Path.Combine(newsStaticDir, filename);
                string htmlDir = Path.GetDirectoryName(htmlFullPath);
                if (!Directory.Exists(htmlDir))
                {
                    Directory.CreateDirectory(htmlDir);
                }
                File.WriteAllText(htmlFullPath, html);
            }
        }
        /// <summary>
        /// 生成静态页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryId"></param>
        /// <param name="title"></param>
        /// <param name="body"></param>
        private static void createNewsStaticPage(long id, long categoryId, string title, string body)
        {
            //生成静态化页面
            string html = KHHelper.ParseRazor(HttpContext.Current, "~/NewsMgr/ViewNews.cshtml", new
            {
                Title = title,
                Body = body
            });
            //从配置文件（web.config）中读取静态页生成路径
            string newStaticDir = ConfigurationManager.AppSettings["NewsStaticDir"];
            string fullPath = newStaticDir + categoryId + @"\" + id + ".shtml";
            string htmlDir = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(htmlDir))//文件夹不存在，则创建
            {
                Directory.CreateDirectory(htmlDir);
            }
            File.WriteAllText(fullPath, html);
        }

        public void rebuildStatic(HttpContext context)  //点击一键生成静态页的时候
        {
            long categoryId = Convert.ToInt64(context.Request["categoryId"]);
            NewsBLL bll = new NewsBLL();
            var news = bll.GetModelList("CategoryId=" + categoryId);
            foreach (var item in news)
            {
                createNewsStaticPage(item.Id, item.CategoryId, item.Title, item.Body);//生成静态页
            }
            createNewsListStaticPage(categoryId);//重新生成列表页面
            AjaxHelper.WriteJson(context.Response, "ok", "");
        }
    }
}
