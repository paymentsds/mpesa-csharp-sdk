using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
        
        
        // Constants
        private static int PORT_C2B = 18352;
        private static int PORT_B2B = 18349;
        private static int PORT_B2C = 18345;
        private static int PORT_QUERY = 18353;
        private static int PORT_REVERSAL = 18354;

        private static string PATH_C2B = "c2bPayment/singleStage/";
        private static string PATH_B2B = "b2bPayment/";
        private static string PATH_B2C = "b2cPayment/";
        private static string PATH_QUERY = "queryTransactionStatus/";
        private static string PATH_REVERSAL = "reversal/";

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
            

            var response = await GetHttpCall(request, PORT_C2B);

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
            var body = new
            {
                input_TransactionReference = request.Transaction,
                input_CustomerMSISDN = request.From,
                input_Amount = request.Amount,
                input_ThirdPartyReference = request.Reference,
                input_ServiceProviderCode = ServiceProviderCode
            };
            
            // var body = new
            // {
            //     input_TransactionReference = "T12344C",
            //     input_CustomerMSISDN = "258840396628",
            //     input_Amount = "10",
            //     input_ThirdPartyReference = "SJGW67f",
            //     input_ServiceProviderCode = "171717"
            // };

            var json = JsonSerializer.Serialize(body);
            
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            var http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("Authorization", $" Bearer {AuthorizationToken}");
            http.DefaultRequestHeaders.Add("Origin", "developer.mpesa.vm.co.mz");
            http.BaseAddress = new Uri("https://api.sandbox.vm.co.mz:18352");
            var result = await http.PostAsync("/ipg/v1x/c2bPayment/singleStage/", data);
            Console.WriteLine(result);
            
            return result;
            //PORTA
            //METODO
            //PATH
            
        }
        
    }
}