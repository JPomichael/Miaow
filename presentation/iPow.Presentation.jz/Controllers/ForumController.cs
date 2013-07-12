using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using iPow.jz.Models;
using iPow.DataSys;

namespace iPow.jz.Controllers
{
    public class ForumController : ControllerBase
    {
        //景区分页，默认数是15条
        int pageSize = 15;

        int pageSizeForumDetail = 50;

        /// <summary>
        /// Seaches the specified f name.
        /// </summary>
        /// <param name="fName">Name of the f.</param>
        /// <returns></returns>
        public ActionResult Search(FormCollection fName)
        {
            //获得主题名称
            ViewBag.Message = FroumModels.irainbow.sns_forum_catalog.Where(o => o.fatherid == 0).SingleOrDefault().name;
            ViewBag.SiteName = "混家族";
            //版本
            ViewBag.Icp = FroumModels.irainbow.sns_option.Where(o => o.name == "icp").SingleOrDefault().value;
            string fm = fName["fName"];
            sns_forum s = FroumModels.irainbow.sns_forum.Where(o => o.name == fm).SingleOrDefault();
            //获得活动的名称
            string title = FroumModels.irainbow.sns_forum.Where(o => o.fid == s.fid).SingleOrDefault().name;
            ViewBag.Name = title;
            return PartialView("ForumListTopic", new FroumModels(s.fid, title, null, 60));
        }

