using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

using System.Web;

namespace iPow.Infrastructure.Crosscutting.Function
{
    public class UserIncHelper
    {
        //cookies加密密钥
        public static string DES_Key = "52364178";

        #region DESEnCode DES加密
        public static string DESEnCode(string pToEncrypt, string sKey)
        {
            pToEncrypt = HttpContext.Current.Server.UrlEncode(pToEncrypt);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量 
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法 
            //使得输入密码必须输入英文文本 
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        #endregion

        #region DESDeCode DES解密
        public static string DESDeCode(string pToDecrypt, string sKey)
        {
            //    HttpContext.Current.Response.Write(pToDecrypt + "<br>" + sKey);
            //    HttpContext.Current.Response.End();
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            return HttpContext.Current.Server.UrlDecode(System.Text.Encoding.Default.GetString(ms.ToArray()));
        }
        #endregion

        #region 加密Username的Cookies
        /// <summary>
        /// username cookies加密
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string DESEnCode_Username(string username)
        {
            username = HttpContext.Current.Server.UrlEncode(username);
            username = DESEnCode(username, DES_Key);
            return username;
        }
        #endregion

        #region 加密UserID的Cookies
        /// <summary>
        /// userid cookies加密
        /// </summary>
        public string DESEnCode_UserID(string userid)
        {
            userid = DESEnCode(userid, DES_Key);
            return userid;
        }
        #endregion

        #region 解密Username的Cookies
        /// <summary>
        /// username cookies解密
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string DESDeCode_Username(string username)
        {
            username = DESDeCode(username, DES_Key);
            username = HttpContext.Current.Server.UrlDecode(username);
            return username;
        }
        #endregion

        #region 解密UserID的Cookies
        /// <summary>
        /// userid cookies解密
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string DESDeCode_UserID(string userid)
        {
            userid = DESDeCode(userid, DES_Key);
            return userid;
        }
        #endregion
        public UserIncHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
}
