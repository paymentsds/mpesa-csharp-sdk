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
        public bool IsSuccessfully { get; set; }

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
            ThirdPartyRef = thirdPartyRef;
            TransactionStatus = transactionStatus;
            IsSuccessfully = isSuccessfully;
        }

        // public static Response FromMpesaResponse(MpesaResponse mpesaResponse)
        // {
        //     return new Response(mpesaResponse.ConversationId, mpesaResponse.TransactionId, mpesaResponse.ResponseDesc,
        //         mpesaResponse.ResponseCode, mpesaResponse.ThirdPartyReference, mpesaResponse.ResponseTransactionStatus);
        // }
    }
}