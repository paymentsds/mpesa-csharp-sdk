using System;
using System.Threading.Tasks;
using MPesa.Internal;

namespace MPesa
{
    public class Client
    {
        private InternalClient InternalClient { get; set; }

        private Client(string apiKey, string publicKey, string serviceProviderCode, string initiatorIdentifier,
            string host, string securityCredential)
        {
            InternalClient = new InternalClient(apiKey, publicKey, serviceProviderCode, initiatorIdentifier, host,
                securityCredential);
        }

        public async Task<Response> Receive(Request request)
        {
            return await InternalClient.Receive(request);
        }
        
        public async Task<Response> Send(Request request)
        {
            return await InternalClient.Send(request);
        }
        
        public async Task<Response> Query(Request request)
        {
            return await InternalClient.Query(request);
        }
        
        public async Task<Response> Revert(Request request)
        {
            return await InternalClient.Revert(request);
        }
        
        //To Validate
        public async Task<Response> QueryCustomerName(Request request)
        {
            return await InternalClient.QueryCustomerName(request);
        }

        public class Builder
        {
            private string ApiKeyValue { get; set; }
            private string PublicKeyValue { get; set; }

            private string ServiceProviderCodeValue { get; set; }
            private string InitiatorIdentifierValue { get; set; }
            private string HostValue { get; set; }
            private string SecurityCredentialValue { get; set; }

            public Builder ApiKey(string apiKey)
            {
                ApiKeyValue = apiKey;
                return this;
            }

            public Builder PublicKey(string publicKey)
            {
                PublicKeyValue = publicKey;
                return this;
            }

            public Builder ServiceProviderCode(string serviceProviderCode)
            {
                ServiceProviderCodeValue = serviceProviderCode;
                return this;
            }

            public Builder InitiatorIdentifier(string initiatorIdentifier)
            {
                InitiatorIdentifierValue = initiatorIdentifier;
                return this;
            }

            public Builder Environment(Environment environment)
            {
                HostValue = environment == MPesa.Environment.Development
                    ? "https://api.sandbox.vm.co.mz"
                    : "https://api.vm.co.mz";

                return this;
            }

            public Builder SecurityCredential(string securityCredential)
            {
                SecurityCredentialValue = securityCredential;
                return this;
            }

            public Client Build()
            {
                if (ApiKeyValue == null)
                {
                    throw new ArgumentNullException(ApiKeyValue, "Client must contain a ApiKey");
                }

                if (HostValue == null)
                {
                    throw new ArgumentNullException(HostValue, "Client must contain a ApiKey");
                }

                if (ServiceProviderCodeValue == null)
                {
                    throw new ArgumentNullException(ApiKeyValue, "Client must contain a ApiKey");
                }

                return new Client(ApiKeyValue, PublicKeyValue, ServiceProviderCodeValue, InitiatorIdentifierValue,
                    HostValue, SecurityCredentialValue);
            }
        }
    }
}