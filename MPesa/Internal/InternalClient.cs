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

        public async Task<Response> Receive(Request request)
        {
            if (request.From == null)
            {
                throw new ArgumentNullException(request.From, "Request must contain a 'from' field to receive money.");
            }

            var httpResponseMessage = await HttpClientHelper.HttpClientCallAsync(request, AuthorizationToken,
                ConstantsHelper.PORT_C2B, ServiceProviderCode);

            var mpesaResponse = await HttpClientHelper.DeserializeResponseMessage(httpResponseMessage);

            return new Response(mpesaResponse.ConversationId, mpesaResponse.TransactionId, mpesaResponse.ResponseDesc,
                mpesaResponse.ResponseCode, mpesaResponse.ThirdPartyReference, mpesaResponse.ResponseTransactionStatus);
        }

        public async Task<Response> Send(Request request)
        {
            MpesaResponse mpesaResponse;

            if (request.To == null)
            {
                throw new ArgumentNullException(request.To, "Request must contain a 'to' field to send money.");
            }

            if (request.To.StartsWith("258") && request.To.Length == 12)
            {
                var httpResponseMessage = await HttpClientHelper.HttpClientCallAsync(request, AuthorizationToken,
                    ConstantsHelper.PORT_B2C, ServiceProviderCode);

                mpesaResponse = await HttpClientHelper.DeserializeResponseMessage(httpResponseMessage);
            }
            else
            {
                var httpResponseMessage = await HttpClientHelper.HttpClientCallAsync(request, AuthorizationToken,
                    ConstantsHelper.PORT_B2B, ServiceProviderCode);
                mpesaResponse = await HttpClientHelper.DeserializeResponseMessage(httpResponseMessage);
            }

            return new Response(mpesaResponse.ConversationId, mpesaResponse.TransactionId, mpesaResponse.ResponseDesc,
                mpesaResponse.ResponseCode, mpesaResponse.ThirdPartyReference, mpesaResponse.ResponseTransactionStatus);
        }

        public async Task<Response> Query(Request request)
        {
            var httpResponseMessage = await HttpClientHelper.HttpClientCallAsync(request, AuthorizationToken,
                ConstantsHelper.PORT_QUERY, ServiceProviderCode);

            var mpesaResponse = await HttpClientHelper.DeserializeResponseMessage(httpResponseMessage);
            
            return new Response(mpesaResponse.ConversationId, mpesaResponse.TransactionId, mpesaResponse.ResponseDesc,
                mpesaResponse.ResponseCode, mpesaResponse.ThirdPartyReference, mpesaResponse.ResponseTransactionStatus);
        }

        public async Task<Response> Revert(Request request)
        {
            if (SecurityCredential == null)
            {
                throw new ArgumentNullException(SecurityCredential,
                    "Client must contain a securityCredential to revert a transaction");
            }

            if (InitiatorIdentifier == null)
            {
                throw new ArgumentNullException(InitiatorIdentifier,
                    "Client must contain a initiatorIdentifier to revert a transaction");
            }

            var httpResponseMessage = await HttpClientHelper.HttpClientCallAsync(request, AuthorizationToken,
                ConstantsHelper.PORT_REVERSAL, ServiceProviderCode, SecurityCredential, InitiatorIdentifier);

            var mpesaResponse = await HttpClientHelper.DeserializeResponseMessage(httpResponseMessage);

            return new Response(mpesaResponse.ConversationId, mpesaResponse.TransactionId, mpesaResponse.ResponseDesc,
                mpesaResponse.ResponseCode, mpesaResponse.ThirdPartyReference, mpesaResponse.ResponseTransactionStatus);
        }
    }
}