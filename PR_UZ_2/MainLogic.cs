using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PR_UZ_2
{
    public class MainLogic
    {
            public static string Encrypt(string text, string key)
            {
                using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
                {
                    byte[] keys = Encoding.ASCII.GetBytes(key);
                    ICryptoTransform encryptor = provider.CreateEncryptor(keys, keys);
                    // Using the key as our initialization vector
                    // because I actually want to get back the text that's being encrypted
                    // :P
                    var ms = new MemoryStream();
                    var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                    byte[] input = Encoding.ASCII.GetBytes(text);
                    cs.Write(input, 0,input.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            
            public static string Decrypt(string text, string key)
            {
                byte[] encryptedTextBytes = Convert.FromBase64String(text);
                byte[] keyBytes = Encoding.ASCII.GetBytes(key);

                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                ICryptoTransform transform = provider.CreateDecryptor(keyBytes, keyBytes);
                CryptoStreamMode mode = CryptoStreamMode.Write;

                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, mode);
                cryptoStream.Write(encryptedTextBytes,0,encryptedTextBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] textBytes = new byte[memoryStream.Position];
                memoryStream.Position = 0;
                memoryStream.Read(textBytes, 0, textBytes.Length);
            
                return Encoding.ASCII.GetString(textBytes);
            }
    }
}