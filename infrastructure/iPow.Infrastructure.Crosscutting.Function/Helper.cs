using System;
using System.Net.Mail;

using Dimac.JMail;

namespace iPow.Infrastructure.Crosscutting.Function
{
    public static partial class Helper
    {
        #region 分页
        /// <summary>
        /// 首页 上一页 下一页 尾页
        /// </summary>
        /// <param name="IsReCount">The is re count.</param>
        /// <param name="Page_Size">Size of the page_.</param>
        /// <param name="PageIndex">Index of the page.</param>
        /// <param name="strURL">The STR URL.</param>
        /// <returns></returns>
        public static string PageGo(int IsReCount, int Page_Size, int PageIndex, string strURL)
        {
            int totalPages = int.Parse(Math.Ceiling((double)IsReCount / Page_Size).ToString());
            if (PageIndex < 1)
            {
                PageIndex = 1;
            }
            if (PageIndex > totalPages)
            {
                PageIndex = totalPages;
            }

            string PageHTML = "";
            PageHTML = PageHTML + "<span>共<font color='#FF0000'>" + IsReCount + "</font>条&nbsp;&nbsp;页次：<font color='#FF0000'>" + PageIndex + "</font>/<font color='#FF0000'>" + totalPages + "</font></span>" + System.Environment.NewLine;
            if (PageIndex <= 1)
            {
                PageHTML = PageHTML + "<span><img src=\"../../images/default/first.gif\"  border=\"0\" alt=\"首页\"/>&nbsp;</span><span><img src=\"../../images/default/back.gif\"  border=\"0\"  alt=\"上一页\"/></span>";
            }
            else
            {
                PageHTML = PageHTML + "<span><a href='" + strURL + "&PageIndex=1'><img src=\"../../images/default/first.gif\"  border=\"0\" alt=\"首页\"/></A>&nbsp;</span><span><A href='" + strURL + "&PageIndex=" + (PageIndex - 1) + "'><img src=\"../../images/default/back.gif\"  border=\"0\"  alt=\"上一页\"/></A></span>";
            }
            if (PageIndex >= totalPages)
            {
                PageHTML = PageHTML + "<span>&nbsp;<img src=\"../../images/default/next.gif\"  border=\"0\"  alt=\"下一页\"/>&nbsp;</span><span><img src=\"../../images/default/last.gif\"  border=\"0\"  alt=\"尾页\"/></span>";
            }
            else
            {
                PageHTML = PageHTML + "<span>&nbsp;<A href='" + strURL + "&pageIndex=" + (PageIndex + 1) + "'><img src=\"../../images/default/next.gif\"  border=\"0\"  alt=\"下一页\"/></A>&nbsp;</span><span><A href='" + strURL + "&pageIndex=" + totalPages + "'><img src=\"../../images/default/last.gif\"  border=\"0\"  alt=\"尾页\"/></A></span>";
            }
            return PageHTML;
        }
        #endregion

        #region ajax分页

