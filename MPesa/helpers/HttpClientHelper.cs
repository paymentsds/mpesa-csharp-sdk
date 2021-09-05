using System;
using System.ComponentModel;
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
        public static async Task<HttpResponseMessage> GetHttpClient(Request request, string authorizationToken, 
            int port, string serviceProviderCode)
        {
            var body = MpesaRequest.FromC2BRequest(request, serviceProviderCode);
           
            var json = JsonSerializer.Serialize(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var http = new HttpClient();


            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("Authorization", $" Bearer {authorizationToken}");
            http.DefaultRequestHeaders.Add("Origin", "developer.mpesa.vm.co.mz");

            return await HttpResultHelper.GetHttpResult(http, port, data);

        }

       
    }

}
