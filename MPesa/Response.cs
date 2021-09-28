using MPesa.Internal;

namespace MPesa
{
    public class Response
    {
        public string ConversationId { get; }
        public string TransactionId { get; }
        public string Description { get; }
        public string Code { get; }
        public bool IsSuccessfully { get;  }

        // Query Transaction
        public string TransactionStatus { get; }

        public Response(
            string conversationId,
            string transactionId,
            string description,
            string code,
            string thirdPartyRef,
            string transactionStatus,
            bool isSuccessfully
        )
        {
            ConversationId = conversationId;
            TransactionId = transactionId;
            Description = description;
            Code = code;
            TransactionStatus = transactionStatus;
            IsSuccessfully = isSuccessfully;
        }

        public static Response FromMpesaResponse(MpesaResponse mpesaResponse, bool isSuccessfully)
        {
            return new Response(mpesaResponse.ConversationId, mpesaResponse.TransactionId, mpesaResponse.ResponseDesc,
                mpesaResponse.ResponseCode, mpesaResponse.ThirdPartyReference, mpesaResponse.ResponseTransactionStatus,
                isSuccessfully);
        }
    }
}