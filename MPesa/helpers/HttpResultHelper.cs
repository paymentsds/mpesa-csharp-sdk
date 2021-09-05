using System;
using System.Net.Http;
using System.Threading.Tasks;
using MPesa.Internal;

namespace MPesa.helpers
{
    public static class HttpResultHelper
    {
        public static async Task<HttpResponseMessage> GetHttpResult(HttpClient httpClient, int port, StringContent data)
        {
            httpClient.BaseAddress = new Uri($"https://api.sandbox.vm.co.mz:{port}");
            var result =  new HttpResponseMessage();
            switch (port)
            {
                case ConstantsHelper.PORT_C2B:
                    result = await httpClient.PostAsync($"/ipg/v1x/{ConstantsHelper.PATH_C2B}", data);
                break;
                case ConstantsHelper.PORT_B2B:
                    result = await httpClient.PostAsync($"/ipg/v1x/{ConstantsHelper.PATH_B2B}/", data);
                    break;
                case ConstantsHelper.PORT_B2C:
                    result = await httpClient.PostAsync($"/ipg/v1x/{ConstantsHelper.PATH_B2C}/", data);
                    break;
                case ConstantsHelper.PORT_QUERY: {
                    break;
                }
                case ConstantsHelper.PORT_REVERSAL: {
                    break;
                }
            }
            
            return result;
        }
    }
}