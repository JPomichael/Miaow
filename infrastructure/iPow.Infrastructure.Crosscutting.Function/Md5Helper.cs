using System;
using System.Text;
using System.Security.Cryptography;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// md5加密
    /// Copyright (C) 2008-2010 深圳互动力科技有限公司
    /// All rights reserved
    /// </summary>
    public class Md5Helper
    {
        public Md5Helper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            // 
        }

        /// <summary>
        /// BBSMs the d5.
        /// </summary>
        /// <param name="Str">The STR.</param>
        /// <returns></returns>
        public static byte[] BBSMD5(string Str)
        {
            SHA1 md5 = new SHA1CryptoServiceProvider();
            Byte[] pass = ConvertStringToByteArray(Str);
            byte[] pass_byte = md5.ComputeHash(pass);
            return pass_byte;
        }

        /// <summary>
        /// Converts the string to byte array.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static Byte[] ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
    }
}
