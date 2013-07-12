using System;
using System.Text.RegularExpressions;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// 页面数据校验类
    /// </summary>
    public static class ValidateHelper
    {

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegNumber = new Regex("^[0-9]+$");//整数

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");//正负整数

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");//小数

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");//中文

        /// <summary>
        /// 检查Request查询字符串的键值，是否是数字，最大长度限制
        /// </summary>
        /// <param name="req">Request</param>
        /// <param name="inputKey">Request的键值</param>
        /// <param name="maxLen">最大长度</param>
        /// <returns>返回Request查询字符串</returns>
        //public static string FetchInputDigit(HttpRequest req, string str, int maxLen)
        //{
        //    string retVal = string.Empty;
        //    if(str != null && str != string.Empty)
        //    {
        //        retVal = req.QueryString[str];
        //        if(null == retVal)
        //            retVal = req.Form[str];
        //        if(null != retVal)
        //        {
        ////edit by yjihrp 2011.4.15
        ////这里引用到了Strings所以注释了
        //            retVal =Utility.Strings.Sub(retVal, maxLen);
        //            if (!IsNumber(retVal))
        //                retVal = string.Empty;
        //        }
        //    }

        //    if(retVal == null)
        //        retVal = string.Empty;
        //    return retVal;
        //}

        /* IsInt 是否为Int
         * IsNumber 纯数字字符串,0,1,2,3.4可以是0开头
         * IsNumberSign 是否数字字符串 可带正负号
         * IsNumeric 纯数字构成的以 1 开头的
         * IsDecimal 是否是浮点数 可带正负号
         * IsDecimalSign 是否是浮点数 可带正负号 
         */
        #region 数字验证

        /// <summary>
        /// 是否为Int
        /// </summary>
        /// <param name="source">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsInt(string str)
        {
            Regex regex = new Regex(@"^(-){0,1}\d+$");
            if (regex.Match(str).Success)
            {
                if ((long.Parse(str) > 0x7fffffffL) || (long.Parse(str) < -2147483648L))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 纯数字字符串,0,1,2,3.4可以是0开头^[0-9]+$
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsNumber(string str)
        {
            Match m = RegNumber.Match(str);
            return m.Success;
        }
        /// <summary>
        /// 是否数字字符串 可带正负号^[+-]?[0-9]
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsNumberSign(string str)
        {
            Match m = RegNumberSign.Match(str);
            return m.Success;
        }
        /// <summary>
        /// 纯数字构成的以 1 开头的 [1-9]*[0-9]
        /// </summary>
        /// <param name="_value">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsNumeric(string str)
        {
            return QuickValidate("^[1-9]*[0-9]*$", str);
        }
        /// <summary>
        /// 是否是浮点数 [0-9]+[.]?[0-9]+$
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsDecimal(string str)
        {
            Match m = RegDecimal.Match(str);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数 可带正负号 ^[+-]?[0-9]+[.]?[0-9]+$
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsDecimalSign(string str)
        {
            Match m = RegDecimalSign.Match(str);
            return m.Success;
        }
        #endregion

        /// <summary>
        /// 检测是否有中文字符 [\u4e00-\u9fa5]
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsHasCHZN(string str)
        {
            Match m = RegCHZN.Match(str);
            return m.Success;
        }

        /// <summary>
        /// 是否是邮件地址 ^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsEmail(string str)
        {
            Match m = RegEmail.Match(str);
            return m.Success;
        }

        /// <summary>
        /// 判断一个字符串是否时间格式
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsDateTime(string str)
        {
            try
            {
                Convert.ToDateTime(str);
                return true;//是   
            }
            catch
            {
                return false;//不是   
            }
        }

        /// <summary>
        /// 是否是纯字母和数字 ^[a-zA-Z0-9_]*$
        /// </summary>
        /// <param name="_value">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsNumberOrLetter(string str)
        {
            return QuickValidate("^[a-zA-Z0-9_]*$", str);
        }

        /// <summary>
        /// 判断是否是数字，包括小数和整数 ^(0|([1-9]+[0-9]*))(.[0-9]+)?$
        /// </summary>
        /// <param name="_value">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsFloat(string str)
        {
            return QuickValidate("^(0|([1-9]+[0-9]*))(.[0-9]+)?$", str);
        }

        /// <summary>
        /// 判断一个字符串是否为手机号码 ^(130|131|132|133|134|135|136|137|138|139|150|151|152|158|159)\d{8}$
        /// </summary>
        /// <param name="_value">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsMobileNum(string str)
        {
            Regex regex = new Regex(@"^(130|131|132|133|134|135|136|137|138|139|150|151|152|153|154|155|156|157|158|159|180|181|182|183|184|185|186|187|188|189)\d{8}$", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为电话号码 ^(86)?(-)?(0\d{2,3})?(-)?(\d{7,8})(-)?(\d{3,5})?$
        /// </summary>
        /// <param name="_value">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsPhoneNum(string str)
        {
            Regex regex = new Regex(@"^(86)?(-)?(0\d{2,3})?(-)?(\d{7,8})(-)?(\d{3,5})?$", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// 判断一个字符串是否为网址 ^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?(([0-9]{1,3}.){3}[0-9]{1,3}|([0-9a-z_!~*'()-]+.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z].[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$
        /// </summary>
        /// <param name="_value">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsUrl(string str)
        {
            string re = "^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?(([0-9]{1,3}.){3}[0-9]{1,3}|([0-9a-z_!~*'()-]+.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z].[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            Regex regex = new Regex(re, RegexOptions.IgnoreCase);
            bool b = regex.Match(str).Success;
            return b;
        }

        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="_express">正则表达式</param>
        /// <param name="_value">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool QuickValidate(string express, string str)
        {
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex(express);
            if (str.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(str);
        }

        /// <summary>
        /// 判断一个字符串是否为ID格式
        /// </summary>
        /// <param name="source">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsIDCard(string str)
        {
            Regex regex;
            string[] strArray;
            DateTime time;
            if ((str.Length != 15) && (str.Length != 0x12))
            {
                return false;
            }
            if (str.Length == 15)
            {
                regex = new Regex(@"^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})$");
                if (!regex.Match(str).Success)
                {
                    return false;
                }
                strArray = regex.Split(str);
                try
                {
                    time = new DateTime(int.Parse("19" + strArray[2]), int.Parse(strArray[3]), int.Parse(strArray[4]));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            regex = new Regex(@"^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9Xx])$");
            if (!regex.Match(str).Success)
            {
                return false;
            }
            strArray = regex.Split(str);
            try
            {
                time = new DateTime(int.Parse(strArray[2]), int.Parse(strArray[3]), int.Parse(strArray[4]));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否由特定字符组成
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsContainSameChar(string str)
        {
            string charInput = string.Empty;
            if (!string.IsNullOrEmpty(str))
            {
                charInput = str.Substring(0, 1);
            }
            return IsContainSameChar(str, charInput, str.Length);
        }

        /// <summary>
        /// 是否由特定字符组成
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <param name="charInput">正则表达示</param>
        /// <param name="lenInput">没有用样</param>
        /// <returns>true or false</returns>
        public static bool IsContainSameChar(string str, string charInput, int len)
        {
            if (string.IsNullOrEmpty(charInput))
            {
                return false;
            }
            else
            {
                Regex RegNumber = new Regex(string.Format("^([{0}])+$", charInput));
                Match m = RegNumber.Match(str);
                return m.Success;
            }
        }

        /// <summary>
        /// 检查输入的参数是不是某些定义好的特殊字符：这个方法目前用于密码输入的安全检查
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>true or false</returns>
        public static bool IsContainSpecChar(string str)
        {
            string[] list = new string[] { "123456", "654321" };
            bool result = new bool();
            for (int i = 0; i < list.Length; i++)
            {
                if (str == list[i])
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
