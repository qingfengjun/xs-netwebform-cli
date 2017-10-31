using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsFramework.Function.Encrypt
{
    public class Encrypt
    {
        /// <summary>
        /// encrypt with md5 and base64
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncryptMD5(string value)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] MD5Source = System.Text.Encoding.UTF8.GetBytes(value);
            byte[] MD5Out = MD5CSP.ComputeHash(MD5Source);
            return Convert.ToBase64String(MD5Out);
        }

        /// <summary>
        /// base64加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncryptBase64(string value)
        {

            string strResult = "";

            if (!string.IsNullOrEmpty(value))
            {
                strResult = Convert.ToBase64String(System.Text.ASCIIEncoding.Default.GetBytes(value));
            }

            if (strResult.Length > value.Length)
            {
                //set my a XES$ in the center
                strResult = strResult.Substring(0, value.Length) + "XES$" + strResult.Substring(value.Length, strResult.Length - value.Length);
            }
            else
            {
                strResult = strResult.Substring(0, strResult.Length / 2) + "XES$" + strResult.Substring(strResult.Length / 2, strResult.Length - strResult.Length / 2);
            }
            return strResult;


        }
        /// <summary>
        /// base 64 解密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DeEncryptBase64(string value)
        {
            string strResult = "";
            if (!string.IsNullOrEmpty(value))
            {
                strResult = System.Text.ASCIIEncoding.Default.GetString(Convert.FromBase64String(value.Replace("XES$", "")));
            }

            return strResult;
        }

    }
}
