using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;
using System.IO;

namespace Wbm.TencV2SDK.Helpers
{
    /// <summary>
    /// 加密助手
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// DES算法加密
        /// </summary>
        /// <param name="pToEncrypt">明文</param>
        /// <param name="sKey">加密Key</param>
        /// <returns></returns>
        public static string DesEncrypt(string pToEncrypt, string sKey)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(pToEncrypt);
            provider.Key = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(sKey));
            provider.Mode = CipherMode.ECB;
            provider.Padding = PaddingMode.PKCS7;
            MemoryStream stream = new MemoryStream();
            CryptoStream crypto = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            crypto.Write(bytes, 0, bytes.Length);
            crypto.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            builder.ToString();
            stream.Close();
            crypto.Clear();
            crypto.Close();
            provider.Clear();
            return builder.ToString();
        }

        /// <summary>
        /// DES算法解密
        /// </summary>
        /// <param name="pToDecrypt">密文</param>
        /// <param name="sKey">加密Key</param>
        /// <returns></returns>
        public static string DesDecrypt(string pToDecrypt, string sKey)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            byte[] buffer = new byte[pToDecrypt.Length / 2];
            for (int i = 0; i < (pToDecrypt.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte)num2;
            }
            provider.Key = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(sKey));
            provider.Mode = CipherMode.ECB;
            provider.Padding = PaddingMode.PKCS7;
            MemoryStream stream = new MemoryStream();
            CryptoStream crypto = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            crypto.Write(buffer, 0, buffer.Length);
            crypto.FlushFinalBlock();
            string builder = Encoding.UTF8.GetString(stream.ToArray());
            stream.Close();
            crypto.Clear();
            crypto.Close();
            provider.Clear();
            return builder;
        }

        /// <summary>
        /// HMACSHA256函数
        /// </summary>
        /// <param name="data">原始字符串</param>
        /// <param name="key">加密key</param>
        /// <returns>HMACSHA256结果</returns>
        public static string HashHmac(string data, string key)
        {
            byte[] keys = Encoding.UTF8.GetBytes(key);
            byte[] content = Encoding.UTF8.GetBytes(data);
            var hmacsha256 = new HMACSHA256(keys);
            byte[] ret = hmacsha256.ComputeHash(content);
            return Encoding.UTF8.GetString(ret);
        }

        /// <summary>
        /// 将字符串以 BASE64 编码。
        /// </summary>
        /// <param name="str"></param>
        /// <returns> BASE64 编码结果</returns>
        public static string Base64Encode(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str)).TrimEnd('=');
        }

        /// <summary>
        /// 将字符串以 BASE64 解码。
        /// </summary>
        /// <param name="str"></param>
        /// <returns>BASE64 解码结果</returns>
        public static string Base64Decode(string str)
        {
            int bit = 4;
            str += new string('=', (str.Length % bit > 0 ? bit - str.Length % bit : 0));
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */