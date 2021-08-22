using System;
using System.Security.Cryptography;
using System.Text;
using MPesa.interfaces;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace MPesa.security
{
    public static class RsaUtility
    {
        
        public static string GenerateAuthorizationToken(string publicKey, string apiKey)
        {
            try
            {
                var encodedPublicKey = Convert.FromBase64String(publicKey);       
                var asymmetricKeyParameter = PublicKeyFactory.CreateKey(encodedPublicKey);
                var rsaKeyParameters = (RsaKeyParameters) asymmetricKeyParameter;
                var cipher = CipherUtilities.GetCipher("RSA/NONE/PKCS1Padding");
                cipher.Init(true, rsaKeyParameters);
                var encodedApiKey = Encoding.UTF8.GetBytes(apiKey);
                var encryptedApikey = Convert.ToBase64String(cipher.DoFinal(encodedApiKey));
                
                return encryptedApikey;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}