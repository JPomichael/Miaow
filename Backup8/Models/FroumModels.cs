using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iPow.DataSys;
using Webdiyer.WebControls.Mvc;
using System.Collections;

namespace iPow.jz.Models
{
    public class FroumModels
    {

        /// <summary>
        /// 
        /// </summary>
        public static string conn = System.Configuration.ConfigurationManager.ConnectionStrings["irainbowEntities"].ConnectionString;

        /// <summary>
        /// 
        /// </summary>
        public static irainbowEntities irainbow = new DataSys.irainbowEntities(conn);

        /// <summary>
        /// 
        /// </summary>
        public irainbowEntities irainbow1 = new DataSys.irainbowEntities(conn);


        /// <summary>
        /// Gets or sets the sns_forum_catalog.
        /// </summary>
        /// <value>The sns_forum_catalog.</value>
        public sns_forum_catalog CurrenCatalog { get; set; }

        /// <summary>
        /// 分类集合
        /// </summary>
        public List<sns_forum_catalog> catalogList { get; set; }

        //景区分页
        public PagedList<sns_forum> catalogListPage { get; set; }

        /// <summary>
        /// 根据类型查询帖子数
        /// </summary>
        public PagedList<sns_topic> forumTopicList { get; set; }

        /// <summary>
        /// 根据类型查询帖子数
        /// </summary>
        public PagedList<sns_Post> forumPostList { get; set; }
        /// <summary>
        /// 随机产生同一个用户发的其他帖子
        /// </summary>
        public List<sns_topic> forumSuiTopicList { get; set; }

        /// <summary>
        /// Gets or sets the post list.
        /// </summary>
        /// <value>The post list.</value>
        public sns_Post postList { get; set; }

        /// <summary>
        /// 景区详情,返回一个实体类
        /// </summary>
        public sns_forum sns_forum { get; set; }

        /// <summary>
        /// 帖子详情
        /// </summary>
        public PagedList<sns_PostContent> PostContentList { get; set; }

        /// <summary>
        /// 获得家族圈信息集合
        /// </summary>
        public List<sns_forum> forumList { get; set; }

        /// <summary>
        /// 帖子数
        /// </summary>
        public int topicNum = 0;

        /// <summary>
        /// 回复数
        /// </summary>
        public int replayNum = 0;

        /// <summary>
        /// 发帖详情
        /// </summary>
        public sns_topic sns_topic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<snsFeed> FeedListTop { get; set; }

