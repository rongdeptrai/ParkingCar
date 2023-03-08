using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyParkingCL.Common
{
    public class Encryptor
    {
        public static string EncryptMD5(string sToEncrypt)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(sToEncrypt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);
            string hashString = "";
            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }
            return hashString.PadLeft(32, '0');
        }

        internal static object EncryptMD5(object passWord)
        {
            throw new NotImplementedException();
        }
    }
}