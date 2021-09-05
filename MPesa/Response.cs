using MPesa.Internal;

namespace MPesa
{
    public class Response
    {
        public string ConversationId { get; }
        public string TransactionId { get; }
        public string Description { get; }
        public string Code { get; }
        public string ThirdPartyRef { get; }
        
        // Query Transaction
        public string TransactionStatus { get; }

        public Response(
            string conversationId,
            string transactionId,
            string description,
            string code,
            string thirdPartyRef,
            string transactionStatus
        )
        {
            ConversationId = conversationId;
            TransactionId = transactionId;
            Description = description;
            Code = code;
            ThirdPartyRef = thirdPartyRef;
            TransactionStatus = transactionStatus;
        }

        public static Response FromMpesaResponse(MpesaResponse mpesaResponse)
        {
            return new Response(mpesaResponse.ConversationId, mpesaResponse.TransactionId, mpesaResponse.ResponseDesc,
                mpesaResponse.ResponseCode, mpesaResponse.ThirdPartyReference, mpesaResponse.ResponseTransactionStatus);
        }
    }
}