        //function ajaxShowPage(ur, para, index) {
        //          $.ajax({
        //              type: 'Get',
        //              url: ur + "?" + para + "=" + index,
        //              data: {},
        //              timeout: 6000,
        //              //data: { searchKey: search },
        //              beforeSend: function () {
        //                  //AjaxStart();
        //              },
        //              success: function (msg) {
        //                  $("#updateDiv").html(msg);
        //                  //AjaxStop();
        //              },
        //              complete: function () {
        //                  //AjaxStop();
        //              },
        //              error: function () {
        //                  //AjaxStop();
        //              }
        //          });
        //      }
        /// <summary>
        /// 首页 上一页 下一页 尾页
        /// </summary>
        /// <param name="isReCount">The is re count.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="url">The URL.</param>
        /// <param name="pageParm">The page parm.</param>
        /// <param name="ajaxFunctionName">The ajax function.</param>
        /// <returns></returns>
        public static string PageGo(int isReCount, int pageSize, int pageIndex, string url, string pageParm, string ajaxFunctionName)
        {
            int totalPages = int.Parse(Math.Ceiling((double)isReCount / pageSize).ToString());
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageIndex > totalPages)
            {
                pageIndex = totalPages;
            }
            string pageHtml = "";
            pageHtml = pageHtml + "<span>共<font color=\"#FF0000\">" + isReCount + "</font>条&nbsp;&nbsp;页次：<font color=\"#FF0000\">" + pageIndex + "</font>/<font color=\"#FF0000\">" + totalPages + "</font></span>" + System.Environment.NewLine;
            if (pageIndex <= 1)
            {
                pageHtml = pageHtml + "<span><a href = \"javascript:;\" >首页</a>&nbsp;</span><span><a href = \"javascript:;\">上一页</a> </span>";
            }
            else
            {
                pageHtml = pageHtml + "<span><a href=\"javascript:;\" onclick = \"" + ajaxFunctionName + "('" + url + "','" + pageParm + "',1);\">首页</a>&nbsp;</span><span><a href=\"javascript:;\" onclick = \"" + ajaxFunctionName + "('" + url + "','" + pageParm + "'," + (pageIndex - 1) + ");\">上一页</a></span>";
            }
            if (pageIndex >= totalPages)
            {
                pageHtml = pageHtml + "<span>&nbsp; <a href = \"javascript:;\">下一页</a>&nbsp;</span><span> <a href =\"javascript:;\">尾页</a></span>";
            }
            else
            {
                pageHtml = pageHtml + "<span>&nbsp;<a href=\"javascript:;\" onclick = \"" + ajaxFunctionName + "('" + url + "','" + pageParm + "'," + (pageIndex + 1) + ");\">下一页</a>&nbsp;</span><span><a href=\"javascript:;\" onclick = \"" + ajaxFunctionName + "('" + url + "','" + pageParm + "'," + totalPages + ");\">尾页</a></span>";
            }
            return pageHtml;
        }

        #endregion

        //第一个参数如果是163邮箱就写smtp.163.com
        //第二个参数发件人的帐号
        //第三个参数发件人密码
        //第四个参数收件人帐号
        //第五个参数主题
        //第六个参数内容.
        public static void SendSmtpMail(string strSmtpServer, string strFrom, string strFromPass, string strto, string strSubject, string strBody)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient(strSmtpServer);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            System.Net.Mail.MailMessage message = new MailMessage(strFrom, strto, strSubject, strBody);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.Send(message);
        }

        /// <summary>
        /// Sendmails the specified from.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="address">The address.</param>
        /// <param name="subject">The title.</param>
        /// <param name="bodyhtml">The bodyhtml.</param>
        /// <returns></returns>
        public static bool SendJmail(string from, string address, string subject, string bodyhtml)
        {
            Dimac.JMail.Message message = new Message();
            message.From = from;
            message.To.Add(address);
            message.Subject = subject;
            message.Charset = System.Text.Encoding.GetEncoding("gb2312");
            message.BodyHtml = bodyhtml;
            try
            {
                Smtp.Send(message, "smtp.exmail.qq.com", 25, "smtp.exmail.qq.com", SmtpAuthentication.Login, "bjhappyvalley@ipow.cn", "ipow@2010");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sends the jmail.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="address">The address.</param>
        /// <param name="title">The title.</param>
        /// <param name="bodyhtml">The bodyhtml.</param>
        /// <param name="encode">The encode.</param>
        /// <param name="user">The user.</param>
        /// <param name="pwd">The PWD.</param>
        /// <returns></returns>
        public static bool SendJmail(string from, string address, string title, string bodyhtml, System.Text.Encoding encode, string user, string pwd)
        {
            Dimac.JMail.Message message = new Message();
            message.From = from;
            var addressArray = address.Split(',');
            foreach (var item in addressArray)
            {
                message.To.Add(item);
            }
            message.Subject = title;
            message.Charset = encode;
            message.BodyHtml = bodyhtml;
            try
            {
                Smtp.Send(message, "smtp.exmail.qq.com", 25, "smtp.exmail.qq.com", SmtpAuthentication.Login, user, pwd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Allows the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static bool AllowUrl(string url)
        {
            string[] str = new string[] { "http://192.168.1.173:809/activity/pjgame/index.shtml",
                "http://192.168.1.173:809/activity/pjgame/#",
                "http://192.168.1.173:809/activity/pjgame/" 
            };
            bool res = false;
            foreach (var item in str)
            {
                if (item.ToLower().CompareTo(url) == 0)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
    }
}