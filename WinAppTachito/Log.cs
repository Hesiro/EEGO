using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models;
using WinAppTachito.Views;

namespace WinAppTachito
{
    class Log
    {
        public static FormPrincipal StartAplication { set; get; }
        public static Usuario UsuarioSistema { get; set; }
        public static void FailRegister(string msgError)
        {
            StreamWriter sW;
            StreamReader sR;
            List<string> listMsg = new List<string>();
            string reading;
            string fileName = "ErrorSys.txt";

            if (!File.Exists(fileName))
            {
                sW = File.CreateText(fileName);
                sW.WriteLine(DateTime.Now.ToString() + " >> " + msgError);
                sW.WriteLine(">>");
                sW.WriteLine(">>");
                sW.WriteLine(">> HS");
                sW.Close();
            }
            else
            {
                sR = File.OpenText(fileName);
                reading = sR.ReadLine();
                while (reading != null)
                {
                    if (!reading.Equals(">>") && !reading.Equals(">> HS"))
                        listMsg.Add(reading);

                    reading = sR.ReadLine();
                }
                sR.Close();

                listMsg.Add(DateTime.Now.ToString() + " >> " + msgError);
                listMsg.Add(">>");
                listMsg.Add(">>");
                listMsg.Add(">> HS");

                File.WriteAllLines(fileName, listMsg.ToArray());

            }
        }
        public static string Encrypt(string source)
        {
            string key = "real";
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes(source);
                    return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }

        public static string Decrypt(string encrypt)
        {
            string key = "real";
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Convert.FromBase64String(encrypt);
                    return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }
    }
}