        /// <summary>
        /// 添加新帖子和评论
        /// </summary>
        /// <param name="f">The fx.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddFromTopic(FormCollection f)
        {
            try
            {
                string title = f["title"];
                string content = f["content"];
                string username = f["username"];
                string fid = f["fid"];
                string tid1 = f["tid"];
                string picurl = f["picurl"];
                string anony = f["anony"];
                string uid = f["uid"];
                if (title == null)
                {
                    #region 添加评论/楼数
                    iPow.DataSys.sns_Post post = iPow.DataClass.jz.Querys.IrainDb.sns_Post.CreateObject();
                    if (anony == "" || anony == null)
                    {
                        post.author = iPow.function.StringHelper.GetRealIP();
                    }
                    else
                    {
                        post.author = anony;
                    }
                    //更新回复主表
                    post.fid = Convert.ToInt32(fid);
                    post.authorico = 0;
                    post.authorid = 0;
                    post.guestname = 0;
                    post.subject = "";
                    post.dateline = iPow.function.DateHelper.GetNowToMysqlTime();
                    post.up = 0;
                    post.wave = 0;
                    post.down = 0;
                    post.postip = iPow.function.StringHelper.GetRealIP();
                    post.tid = Convert.ToInt32(tid1);
                    post.replyfloor = (short)(iPow.DataClass.jz.Querys.GetPostMaxFloorByTid(post.tid) + 1);
                    iPow.DataClass.jz.Querys.IrainDb.sns_Post.AddObject(post);

                    //更新回复详细表
                    iPow.DataSys.sns_PostContent postContent = iPow.DataClass.jz.Querys.IrainDb.sns_PostContent.CreateObject();
                    postContent.message = content + "<br/>" + picurl;
                    postContent.picture = "";
                    postContent.tid = Convert.ToInt32(tid1);
                    iPow.DataClass.jz.Querys.IrainDb.sns_PostContent.AddObject(postContent);

                    //更新楼数 最后一个回复人id username
                    iPow.DataSys.sns_topic toppic = iPow.DataClass.jz.Querys.GetSingleTopPicByTid(post.tid);
                    toppic.replies += 1;
                    toppic.lastauthor = iPow.function.StringHelper.GetAnonyIP();
                    toppic.lastauthorid = 0;

                    int res = iPow.DataClass.jz.Querys.IrainDb.SaveChanges();

                    //更新新鲜事儿首页会显示这些信息的
                    iPow.DataSys.sns_feed_template tmeplate = iPow.DataClass.jz.Querys.GetSingleFeedTemplateByType("forum_reply");
                    iPow.DataSys.sns_feed feed = iPow.DataClass.jz.Querys.IrainDb.sns_feed.CreateObject();


                    //这个地方得改改，不过现在，还不晓得怎么改的
                    feed.appid = "0";
                    feed.feedtype = 0;
                    feed.fid = 0;
                    feed.type = "forum_reply";
                    feed.cTime = (int?)post.dateline;
                    feed.uid = 0;
                    feed.username = iPow.function.StringHelper.GetAnonyIP();
                    feed.title_data = feed.username + "回复了主题帖：<a href='/topic/" + post.tid + "/x' target='_blank'>" + toppic.subject + "</a>";

                    feed.body_data = feed.title_data;

                    Webdiyer.WebControls.Mvc.PagedList<iPow.DataClass.jz.SinglePostDetail> model = null;
                    model = iPow.DataClass.jz.Querys.GetTopPicPostDetailListById(post.tid, 1, pageSize, "last");
                    return PartialView("ListTopicPartital", model);
                    #endregion
                }
                else
                {
                    #region 添加新帖子
                    sns_topic toppic = new sns_topic();
                    sns_Post post = new sns_Post();
                    sns_PostContent postContent = new sns_PostContent();
                    postContent.isHtml = 0;
                    if (picurl == null)
                    {
                        postContent.message = content;
                    }
                    else
                    {
                        postContent.message = content + "<br/>" + picurl;
                    }
                    postContent.picture = "";
                    if (username == null)
                    {
                        post.author = iPow.function.StringHelper.GetRealIP();
                        toppic.author = iPow.function.StringHelper.GetRealIP();
                        toppic.lastauthor = iPow.function.StringHelper.GetRealIP();
                    }
                    else
                    {
                        post.author = username;
                        toppic.author = username;
                        toppic.lastauthor = username;
                    }
                    post.fid = Convert.ToInt32(fid);
                    post.authorico = 0;
                    post.authorid = 0;
                    post.subject = title;
                    post.dateline = iPow.function.DateHelper.GetNowToMysqlTime();
                    post.up = 0;
                    post.wave = 0;
                    post.postip = iPow.function.StringHelper.GetRealIP();
                    post.replyfloor = 0;
                    toppic.dateline = iPow.function.DateHelper.GetNowToMysqlTime();
                    toppic.lasttime = iPow.function.DateHelper.GetNowToMysqlTime();
                    toppic.fid = Convert.ToInt32(fid);
                    toppic.authorico = 0;
                    toppic.authorid = 0;
                    toppic.lastauthorid = 0;
                    toppic.subject = title;
                    iPow.DataClass.jz.Querys.IrainDb.sns_topic.AddObject(toppic);
                    int res =  iPow.DataClass.jz.Querys.IrainDb.SaveChanges();
                    if(res > 0 )
                    {
                        sns_topic topic = iPow.DataClass.jz.Querys.GetSingleTopPicBySubject(title);
                        int tid = topic.tid;
                        post.tid = tid;
                        postContent.tid = tid;
                        iPow.DataClass.jz.Querys.IrainDb.sns_Post.AddObject(post);
                        iPow.DataClass.jz.Querys.IrainDb.sns_PostContent.AddObject(postContent);
                        iPow.DataClass.jz.Querys.IrainDb.SaveChanges();
                    }
                    return RedirectToAction("ListTopic", "Forum", new { tid = post.tid, num = "", pageIndex = 1 });

                    ////获得活动的名称
                    //string title1 = FroumModels.irainbow.sns_forum.Where(o => o.fid == post.fid).SingleOrDefault().name;
                    //ViewBag.Name = title;
                    //return PartialView("ForumListTopicC", new FroumModels(post.fid, title1, null, 60));

                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = FroumModels.irainbow.sns_forum_catalog.Where(o => o.fatherid == 0).SingleOrDefault().name;
            ViewBag.SiteName = "混家族";
            //版本
            ViewBag.Icp = FroumModels.irainbow.sns_option.Where(o => o.name == "icp").SingleOrDefault().value;
            return View();
        }


        /// <summary>
        /// 添加家族圈
        /// </summary>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            string bar = f["bar"];
            string intro = f["intro"];
            string username = f["username"];
            if (bar != null)
            {
                sns_forum_temp snsForm = new sns_forum_temp();
                snsForm.synopsis = intro;
                snsForm.name = bar;
                snsForm.ipaddress = iPow.function.StringHelper.GetRealIP();
                snsForm.dateline = iPow.function.DateHelper.GetNowToMysqlTime();
                //   string d = new FroumModels().GetGMTDateTime(snsForm.dateline).ToString();
                if (username == null)
                {
                    snsForm.founder = iPow.function.StringHelper.GetRealIP();
                }
                else
                {
                    snsForm.founder = username;
                }
                FroumModels.irainbow.sns_forum_temp.AddObject(snsForm);
                FroumModels.irainbow.SaveChanges();
            }
            return PartialView(new FroumModels());
        }

        /// <summary>
        /// Categories the list.
        /// xxxx家族圈帖子列表 、
        /// xxxx分类家族圈列表
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="t">The t.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns></returns>
        public ActionResult CategoryList(int? cid, int t, int? pageIndex)
        {
            //如果等于1,代表是根据分类查询家族信息,否则是根据景区id查询景区帖子
            if (t == 1)
            {
                iPow.DataClass.jz.ForumCatalogList model = new DataClass.jz.ForumCatalogList();
                model.CurrentCatalog = iPow.DataClass.jz.Querys.GetForumSingleCatalogById((int)cid);
                //一个分类的分页
                if (pageIndex != null)
                {
                    var data = iPow.DataClass.jz.Querys.GetForumFamilyListByCatalogId((int)cid, (int)pageIndex, pageSize);
                    ViewBag.cid = cid;
                    return PartialView("CategoryListPartial", data);
                }
                //第一次访问
                return View(model);
            }
            else
            {
                int fid = Convert.ToInt32(cid);
                iPow.DataClass.jz.ForumDetail model = new DataClass.jz.ForumDetail();
                //当前这个家庭圈基本信息
                model.CurrentForum = iPow.DataClass.jz.Querys.GetForumBaseInfoById(fid);
                //有翻页
                if (pageIndex != null)
                {
                    var data = iPow.DataClass.jz.Querys.GetForumTopicListById(model.CurrentForum.fid, (int)pageIndex, pageSizeForumDetail);
                    ViewBag.fid = fid;
                    return PartialView("ForumListTopicPartial", data);
                }
                //第一，没有翻页
                if (model != null)
                {
                    model.CurrentCatalog = iPow.DataClass.jz.Querys.GetForumSingleCatalogById(model.CurrentForum.cid);
                }
                return PartialView("ForumListTopic", model);
            }
        }

        /// <summary>
        /// Lists the topic.
        /// 一个详细帖子列表和分页
        /// </summary>
        /// <param name="tid">The tid.</param>
        /// <param name="num">The num.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns></returns>
        public ActionResult ListTopic(int? tid, string num, int? pageIndex)
        {
            if (pageIndex != null)
            {
                Webdiyer.WebControls.Mvc.PagedList<iPow.DataClass.jz.SinglePostDetail> model = null;
                model = iPow.DataClass.jz.Querys.GetTopPicPostDetailListById((int)tid, (int)pageIndex, pageSize);
                return PartialView("ListTopicPartital", model);
            }
            else
            {
                iPow.DataClass.jz.TopPicDetail model = new DataClass.jz.TopPicDetail();
                int currentForumId = iPow.DataClass.jz.Querys.GetPostFidByTid((int)tid);
                model.CurrentForum = iPow.DataClass.jz.Querys.GetForumBaseInfoById(currentForumId);
                if (model.CurrentForum != null)
                {
                    model.CurrentCatalog = iPow.DataClass.jz.Querys.GetForumSingleCatalogById(model.CurrentForum.cid);
                }

                var toppic = iPow.DataClass.jz.Querys.GetSingleTopPicByTid((int)tid);
                toppic.views += 1;
                model.TopPic = toppic;
                iPow.DataClass.jz.Querys.IrainDb.sns_topic.Context.SaveChanges();

                return PartialView(model);
            }
        }

        /// <summary>
        /// 顶、砸、飘过
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [NoCache]
        public JsonResult DeUp(int? pid, string type)
        {
            bool tar = true;
            sns_Post post = iPow.DataClass.jz.Querys.GetSinglePostByPid((int)pid);
            int count = 0;
            if (post != null)
            {
                try
                {
                    //飘过
                    if (type == "wave")
                    {
                        post.wave = post.wave + 1;
                        count = post.wave;
                    }
                    //顶
                    else if (type == "up")
                    {
                        post.up = post.up + 1;
                        count = post.up;
                    }
                    //砸
                    else if (type == "down")
                    {
                        post.down = post.down + 1;
                        count = post.down;
                    }
                    iPow.DataClass.jz.Querys.IrainDb.SaveChanges();
                }
                catch (Exception)
                {
                    tar = false;
                    count = 0;
                }
            }
            else
            {
                tar = false;
            }
            return this.Json(new { success = tar.ToString(), count = count }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据作者与标题查询,家族圈
        /// </summary>
        /// <param name="seachName">Name of the seach.</param>
        /// <param name="type">The type.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns></returns>
        public ActionResult SeachFroum(string seachName, string type, int? pageIndex)
        {
            seachName = seachName.Trim();
            //版本
            ViewBag.Icp = FroumModels.irainbow.sns_option.Where(o => o.name == "icp").SingleOrDefault().value;
            //获得主题名称
            ViewBag.Message = FroumModels.irainbow.sns_forum_catalog.Where(o => o.fatherid == 0).SingleOrDefault().name;
            ViewBag.SiteName = "混家族";
            //家族圈查询
            if (type == "2" || type == "images")
            {
                sns_forum s = FroumModels.irainbow.sns_forum.Where(o => o.name == seachName).SingleOrDefault();
                if (s == null)
                {
                    ViewBag.SearchName = seachName;//查询标题
                    return PartialView("Create", new FroumModels());
                }
                else
                {
                    if (pageIndex != null)
                    {
                        return PartialView("ForumListTopicC", new FroumModels(s.fid, type, pageIndex, 60));
                    }
                    return PartialView("ForumListTopic", new FroumModels(s.fid, type, pageIndex, 60));
                }
            }
            //根据作者与标题查询
            if (pageIndex != null)
            {
                return PartialView("SeachFroumC", new FroumModels(seachName, type, pageIndex, 60));
            }
            return PartialView("SeachFroum", new FroumModels(seachName, type, pageIndex, 60));
        }

        /// <summary>
        /// Searches the topic.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public ActionResult SearchTopic(string n)
        {
            List<string> list = new List<string>();
            if (Request.IsAjaxRequest())
            {
                string sear = string.Empty;
                if (Request["term"] != null)
                {
                    sear = Request["term"].ToString();
                    sear = sear.Trim();
                }
                if (n == "1")
                {
                    var subject = FroumModels.irainbow.sns_topic.Where(o => o.subject.Contains(sear)).Distinct().Select(d => d.subject).Take(10).ToList();
                    list.AddRange(subject);
                }
                else if (n == "2")
                {
                    var synopsis = FroumModels.irainbow.sns_forum.Where(o => o.synopsis.Contains(sear)).Distinct().Select(d => d.synopsis).Take(10).ToList();
                    list.AddRange(synopsis);
                }
                else if (n == "3")
                {
                    var name = FroumModels.irainbow.sns_topic.Where(o => o.author.Contains(sear)).Distinct().Select(d => d.author).Take(0).ToList();
                    list.AddRange(name);
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
    }
}
