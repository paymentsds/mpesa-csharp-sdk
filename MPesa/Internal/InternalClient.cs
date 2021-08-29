using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MPesa.helpers;
using MPesa.security;

namespace MPesa.Internal
{
    public class InternalClient
    {
        private string ApiKey { get; set; }
        private string PublicKey { get; set; }

        private string ServiceProviderCode { get; set; }
        private string InitiatorIdentifier { get; set; }
        private string Host { get; set; }
        private string SecurityCredential { get; set; }
        private string AuthorizationToken { get; set; }
  
        public InternalClient(string apiKey, string publicKey, string serviceProviderCode, string initiatorIdentifier,
            string host, string securityCredential)
        {
            ApiKey = apiKey;
            PublicKey = publicKey;
            ServiceProviderCode = serviceProviderCode;
            InitiatorIdentifier = initiatorIdentifier;
            Host = host;
            SecurityCredential = securityCredential;
            AuthorizationToken = RsaUtility.GenerateAuthorizationToken(publicKey, apiKey);
        }

        public async Task<Response> receive(Request request)
        {
            if (request.From == null)
            {
                throw new ArgumentNullException(request.From, "Request must contain a 'from' field to receive money.");
            }
            

            //var response = await GetHttpCall(request, PORT_C2B);
            var response = await GetHttpCall(request, ConstantsHelper.PORT_C2B);

            return null;
        } 
        
        public async Task<Response> send(Request request)
        {
            return null;
            // if (request.From == null)
            // {
            //     throw new ArgumentNullException(request.From, "Request must contain a 'from' field to receive money.");
            // }
        } 
        
        public async Task<Response> query(Request request)
        {
            return null;
            // if (request.From == null)
            // {
            //     throw new ArgumentNullException(request.From, "Request must contain a 'from' field to receive money.");
            // }
        }
        
        public async Task<Response> reversal(Request request)
        {
            return null;
            // if (request.From == null)
            // {
            //     throw new ArgumentNullException(request.From, "Request must contain a 'from' field to receive money.");
            // }
        }

        // private string generateAuthorizationToken()
        // {
        //     RSAParameters rsp = new RSAParameters
        //     {
        //         Modulus = "",
        //         Exponent = HexStringToByteArray("01000122")
        //     };
        // }

        public async Task<object> GetHttpCall(Request request, int port)
        {
          
            var result = await HttpClientHelper.GetHttpClient(request, AuthorizationToken, 
                ConstantsHelper.PORT_C2B, ServiceProviderCode);
            
            Console.WriteLine(result);
            
            return result;
            //PORTA
            //METODO
            //PATH
            
        }
        
    }
}