using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MPesa.@internal
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
            //AuthorizationToken = generateAuthorizationToken();
        }

        public async Task<Response> receive(Request request)
        {
            return null;
            // if (request.From == null)
            // {
            //     throw new ArgumentNullException(request.From, "Request must contain a 'from' field to receive money.");
            // }
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
        
    }
}