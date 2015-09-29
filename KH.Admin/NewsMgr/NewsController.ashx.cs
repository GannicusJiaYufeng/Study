using KH.BLL;
using KH.Model;
using KHCommons;
using KHRazor;
using RazorEngine.Text;
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
            string strParentId = context.Request["parentId"];  //可能是后台主页传来（就为空） 也可能是categorylist传来的
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
            long parentId = Convert.ToInt64(context.Request["parentId"]);
            KHHelper.OutputRazor(context, "~/NewsMgr/AddNewEditCategory.cshtml", new { id = "", name = "", parentId = parentId, action = "addnewCategorySave" });
        }
        public void addnewCategorySave(HttpContext context)
        {
            long parentId = Convert.ToInt64(context.Request["parentId"]); string name = context.Request["name"];
            if (string.IsNullOrEmpty(name) || new NewsCategoriesBLL().IsHaveName(name))
            {
                context.Response.Write("类别名字为空或者类别名已经存在"); return;
            }
            NewsCategories cate = new NewsCategories(); cate.Name = name; cate.ParentId = parentId;
            new NewsCategoriesBLL().Add(cate); context.Response.Redirect("NewsController.ashx?action=categoryList&parentId=" + parentId);
            AdminHelper.RecordOperationLog("增加了文章类别" + name);//写日志
        }
        public void editCategory(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["id"]); string name = (new NewsCategoriesBLL().GetModel(id)).Name; long parentId = Convert.ToInt64((new NewsCategoriesBLL().GetModel(id)).ParentId);
            KHHelper.OutputRazor(context, "~/NewsMgr/AddNewEditCategory.cshtml", new { id = id, name = name, parentId = parentId, action = "editCategorySave" });
        }
        public void editCategorySave(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["id"]); string oldname = (new NewsCategoriesBLL().GetModel(id)).Name;
            string name = context.Request["name"]; long parentId = Convert.ToInt64(context.Request["parentId"]);
            if ((name != oldname && new NewsCategoriesBLL().IsHaveName(name)) || string.IsNullOrEmpty(name))
            {
                context.Response.Write("类别名字为空或者类别名已经存在"); return;
            }
            NewsCategories cate = new NewsCategoriesBLL().GetModel(id); cate.Name = name;
            new NewsCategoriesBLL().Update(cate); context.Response.Redirect("NewsController.ashx?action=categoryList&parentId=" + parentId);
            AdminHelper.RecordOperationLog("修改了文章类别" + name);//写日志
        }
        public void deleteCategory(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["id"]); string name = (new NewsCategoriesBLL().GetModel(id)).Name;
            if (new NewsBLL().IsHaveCategoryId(id))
            {
                context.Response.Write("该新闻类别下面有新闻，请先删除新闻"); return;
            }
            new NewsCategoriesBLL().Delete(id); AdminHelper.RecordOperationLog("删除了文章类别" + name);//写日志
        }
        public void editNews(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["id"]); long categoryId = (new NewsBLL().GetModel(id)).CategoryId;
            string title = (new NewsBLL().GetModel(id)).Title; string body = (new NewsBLL().GetModel(id)).Body;
            RawString oldbody = KHHelper.Raw(body);//!!
            KHHelper.OutputRazor(context, "~/NewsMgr/AddNewNews.cshtml",
                new { categoryId = categoryId ,title=title,body=oldbody,action="editNewsSave",id=id});
        }
        public void editNewsSave(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["id"]); string oldtitle = (new NewsBLL().GetModel(id)).Title;
            string title = context.Request["title"]; long categoryId = Convert.ToInt64(context.Request["categoryId"]);
            string body = context.Request["body"];
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(body)||(new NewsBLL().IsHaveThisTitle(title)&&oldtitle!=title))
            {
                AjaxHelper.WriteJson(context.Response, "error", "标题和正文都不能为空并且标题不能重复"); return;
            }
            if (title.Length > 250) //title长度最长250
            {
                AjaxHelper.WriteJson(context.Response, "error", "标题太长，不能超过250");   return;
            }
            News news = new NewsBLL().GetModel(id); news.Title = title; news.Body = body;
            new NewsBLL().Update(news);
            createNewsStaticPage(id, categoryId, title, body);
            createNewsListStaticPage(categoryId); //每次修改文章都把该类别下所有的文章列表页面生成
            AjaxHelper.WriteJson(context.Response, "ok", ""); AdminHelper.RecordOperationLog("修改了新闻" + title);//写日志
        }
        public void deleteNews(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["id"]); string title = (new NewsBLL().GetModel(id)).Title; long categoryId = (new NewsBLL().GetModel(id)).CategoryId;
            new NewsBLL().Delete(id); context.Response.Redirect("NewsController.ashx?action=newsList&id=" + categoryId);
            AdminHelper.RecordOperationLog("删除了新闻" + title);//写日志
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
                new { categoryId = categoryId,body="",title="",action="addnewNewsSave",id=""});
        }
        public void addnewNewsSave(HttpContext context)
        {
            long categoryId = Convert.ToInt64(context.Request["categoryId"]);
            string title = context.Request["title"];
            string body = context.Request["body"];
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(body) || new NewsBLL().IsHaveThisTitle(title))
            {
                AjaxHelper.WriteJson(context.Response, "error", "标题和正文都不能为空并且标题不能重复"); return;
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
            AjaxHelper.WriteJson(context.Response, "ok", ""); AdminHelper.RecordOperationLog("增加了新闻" + title);//写日志
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
            int totalSize = newsbll.GetRecordCount("CategoryId=" + categoryId);//获得类别下文章的总条数
            int pageSize = 10;//每页10条
            //56/10,6
            int pageCount = (int)Math.Ceiling((totalSize * 1.0f) / (pageSize * 1.0f)); //总页数
            //逐页生成列表文件
            for (int i = 1; i <= pageCount; i++)
            {
                string newsStaticDir = ConfigurationManager.AppSettings["NewsStaticDir"];  //避免静态页面保存地址被写死
                string filename = categoryId + @"\index_" + i + ".shtml";//
                var newsItems = newsbll.GetPagedNews(categoryId, (i - 1) * 10 + 1, i * 10);//获得当前页的数据 
                //i-1当前页的前一页的，然后每一页十个数据，到本页就是*10+1，然后本页10个数据，所以到i*10
                //如 i=1,1,10   就找1和10之间数据
                //i=2,11,20  就找11-20之间数据
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
            AjaxHelper.WriteJson(context.Response, "ok", ""); AdminHelper.RecordOperationLog("一键生成了静态页");//写日志
        }
    }
}
