using System.Text.Json.Serialization;

namespace MPesa.Internal
{
    public class MpesaRequest
    {
        [JsonPropertyName("input_TransactionReference")]
        public string TransactionReference { get; set; }
        [JsonPropertyName("input_amount")] 
        public string Amount { get; set; }
        [JsonPropertyName("input_ThirdPartyReference")] 
        public string ThirdPartyReference { get; set; }
        [JsonPropertyName("input_CustomerMSISDN")] 
        public string CustomerMsisdn { get; set; }
        [JsonPropertyName("input_ServiceProviderCode")] 
        public string ServiceProviderCode { get; set; }
        
        // B2B
        [JsonPropertyName("input_PrimaryPartyCode")]
        public string PrimaryPartyCode { get; set; }
        [JsonPropertyName("input_ReceiverPartyCode")]
        public string ReceiverPartyCode { get; set; }
        
        // Reversal
        [JsonPropertyName("input_ReversalAmount")]
        public string ReversalAmount { get; set; }
        [JsonPropertyName("input_InitiatorIdentifier")]
        public string InitiatorIdentifier { get; set; }
        [JsonPropertyName("input_SecurityCredential")]
        public string SecurityCredential { get; set; }
        [JsonPropertyName("input_TransactionID")]
        public string TransactionId { get; set; }

        private MpesaRequest() { }

        public static MpesaRequest FromC2BRequest(Request request, string serviceProviderCode)
        {
            var mpesaRequest = new MpesaRequest
            {
                Amount = request.Amount + "",
                TransactionReference = request.Transaction,
                ThirdPartyReference = request.Reference,
                CustomerMsisdn = request.From,
                ServiceProviderCode = serviceProviderCode
            };
            return mpesaRequest;
        }

        public static MpesaRequest FromB2CRequest(Request request, string serviceProviderCode)
        {
            var mpesaRequest = new MpesaRequest
            {
                Amount = request.Amount + "",
                TransactionReference = request.Transaction,
                ThirdPartyReference = request.Reference,
                CustomerMsisdn = request.To,
                ServiceProviderCode = serviceProviderCode
            };
            return mpesaRequest;
        }

        public static MpesaRequest FromB2BRequest(Request request, string primaryPartyCode)
        {
            var mpesaRequest = new MpesaRequest
            {
                Amount = request.Amount + "",
                TransactionReference = request.Transaction,
                ThirdPartyReference = request.Reference,
                PrimaryPartyCode = primaryPartyCode,
                ReceiverPartyCode = request.To
            };

            return mpesaRequest;
        }

        public static MpesaRequest FromReversalRequest(
            Request request, 
            string serviceProviderCode, 
            string securityCredential, 
            string initiatorIdentifier)
        {
            var mpesaRequest = new MpesaRequest
            {
                TransactionId = request.Transaction,
                SecurityCredential = securityCredential,
                InitiatorIdentifier = initiatorIdentifier,
                ThirdPartyReference = request.Reference,
                ServiceProviderCode = serviceProviderCode,
                ReversalAmount = request.Amount + ""
            };

            return mpesaRequest;
        }
    }
}