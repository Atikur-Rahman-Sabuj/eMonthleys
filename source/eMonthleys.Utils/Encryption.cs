using System;
using System.IO;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;

namespace eMonthleys.Utils
{
    public class Encryption
    {
        #region Connection String Encryption

        //These constants are used to set up the encryption Key and Vector values.
        //Do not change these values unless you plan on regenerating all connection strings.
        private const int KEYBITLENGTH = 256;
        private const int ITERATIONS = 786;
        private const string SALTSTRING = "eMonthlySALT";
        private const string PASSWORDSTRING = "eMonthlyPASSWORD";

        public static string Encrypt(string clearText)
        {
            return Convert.ToBase64String(Transform(Encoding.Default.GetBytes(clearText), GetEncryptionEngine().CreateEncryptor()));
        }

        public static string Decrypt(string cipherText)
        {
            //if (cipherText.Equals("MDaGLSRuXmY82OFMuyBqTCdFD/W40DKOuHPGCCp2+BkTY8uFGQ2ektTqAEjuCbLkolWGQMrqI0uKP63wEEqR2ANCaf7Ey72f/w7zf1i8dhc="))
            //{
            //    return "Data Source=TIRINGBRING-PC\\SQLEXPRESS;Initial Catalog=emonthleysdb;Integrated Security=True;MultipleActiveResultSets=True";
            //}
            String value = Encoding.Default.GetString(Transform(Convert.FromBase64String(cipherText), GetEncryptionEngine().CreateDecryptor()));
            return value;
            //return Encoding.Default.GetString(Transform(Convert.FromBase64String(cipherText), GetEncryptionEngine().CreateDecryptor()));
            //return "Data Source=TIRINGBRING-PC\\SQLEXPRESS;Initial Catalog=emonthleysdb;Integrated Security=True;MultipleActiveResultSets=True";
            //return "Data Source=VPLANETWEB1\\SQLEXPRESS;Initial Catalog=emonthleysdb;Uid=emsk;Pwd=S@mad2014;MultipleActiveResultSets=True";
        }

        private static SymmetricAlgorithm GetEncryptionEngine()
        {
            SymmetricAlgorithm encryptEngine = new RijndaelManaged();
            encryptEngine.Mode = CipherMode.CBC;

            //switched to configurable above
            //encryptEngine.Key = Convert.FromBase64String("U1fknVDCPQWERTYGZfRqvAYCK7gFpUukYKOqsCuN8XU=");
            //encryptEngine.IV = Convert.FromBase64String("vEQWERTYRMrovjV+NXos5g==");

            encryptEngine.Padding = PaddingMode.Zeros;
            encryptEngine.Key = GetAlgorithmKeyOrVector("key");
            encryptEngine.IV = GetAlgorithmKeyOrVector("vector");

            return encryptEngine;
        }

        private static byte[] Transform(byte[] Source, ICryptoTransform Transformer)
        {
            MemoryStream stream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(stream, Transformer, CryptoStreamMode.Write);
            cryptoStream.Write(Source, 0, Source.Length);

            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return stream.ToArray();
        }

        private static byte[] GetAlgorithmKeyOrVector(string byteType)
        {
            SymmetricAlgorithm algorithm = Rijndael.Create();

            var salt = GetByteArrayFromString(SALTSTRING);
            int iterations = ITERATIONS;
            int keyBitLength = KEYBITLENGTH;

            var r = new Rfc2898DeriveBytes(PASSWORDSTRING, salt, iterations);

            if (byteType == "key")
                return r.GetBytes(keyBitLength / 8);
            else
                return r.GetBytes(algorithm.BlockSize / 8);
        }

        private static byte[] GetByteArrayFromString(string s)
        {
            if (s.Length > 0)
            {
                byte[] byteArray = new byte[s.Length];

                for (int i = 0; i < s.Length; i++)
                {
                    string part = s.Substring(i, 1);
                    char c = s[0];
                    int b = c;
                    byteArray[i] = (byte)b;
                }
                return byteArray;
            }
            else
                return null;
        }

        #endregion

        #region Password Encryption

        public static string EncryptPassword(string Email, string Password)
        {
            string encryptedPass = string.Empty;
            SHA256Managed hashedPass = new SHA256Managed();
            byte[] hashedbytes;
            UTF32Encoding passEncoder = new UTF32Encoding();

            hashedbytes = hashedPass.ComputeHash(passEncoder.GetBytes(Password + Email));
            encryptedPass = Convert.ToBase64String(hashedbytes);            
            return encryptedPass;
        }

        public static string GetRandomPassword()
        {
            string newPassword = string.Empty;
            newPassword = Membership.GeneratePassword(10, 2);
            return newPassword;
        }

        #endregion
    }
}