        /// <summary>
        /// 用户登陆信息
        /// </summary>
        public Dictionary<string, string> LoginArr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> GroupArr = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// Gropus the dic.
        /// </summary>
        public void GropuDic()
        {
            Dictionary<string, string> str = new Dictionary<string, string>();
            str.Add("name", "游客");
            str.Add("topic", "1");
            str.Add("reply", "1");
            str.Add("verify", "1");

            Dictionary<string, string> str1 = new Dictionary<string, string>();
            str1.Add("name", "普通会员");
            str1.Add("topic", "1");
            str1.Add("reply", "1");
            str1.Add("verify", "1");

            Dictionary<string, string> str2 = new Dictionary<string, string>();
            str2.Add("name", "忠实会员");
            str2.Add("topic", "1");
            str2.Add("reply", "1");
            str2.Add("verify", "1");

            Dictionary<string, string> str3 = new Dictionary<string, string>();
            str3.Add("name", "VIP会员");
            str3.Add("topic", "1");
            str3.Add("reply", "1");
            str3.Add("verify", "1");

            Dictionary<string, string> str4 = new Dictionary<string, string>();
            str4.Add("name", "族长");
            str4.Add("topic", "1");
            str4.Add("reply", "1");
            str4.Add("verify", "1");

            Dictionary<string, string> str5 = new Dictionary<string, string>();
            str5.Add("name", "普通管理员");
            str5.Add("topic", "1");
            str5.Add("reply", "1");
            str5.Add("verify", "0");

            Dictionary<string, string> str6 = new Dictionary<string, string>();
            str6.Add("name", "高级管理员");
            str6.Add("topic", "1");
            str6.Add("reply", "1");
            str6.Add("verify", "0");

            GroupArr.Add("0", str);
            GroupArr.Add("1", str1);
            GroupArr.Add("2", str2);
            GroupArr.Add("3", str3);
            GroupArr.Add("4", str4);
            GroupArr.Add("5", str5);
            GroupArr.Add("6", str6);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FroumModels"/> class.
        /// </summary>
        public FroumModels()
        {
            this.CurrenCatalog = new sns_forum_catalog();
            CurrenCatalog.name = "创建家族圈";
        }

        /// <summary>
        /// 根据类型分页
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pagesize">The pagesize.</param>
        public FroumModels(int? cid, int? pageIndex, int? pagesize)
        {
            InitCatalog();
            GropuDic();
            InitCatalogPerent(cid);
            InitForumAllPageSize(cid, pageIndex, pagesize);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FroumModels"/> class.
        /// </summary>
        /// <param name="tid">The tid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        public FroumModels(int? tid, int? pageIndex)
        {
            InitForumTopic(tid, pageIndex, 50);
        }

        /// <summary>
        /// 帖子分页
        /// </summary>
        /// <param name="fid">The fid.</param>
        /// <param name="title">The title.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pagesize">The pagesize.</param>
        public FroumModels(int fid, string title, int? pageIndex, int? pagesize)
        {

            GropuDic();
            //获得景区类型名称
            var forum = irainbow.sns_forum.Where(o => o.fid == fid).SingleOrDefault();
            if (fid == 0)
            {
                InitCatalogPerent(18);
            }
            else
            {
                InitCatalogPerent(forum.cid);
            }

            InitForumAllTopPageSize(fid, title, pageIndex, pagesize);
        }

        /// <summary>
        /// 帖子查询
        /// </summary>
        /// <param name="seachName">Name of the seach.</param>
        /// <param name="type">The type.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pagesize">The pagesize.</param>
        public FroumModels(string seachName, string type, int? pageIndex, int? pagesize)
        {
            GropuDic();
            InitCatalog();
            SeachTopic(seachName, type, pageIndex, pagesize);
        }


        /// <summary>
        /// Seaches the topic.
        /// </summary>
        /// <param name="seachName">Name of the seach.</param>
        /// <param name="type">The type.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pagesize">The pagesize.</param>
        public void SeachTopic(string seachName, string type, int? pageIndex, int? pagesize)
        {
            this.CurrenCatalog = new sns_forum_catalog();
            CurrenCatalog.name = "搜索";

            if (type == "3")
            {
                forumTopicList = irainbow.sns_topic.Where(o => o.author.Contains(seachName)).OrderByDescending(o => o.lasttime).ToPagedList(pageIndex ?? 1, pagesize ?? 30);
                topicNum = irainbow.sns_topic.Where(o => o.author.Contains(seachName)).Count();
            }
            else if (type == "1")
            {
                forumTopicList = irainbow.sns_topic.Where(o => o.subject.Contains(seachName)).OrderByDescending(o => o.lasttime).ToPagedList(pageIndex ?? 1, pagesize ?? 30);
                topicNum = irainbow.sns_topic.Where(o => o.subject.Contains(seachName)).Count();
            }
        }

        /// <summary>
        /// 获得景区类型
        /// </summary>
        public void InitCatalog()
        {
            if (catalogList == null)
            {
                this.catalogList = irainbow.sns_forum_catalog.Where(o => o.fatherid != 0).OrderBy(o => o.cid).ToList();
            }
        }

        /// <summary>
        /// 获得父级景区类型
        /// </summary>
        /// <param name="cid">The cid.</param>
        public void InitCatalogPerent(int? cid)
        {
            this.CurrenCatalog = irainbow.sns_forum_catalog.Where(o => o.cid == cid).SingleOrDefault();
        }

        /// <summary>
        /// 根据类型id获得家族信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        //public void GetCatalogById(int? cid)
        //{
        //    this.forumList = irainbow.sns_forum.Where(o => o.cid == cid).OrderByDescending(o => o.dateline).ToList();
        //}

        /// <summary>
        /// 根据景区类型和id进行 分页
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public void InitForumAllPageSize(int? cid, int? pageIndex, int? pageSize)
        {
            IsLogin();
            if (cid == 18)
            {
                this.catalogListPage = irainbow.sns_forum.OrderBy(o => o.fid).ToPagedList(pageIndex ?? 1, pageSize ?? 15);
                this.forumList = irainbow.sns_forum.OrderByDescending(o => o.dateline).ToList();
            }
            else
            {
                this.catalogListPage = irainbow.sns_forum.Where(o => o.cid == cid).OrderBy(o => o.fid).ToPagedList(pageIndex ?? 1, pageSize ?? 15);
                this.forumList = irainbow.sns_forum.Where(o => o.cid == cid).OrderByDescending(o => o.dateline).ToList();
            }
        }

        /// <summary>
        /// 判断用户是否一登陆
        /// </summary>
        public void IsLogin()
        {
            sns_user suer = HttpContext.Current.Session["User"] as sns_user;
            //判断用户是否一登陆
            if (LoginModel.isLogin(HttpContext.Current.Response.Cookies["email"].Value, HttpContext.Current.Response.Cookies["password"].Value))
            {
                LoginArr = new Dictionary<string, string>();
                LoginArr.Add("state", "1");
                LoginArr.Add("uid", suer.id.ToString());
                LoginArr.Add("name", suer.name);
                LoginArr.Add("group", "1");
            }
            else
            {
                LoginArr = new Dictionary<string, string>();
                LoginArr.Add("state", "0");
                LoginArr.Add("uid", "0");
                LoginArr.Add("name", "0");
                LoginArr.Add("group", "0");
            }
        }

        /// <summary>
        /// 根据景区id和主题模糊查询
        /// </summary>
        /// <param name="fid">The fid.</param>
        /// <param name="title">The title.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public void InitForumAllTopPageSize(int fid, string title, int? pageIndex, int? pageSize)
        {
            IsLogin();
            this.forumTopicList = irainbow.sns_topic.Where(o => o.fid == fid || o.subject.Contains(title)).OrderByDescending(o => o.lasttime).ToPagedList(pageIndex ?? 1, pageSize ?? 60);
            //获得景区详情
            this.sns_forum = irainbow.sns_forum.Where(o => o.fid == fid).SingleOrDefault();
            topicNum = irainbow.sns_topic.Where(o => o.fid == fid).Count();
            replayNum = irainbow.sns_topic.Where(o => o.fid == fid).Sum(o => o.replies);
        }

        /// <summary>
        /// 获得帖子详情
        /// </summary>
        /// <param name="tid">The tid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public void InitForumTopic(int? tid, int? pageIndex, int? pageSize)
        {
            try
            {
                IsLogin();
                GropuDic();
                this.PostContentList = irainbow.sns_PostContent.Where(o => o.tid == tid).OrderBy(o => o.pid).ToPagedList(pageIndex ?? 1, pageSize ?? 15);
                //贴子数据
                this.sns_topic = irainbow.sns_topic.Where(o => o.tid == tid).SingleOrDefault();
                //回复数
                replayNum = irainbow.sns_topic.Where(o => o.tid == tid).Count();

                this.sns_forum = irainbow.sns_forum.Where(o => o.fid == this.sns_topic.fid).SingleOrDefault();

                this.CurrenCatalog = irainbow.sns_forum_catalog.Where(o => o.cid == sns_forum.cid).SingleOrDefault();

                //this.postList = irainbow.sns_Post.Where(o => o.tid == tid).SingleOrDefault();

                this.forumPostList = irainbow.sns_Post.Where(o => o.tid == tid).OrderBy(o => o.pid).ToPagedList(pageIndex ?? 1, pageSize ?? 15);

                //this.forumTopicList = irainbow.sns_topic.Where(o => o.authorico == sns_topic.authorico).ToPagedList(pageIndex ?? 1, 5);

                this.forumSuiTopicList = new List<sns_topic>();

                List<sns_Post> list = irainbow.sns_Post.Where(o => o.authorid == sns_topic.authorid).ToList();

                //var temp = irainbow.sns_Post.Where(o => o.authorid == list[i].authorid).Count();

                for (int i = 0; i < list.Count; i++)
                {
                    var r = new Random();

                    if (list.Count > 0)
                    {
                        if (forumSuiTopicList.Count <= 5)
                        {
                            //产生一个随机数
                            var ToSkip = r.Next(0, list.Count);

                            int a = list[i].authorid;

                            DataSys.sns_topic tempPic = irainbow.sns_topic.Where(o => o.authorid == a).OrderBy(o => o.fid).Skip(ToSkip).Take(1).FirstOrDefault();
                            //  tempPic.r
                            //(from e in irainbow.sns_Post where e.authorid == list[i].authorid orderby e.pid select e).Skip(ToSkip).Take(1).FirstOrDefault();
                            if (tempPic != null)
                            {
                                //判断是否已存在集合中
                                if (!forumSuiTopicList.Contains(tempPic))
                                {
                                    forumSuiTopicList.Add(tempPic);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }

                    }

                }
                sns_topic.views = sns_topic.views + 1;//查看帖子加一
                //   irainbow.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}