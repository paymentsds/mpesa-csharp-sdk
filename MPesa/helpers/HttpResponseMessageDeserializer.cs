using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MPesa.Internal;

namespace MPesa.helpers
{
    public class HttpResponseMessageDeserializer
    {
        public static async Task<MpesaResponse> DeserializeMessage(HttpResponseMessage httpResponseMessage)
        {
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();

            var mpesaResponse = JsonSerializer.Deserialize<MpesaResponse>(readAsStringAsync);

            return mpesaResponse;
        }
    }
}