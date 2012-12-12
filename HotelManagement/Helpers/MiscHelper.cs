/***************************************************************************\
Module Name:    MiscHelper
Author:         Viral Christian
Description:    

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using HotelManagement.Helpers.CacheHelpers;
using System.Web.Script.Serialization;

namespace HotelManagement.Helpers
{
    public static class MiscHelper
    {
        private const string initVector = "tu0XgEbi140y89u2";
        private const int keysize = 256;

        public static SelectListItem EmptySelectListItem(this SelectList selectList)
        {
            SelectListItem item = new SelectListItem();
            item.Text = String.Empty;
            item.Value = "0";
            return item;
        }

        public static string AppSetting(this HtmlHelper helper, string settingName)
        {
            return AppCache.AllSettings.FirstOrDefault(s => s.Name == settingName).Value;                        
        }

        public static string AppSetting(string settingName)
        {
            return AppCache.AllSettings.FirstOrDefault(s => s.Name == settingName).Value;
        }

        public static string Encrypt(string plainText)
        {
            string passPhrase = MiscHelper.AppSetting("SecretEncryptText");

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string cipherText)
        {
            string passPhrase = MiscHelper.AppSetting("SecretEncryptText");

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public static string ToJson(object data)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(data);
        }

        public static T FromJson<T>(string data)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            T obj = jss.Deserialize<T>(data);
            return obj;
        }

        public static int GetMonth(string month)
        {
            switch(month.ToLower())
            {
                case "jan":
                case "january":
                    return 1;

                case "feb":
                case "february":
                    return 2;

                case "mar":
                case "march":
                    return 3;
                    
                case "apr":
                case "april":
                    return 4;
                    
                case "may":
                    return 5;
                    
                case "jun":
                case "june":
                    return 6;
                                        
                case "jul":
                case "july":
                    return 7;

                case "aug":
                case "august":
                    return 8;

                case "sep":
                case "september":
                    return 9;

                case "oct":
                case "october":
                    return 10;

                case "nov":
                case "november":
                    return 11;

                case "dec":
                case "december":
                    return 12;

                default:
                    return 0;
            }
        }

        public static string GetMonth(int month)
        {
            switch (month)
            {
                case 1:                
                    return "jan";

                case 2:                
                    return "feb";

                case 3:
                    return "mar";

                case 4:
                    return "apr";

                case 5:
                    return "may";

                case 6:
                    return "jun";

                case 7:
                    return "jul";

                case 8:
                    return "aug";

                case 9:
                    return "sep";

                case 10:
                    return "oct";

                case 11:
                    return "nov";

                case 12:
                    return "dec";

                default:
                    return String.Empty;
            }
        }
    }
}