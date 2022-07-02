using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MPesa.Internal;

namespace MPesa.helpers
{
    public static class HttpClientHelper
    {
        //Make the Queries to MPesa API
        public static async Task<HttpResponseMessage> HttpClientCallAsync(Request request, string authorizationToken,
            int port, string serviceProviderCode, string securityCredential = "", string initiatorIdentifier = "")
        {
            var httpClient = BuildHttpClientHeader(authorizationToken, port);
            var result = new HttpResponseMessage();
            MpesaRequest mpesaRequest;
            HttpContent data;

            switch (port)
            {
                case ConstantsHelper.PORT_C2B:
                    mpesaRequest = MpesaRequest.FromC2BRequest(request, serviceProviderCode);
                    data = BuildStringContent(mpesaRequest);
                    result = await httpClient.PostAsync($"/ipg/v1x/{ConstantsHelper.PATH_C2B}", data);
                    break;

                case ConstantsHelper.PORT_B2B:
                    mpesaRequest = MpesaRequest.FromB2BRequest(request, serviceProviderCode);
                    data = BuildStringContent(mpesaRequest);
                    result = await httpClient.PostAsync($"/ipg/v1x/{ConstantsHelper.PATH_B2B}", data);
                    break;

                case ConstantsHelper.PORT_B2C:
                    mpesaRequest = MpesaRequest.FromB2CRequest(request, serviceProviderCode);
                    data = BuildStringContent(mpesaRequest);
                    result = await httpClient.PostAsync($"/ipg/v1x/{ConstantsHelper.PATH_B2C}", data);
                    break;

                case ConstantsHelper.PORT_QUERY:
                {
                    result = await httpClient.GetAsync(
                        $"/ipg/v1x/{ConstantsHelper.PATH_QUERY}?input_ThirdPartyReference={request.Reference}&input_QueryReference={request.Subject}&input_ServiceProviderCode={serviceProviderCode}");
                    break;
                }
                case ConstantsHelper.PORT_REVERSAL:
                {
                    mpesaRequest = MpesaRequest.FromReversalRequest(request, serviceProviderCode, securityCredential,
                        initiatorIdentifier);
                    data = BuildStringContent(mpesaRequest);
                    result = await httpClient.PutAsync($"/ipg/v1x/{ConstantsHelper.PATH_REVERSAL}", data);
                    break;
                }

                case ConstantsHelper.PORT_CUSTOMER_NAME:
                {
                    result = await httpClient.GetAsync(
                        $"/ipg/v1x/{ConstantsHelper.PATH_CUSTOMER_NAME}?input_CustomerMSISDN={request.From}&input_ThirdPartyReference={request.Reference}&input_ServiceProviderCode={serviceProviderCode}");
                    break;
                }
            }

            return result;
        }

        private static HttpClient BuildHttpClientHeader(string authorizationToken, int port)
        {
            var http = new HttpClient {BaseAddress = new Uri($"https://api.sandbox.vm.co.mz:{port}")};

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("Authorization", $" Bearer {authorizationToken}");
            http.DefaultRequestHeaders.Add("Origin", "developer.mpesa.vm.co.mz");

            return http;
        }

        //Serialize the String Content from the MPesa Request
        private static StringContent BuildStringContent(MpesaRequest mpesaRequest)
        {
            var json = JsonSerializer.Serialize(mpesaRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            return data;
        }

        //Deserialize the HttpResponseMessage to MPesaResponse
        public static async Task<MpesaResponse> DeserializeResponseMessage(HttpResponseMessage httpResponseMessage)
        {
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();

            var mpesaResponse = JsonSerializer.Deserialize<MpesaResponse>(readAsStringAsync);

            return mpesaResponse;
        }
    }
}