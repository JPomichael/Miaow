using System;
using System.Text.RegularExpressions;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// ҳ������У����
    /// </summary>
    public static class ValidateHelper
    {

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegNumber = new Regex("^[0-9]+$");//����

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");//��������

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");//С��

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //�ȼ���^[+-]?\d+[.]?\d+$

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w Ӣ����ĸ�����ֵ��ַ������� [a-zA-Z0-9] �﷨һ�� 

        /// <summary>
        /// 
        /// </summary>
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");//����

        /// <summary>
        /// ���Request��ѯ�ַ����ļ�ֵ���Ƿ������֣���󳤶�����
        /// </summary>
        /// <param name="req">Request</param>
        /// <param name="inputKey">Request�ļ�ֵ</param>
        /// <param name="maxLen">��󳤶�</param>
        /// <returns>����Request��ѯ�ַ���</returns>
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
        ////�������õ���Strings����ע����
        //            retVal =Utility.Strings.Sub(retVal, maxLen);
        //            if (!IsNumber(retVal))
        //                retVal = string.Empty;
        //        }
        //    }

        //    if(retVal == null)
        //        retVal = string.Empty;
        //    return retVal;
        //}

        /* IsInt �Ƿ�ΪInt
         * IsNumber �������ַ���,0,1,2,3.4������0��ͷ
         * IsNumberSign �Ƿ������ַ��� �ɴ�������
         * IsNumeric �����ֹ��ɵ��� 1 ��ͷ��
         * IsDecimal �Ƿ��Ǹ����� �ɴ�������
         * IsDecimalSign �Ƿ��Ǹ����� �ɴ������� 
         */
        #region ������֤

        /// <summary>
        /// �Ƿ�ΪInt
        /// </summary>
        /// <param name="source">�����ַ���</param>
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
        /// �������ַ���,0,1,2,3.4������0��ͷ^[0-9]+$
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsNumber(string str)
        {
            Match m = RegNumber.Match(str);
            return m.Success;
        }
        /// <summary>
        /// �Ƿ������ַ��� �ɴ�������^[+-]?[0-9]
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsNumberSign(string str)
        {
            Match m = RegNumberSign.Match(str);
            return m.Success;
        }
        /// <summary>
        /// �����ֹ��ɵ��� 1 ��ͷ�� [1-9]*[0-9]
        /// </summary>
        /// <param name="_value">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsNumeric(string str)
        {
            return QuickValidate("^[1-9]*[0-9]*$", str);
        }
        /// <summary>
        /// �Ƿ��Ǹ����� [0-9]+[.]?[0-9]+$
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsDecimal(string str)
        {
            Match m = RegDecimal.Match(str);
            return m.Success;
        }
        /// <summary>
        /// �Ƿ��Ǹ����� �ɴ������� ^[+-]?[0-9]+[.]?[0-9]+$
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsDecimalSign(string str)
        {
            Match m = RegDecimalSign.Match(str);
            return m.Success;
        }
        #endregion

        /// <summary>
        /// ����Ƿ��������ַ� [\u4e00-\u9fa5]
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsHasCHZN(string str)
        {
            Match m = RegCHZN.Match(str);
            return m.Success;
        }

        /// <summary>
        /// �Ƿ����ʼ���ַ ^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsEmail(string str)
        {
            Match m = RegEmail.Match(str);
            return m.Success;
        }

        /// <summary>
        /// �ж�һ���ַ����Ƿ�ʱ���ʽ
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsDateTime(string str)
        {
            try
            {
                Convert.ToDateTime(str);
                return true;//��   
            }
            catch
            {
                return false;//����   
            }
        }

        /// <summary>
        /// �Ƿ��Ǵ���ĸ������ ^[a-zA-Z0-9_]*$
        /// </summary>
        /// <param name="_value">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsNumberOrLetter(string str)
        {
            return QuickValidate("^[a-zA-Z0-9_]*$", str);
        }

        /// <summary>
        /// �ж��Ƿ������֣�����С�������� ^(0|([1-9]+[0-9]*))(.[0-9]+)?$
        /// </summary>
        /// <param name="_value">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsFloat(string str)
        {
            return QuickValidate("^(0|([1-9]+[0-9]*))(.[0-9]+)?$", str);
        }

        /// <summary>
        /// �ж�һ���ַ����Ƿ�Ϊ�ֻ����� ^(130|131|132|133|134|135|136|137|138|139|150|151|152|158|159)\d{8}$
        /// </summary>
        /// <param name="_value">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsMobileNum(string str)
        {
            Regex regex = new Regex(@"^(130|131|132|133|134|135|136|137|138|139|150|151|152|153|154|155|156|157|158|159|180|181|182|183|184|185|186|187|188|189)\d{8}$", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// �ж�һ���ַ����Ƿ�Ϊ�绰���� ^(86)?(-)?(0\d{2,3})?(-)?(\d{7,8})(-)?(\d{3,5})?$
        /// </summary>
        /// <param name="_value">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsPhoneNum(string str)
        {
            Regex regex = new Regex(@"^(86)?(-)?(0\d{2,3})?(-)?(\d{7,8})(-)?(\d{3,5})?$", RegexOptions.IgnoreCase);
            return regex.Match(str).Success;
        }

        /// <summary>
        /// �ж�һ���ַ����Ƿ�Ϊ��ַ ^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?(([0-9]{1,3}.){3}[0-9]{1,3}|([0-9a-z_!~*'()-]+.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z].[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$
        /// </summary>
        /// <param name="_value">�����ַ���</param>
        /// <returns>true or false</returns>
        public static bool IsUrl(string str)
        {
            string re = "^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?(([0-9]{1,3}.){3}[0-9]{1,3}|([0-9a-z_!~*'()-]+.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z].[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            Regex regex = new Regex(re, RegexOptions.IgnoreCase);
            bool b = regex.Match(str).Success;
            return b;
        }

        /// <summary>
        /// ������֤һ���ַ����Ƿ����ָ����������ʽ��
        /// </summary>
        /// <param name="_express">������ʽ</param>
        /// <param name="_value">�����ַ���</param>
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
        /// �ж�һ���ַ����Ƿ�ΪID��ʽ
        /// </summary>
        /// <param name="source">�����ַ���</param>
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
        /// �Ƿ����ض��ַ����
        /// </summary>
        /// <param name="strInput">�����ַ���</param>
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
        /// �Ƿ����ض��ַ����
        /// </summary>
        /// <param name="strInput">�����ַ���</param>
        /// <param name="charInput">������ʾ</param>
        /// <param name="lenInput">û������</param>
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
        /// �������Ĳ����ǲ���ĳЩ����õ������ַ����������Ŀǰ������������İ�ȫ���
        /// </summary>
        /// <param name="strInput">�����ַ���</param>
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
