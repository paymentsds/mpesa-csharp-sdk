using System;
using System.Security.Cryptography;
using System.Text;

namespace MPesa.helpers
{
    public class RsaUtility
    {
        public static string RsaEncrypt(string apiKey, string publicKey)
        {
            try
            {
                using var rsa = new RSACryptoServiceProvider();

                var rsaKeyInfo = rsa.ExportParameters(false);
                var encodedPublicKey = Encoding.Default.GetBytes(publicKey);
                rsaKeyInfo.Modulus = encodedPublicKey;
                rsa.ImportParameters(rsaKeyInfo);
                var encrypt = rsa.Encrypt(Encoding.UTF8.GetBytes(apiKey), false);
                return Convert.ToBase64String(encrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public static string Example(string apiKey, string publicKey)
        {
            using var rsa = new RSACryptoServiceProvider(4096);
            var rsaKeyInfo = rsa.ExportParameters(false);
            var decodedPublicKey = Convert.FromBase64String(publicKey);
            rsaKeyInfo.Modulus = decodedPublicKey;
            rsa.ImportParameters(rsaKeyInfo);
            var bytesPlainTextData = Encoding.UTF8.GetBytes(apiKey);
            
            var encrypt = rsa.Decrypt(bytesPlainTextData, false);

            return Convert.ToBase64String(encrypt);
            
            
        }
    }
}