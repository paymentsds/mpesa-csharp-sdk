using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MPesa.helpers
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> GetHttpClient(Request request, string authorizationToken, 
            int port, string serviceProviderCode)
        {
            var body = new
            {
                input_TransactionReference = request.Transaction,
                input_CustomerMSISDN = request.From,
                input_Amount = request.Amount,
                input_ThirdPartyReference = request.Reference,
                input_ServiceProviderCode = serviceProviderCode
            };
            var json = JsonSerializer.Serialize(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var http = new HttpClient();


            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("Authorization", $" Bearer {authorizationToken}");
            http.DefaultRequestHeaders.Add("Origin", "developer.mpesa.vm.co.mz");
            /*
            http.BaseAddress = new Uri("https://api.sandbox.vm.co.mz:18352");
            var result = await http.PostAsync("/ipg/v1x/c2bPayment/singleStage/", data);
            */
            
            return await GetHttpResultHelper.GetHttpResult(http, port, data);

        }

       
    }

}
