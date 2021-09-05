using System.Text.Json.Serialization;

namespace MPesa.Internal
{
    public class MpesaResponse
    {
        [JsonPropertyName("output_ConversationID")]
        public string ConversationId { get; set; }
        [JsonPropertyName("output_TransactionID")]
        public string TransactionId { get; set; }
        [JsonPropertyName("output_ResponseDesc")]
        public string ResponseDesc { get; set; }
        [JsonPropertyName("output_ResponseCode")]
        public string ResponseCode { get; set; }
        [JsonPropertyName("output_ThirdPartyReference")]
        public string ThirdPartyReference { get; set; }
        
        // Query Transaction Status
        [JsonPropertyName("output_ResponseTransactionStatus")]
        public string ResponseTransactionStatus { get; set; }
        
    }
}