using System.Web;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// JS工具集
    /// Copyright (C) 2008-2010 深圳互动力科技有限公司
    /// All rights reserved
    /// </summary>
    public class JavaScriptHelper
    {
        public static void AlertAndRedirect(string message, string toURL)
        {
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        }

        #region 向客户端发送函数KendoPostBack(eventTarget, eventArgument)
        /// <summary>
        /// 向客户端发送函数KendoPostBack(eventTarget, eventArgument)
        /// 服务器端可接收__EVENTTARGET,__EVENTARGUMENT的值
        /// </summary>
        /// <param name="page">System.Web.UI.Page 一般为this</param>
        public static void JscriptSender(System.Web.UI.Page page)
        {
            page.ClientScript.RegisterHiddenField("__EVENTTARGET", "");
            page.ClientScript.RegisterHiddenField("__EVENTARGUMENT", "");
            string s = @" 
<script language=Javascript>
      function KendoPostBack(eventTarget, eventArgument) 
      {
var theform = document.forms[0];
theform.__EVENTTARGET.value = eventTarget;
theform.__EVENTARGUMENT.value = eventArgument;
theform.submit();
}
";

            page.ClientScript.RegisterHiddenField("sds", s);
        }
        #endregion

        #region 弹出JavaScript小窗口
        /// <summary>
        /// 弹出JavaScript小窗口
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void Alert(string message)
        {
            message = message.Trim();
            string js = @"<Script language='JavaScript'>
                    alert('" + message + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 提示是否进行操作，否就关闭窗口
        /// <summary>
        /// 提示是否进行操作，否就关闭窗口
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void Confirm(string message, string url)
        {
            message = message.Trim();
            string js = @"<Script language='JavaScript'>
                    if (confirm('" + message + "')) location.href='" + url + "'; else window.close();</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 提示是否进行操作，否就转到BackUrl
        /// <summary>
        /// 提示是否进行操作，否就转到BackUrl
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="url">成功转向</param>
        /// <param name="BackUrl">失败转向</param>
        public static void ConfirmBack(string message, string url, string BackUrl)
        {
            message = message.Trim();
            string js = @"<Script language='JavaScript'>
                    if (confirm('" + message + "')) location.href='" + url + "'; else location.href='" + BackUrl + "';</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion


        public static void RtnRltMsgbox(object message, string strWinCtrl)
        {
            string js = @"<Script language='JavaScript'>
 strWinCtrl = true;
                     strWinCtrl = if(!confirm('" + message + "'))return false;</Script>";
            HttpContext.Current.Response.Write(string.Format(js, message.ToString()));
        }

        #region 回到历史页面
        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
        }
        #endregion

        #region 关闭当前窗口
        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            string js = @"<Script language='JavaScript'>
                    window.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 刷新父窗口
        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent()
        {
            string js = @"<Script language='JavaScript'>
                    parent.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 格式化为JS可解释的字符串
        /// <summary>
        /// 格式化为JS可解释的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string JSStringFormat(string s)
        {
            return s.Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\\'").Replace("\"", "\\\"");
        }
        #endregion

        #region 刷新打开窗口
        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 打开窗口
        /// <summary>
        /// 打开窗口
        /// </summary>
        /// <param name="url"></param>
        public static void OpenWebForm(string url)
        {
            string js = @"<Script language='JavaScript'>
//window.open('" + url + @"');
window.open('" + url + @"',','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region OpenWebForm
        public static void OpenWebForm(string url, string name, string future)
        {
            string js = @"<Script language='JavaScript'>
                     window.open('" + url + @"','" + name + @"','" + future + @"')
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region OpenWebForm
        public static void OpenWebForm(string url, string formName)
        {
            string js = @"<Script language='JavaScript'>
//window.open('" + url + @"','" + formName + @"');
window.open('" + url + @"','" + formName + @"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 打开WEB窗口
        /// <param name="url">WEB窗口</param>
        /// <param name="isFullScreen">是否全屏幕</param>
        public static void OpenWebForm(string url, bool isFullScreen)
        {
            string js = @"<Script language='JavaScript'>";
            if (isFullScreen)
            {
                js += "var iWidth = 0;";
                js += "var iHeight = 0;";
                js += "iWidth=window.screen.availWidth-10;";
                js += "iHeight=window.screen.availHeight-50;";
                js += "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
                js += "window.open('" + url + @"',',szFeatures);";
            }
            else
            {
                js += "window.open('" + url + @"',','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            }
            js += "</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 转向Url制定的页面
        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url"></param>
        public static void JavaScriptLocationHref(string url)
        {
            string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 指定的框架页面转换
        /// <summary>
        /// 指定的框架页面转换
        /// </summary>
        /// <param name="FrameName"></param>
        /// <param name="url"></param>
        public static void JavaScriptFrameHref(string FrameName, string url)
        {
            string js = @"<Script language='JavaScript'>

                    @obj.location.replace(""{0}"";
                  </Script>";
            js = js.Replace("@obj", FrameName);
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 重置页面
        /// <summary>
        ///重置页面
        /// </summary>
        public static void JavaScriptResetPage(string strRows)
        {
            string js = @"<Script language='JavaScript'>
                    window.parent.CenterFrame.rows='" + strRows + "';</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 客户端方法设置Cookie
        /// <summary>
        /// 函数名:JavaScriptSetCookie
        /// 功能描述:客户端方法设置Cookie
        /// </summary>
        /// <param name="strName">Cookie名</param>
        /// <param name="strValue">Cookie值</param>
        public static void JavaScriptSetCookie(string strName, string strValue)
        {
            string js = @"<script language=Javascript>
var the_cookie = '" + strName + "=" + strValue + @"'
var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';
//document.cookie = the_cookie;//写入Cookie<BR>} <BR>
document.cookie = the_cookie + '; expires='+dateexpire; 
";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 返回父窗口
        /// <summary> 
        /// 函数名:GotoParentWindow 
        /// 功能描述:返回父窗口 
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param> 
        public static void GotoParentWindow(string parentWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    this.parent.location.replace('" + parentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换父窗口
        /// <summary> 
        /// 函数名:ReplaceParentWindow 
        /// 功能描述:替换父窗口 
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param>
        /// <param name="caption">窗口提示</param>
        /// <param name="future">窗口特征参数</param>
        public static void ReplaceParentWindow(string parentWindowUrl, string caption, string future)
        {
            string js = "";
            if (future != null && future.Trim() != "")
            {
                js = @"<script language=javascript>this.parent.location.replace('" + parentWindowUrl + "','" + caption + "','" + future + "');";
            }
            else
            {
                js = @"<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;
var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('" + parentWindowUrl + "','" + caption + "',szFeatures);";
            }

            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换当前窗体的打开窗口
        /// <summary> 
        /// 函数名:ReplaceOpenerWindow 
        /// 功能描述:替换当前窗体的打开窗口 
        /// </summary>
        /// <param name="openerWindowUrl">当前窗体的打开窗口</param> 
        public static void ReplaceOpenerWindow(string openerWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.location.replace('" + openerWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换当前窗体的打开窗口的父窗口
        /// <summary> 
        /// 函数名:ReplaceOpenerParentWindow 
        /// 功能描述:替换当前窗体的打开窗口的父窗口 
        /// </summary>
        /// <param name="openerWindowUrl">当前窗体的打开窗口的父窗口</param> 
        public static void ReplaceOpenerParentFrame(string frameName, string frameWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.parent." + frameName + ".location.replace('" + frameWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换当前窗体的打开窗口的父窗口
        /// <summary> 
        /// 函数名:ReplaceOpenerParentWindow 
        /// 功能描述:替换当前窗体的打开窗口的父窗口 
        /// </summary>
        /// <param name="openerWindowUrl">当前窗体的打开窗口的父窗口</param> 
        public static void ReplaceOpenerParentWindow(string openerParentWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.parent.location.replace('" + openerParentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 关闭窗口
        /// <summary> 
        /// 函数名:CloseParentWindow 
        /// 功能描述:关闭窗口 
        /// </summary>
        public static void CloseParentWindow()
        {
            string js = @"<Script language='JavaScript'>
                    window.parent.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void CloseOpenerWindow()
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 返回打开模式窗口的脚本
        /// <summary>
        /// 函数名:ShowModalDialogJavascript 
        /// 功能描述:返回打开模式窗口的脚本 
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static string ShowModalDialogJavascript(string webFormUrl)
        {
            string js = @"<script language=javascript>
var iWidth = 0 ;
var iHeight = 0 ;
iWidth=window.screen.availWidth-10;
iHeight=window.screen.availHeight-50;
var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';
showModalDialog('" + webFormUrl + "',',szFeatures);";
            return js;
        }

        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            string js = @"<script language=javascript> 
showModalDialog('" + webFormUrl + "',','" + features + "');";
            return js;
        }
        #endregion

        #region 打开模式窗口
        /// <summary>
        /// 函数名:ShowModalDialogWindow 
        /// 功能描述:打开模式窗口 
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static void ShowModalDialogWindow(string webFormUrl)
        {
            string js = ShowModalDialogJavascript(webFormUrl);
            HttpContext.Current.Response.Write(js);
        }

        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=no";
            ShowModalDialogWindow(webFormUrl, features);
        }

        public static void SetHtmlElementValue(string formName, string elementName, string elementValue)
        {
            string js = @"<Script language='JavaScript'>if(document." + formName + "." + elementName + "!=null){document." + formName + "." + elementName + ".value =" + elementValue + ";}</Script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion
    }
}
