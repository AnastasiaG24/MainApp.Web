using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace eUseControl.Helpers
{
     public static class CookieGenerator
     {
          private const string SaltData = "OADLZ4qkrYq8BS5jGDF4JXWJ" +
                                          "qKqa0fXxeBPr7ThxWxmXDOER" +
                                          "PhlaLBv4nJrTGRwLg9tZbmV7g" +
                                          "8QUEAae6JPyv6eHY7s4HtBL4z4" +
                                          "fBGdh2NwS4akq9RczAEZAsuP5" +
                                          "cclsEfqc4pedSVVt74Z9CD7rw" +
                                          "iStnJWaa3j9a0WAnEtP5NvP+" +
                                          "EKHFnWtfCaWPxjpcbx8evdyq" +
                                          "UEauLvZLphmJLUteZ4QXUG" +
                                          "Z4F3PDhm3exQxvSCtQ8RhWwF";

          private static readonly byte[] Salt = Encoding.ASCII.GetBytes(SaltData);

          public static string Create(string value)
          {
               return EncryptStringAes(value, "BjXHm5MKKaralwzx9uATvFe4Ri967KgutrTRE8c2J56FnkukJKfK6bZeEDFDvsCYNHpUFXUUUuH8R4U7Jt2kmughubg6pc7rCyqGDbUPrWvPc67k3Xp");
          }

          public static string Validate(string value)
          {
               return DecryptStringAes(value, "BjXHm5MKKaralwzx9uATvFe4Ri967KgutrTRE8c2J56FnkukJKfK6bZeEDFDvsCYNHpUFXUUUuH8R4U7Jt2kmughubg6pc7rCyqGDbUPrWvPc67k3Xp");
          }

          public static string EncryptStringAes(string plainText, string keyString)
          {
               byte[] key = Encoding.UTF8.GetBytes(keyString.Substring(0, 32)); // AES-256 are nevoie de 32 bytes
               byte[] iv = Encoding.UTF8.GetBytes(keyString.Substring(0, 16));  // IV de 16 bytes pentru CBC

               using (var aes = Aes.Create())
               {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                         using (var sw = new StreamWriter(cs))
                         {
                              sw.Write(plainText);
                         }
                         return Convert.ToBase64String(ms.ToArray());
                    }
               }
          }

          public static string DecryptStringAes(string cipherText, string keyString)
          {
               byte[] key = Encoding.UTF8.GetBytes(keyString.Substring(0, 32));
               byte[] iv = Encoding.UTF8.GetBytes(keyString.Substring(0, 16));
               byte[] buffer = Convert.FromBase64String(cipherText);

               using (var aes = Aes.Create())
               {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream(buffer))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs))
                    {
                         return sr.ReadToEnd();
                    }
               }
          }
     }
}
