using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MPesa;
using MPesa.security;
using Environment = MPesa.Environment;

namespace Caller
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string apiKey = "";
            const string publicKey =
                "MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEAmptSWqV7cGUUJJhUBxsMLonux24u+FoTlrb+4Kgc6092JIszmI1QUoMohaDDXSVueXx6IXwYGsjjWY32HGXj1iQhkALXfObJ4DqXn5h6E8y5/xQYNAyd5bpN5Z8r892B6toGzZQVB7qtebH4apDjmvTi5FGZVjVYxalyyQkj4uQbbRQjgCkubSi45Xl4CGtLqZztsKssWz3mcKncgTnq3DHGYYEYiKq0xIj100LGbnvNz20Sgqmw/cH+Bua4GJsWYLEqf/h/yiMgiBbxFxsnwZl0im5vXDlwKPw+QnO2fscDhxZFAwV06bgG0oEoWm9FnjMsfvwm0rUNYFlZ+TOtCEhmhtFp+Tsx9jPCuOd5h2emGdSKD8A6jtwhNa7oQ8RtLEEqwAn44orENa1ibOkxMiiiFpmmJkwgZPOG/zMCjXIrrhDWTDUOZaPx/lEQoInJoE2i43VN/HTGCCw8dKQAwg0jsEXau5ixD0GUothqvuX3B9taoeoFAIvUPEq35YulprMM7ThdKodSHvhnwKG82dCsodRwY428kg2xM/UjiTENog4B6zzZfPhMxFlOSFX4MnrqkAS+8Jamhy1GgoHkEMrsT5+/ofjCx0HjKbT5NuA2V/lmzgJLl3jIERadLzuTYnKGWxVJcGLkWXlEPYLbiaKzbJb2sYxt+Kt5OxQqC1MCAwEAAQ==";

            var client = new Client.Builder()
                .ApiKey(apiKey)
                .PublicKey(publicKey)
                .ServiceProviderCode("171717")
                .InitiatorIdentifier("SJGW67fK")
                .Environment(Environment.Development)
                .Build();


            var paymentRequest = new Request.Builder()
                .Amount(10.0)
                .From("258842660175")
                .Reference("T12344U")
                .Transaction("T12344A")
                .Build();

            var response = client.Receive(paymentRequest);

               

            // var test = RsaUtility.Example(apiKey, publicKey);
            //var test = RsaUtility.RsaEncrypt(apiKey, publicKey);

            //var test = RsaUtility.GenerateAuthorizationToken(apiKey, publicKey);
            
            // var body = new
            // {
            //     input_TransactionReference = "T12344C",
            //     input_CustomerMSISDN = "258840396628",
            //     input_Amount = "10",
            //     input_ThirdPartyReference = "SJGW67f",
            //     input_ServiceProviderCode = "171717"
            // };
            //
            // var json = JsonSerializer.Serialize(body);
            //
            // var data = new StringContent(json, Encoding.UTF8, "application/json");
            //
            // var http = new HttpClient();
            //
            // http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // http.DefaultRequestHeaders.Add("Authorization", $" Bearer {test}");
            // http.DefaultRequestHeaders.Add("Origin", "developer.mpesa.vm.co.mz");
            // http.BaseAddress = new Uri("https://api.sandbox.vm.co.mz:18352");
            // var result = await http.PostAsync("/ipg/v1x/c2bPayment/singleStage/", data);
            
            Console.WriteLine("");
            Console.WriteLine("Token");
            Console.WriteLine("");
            //Console.WriteLine(test);
            Console.WriteLine("");
            Console.WriteLine("Result");
            //Console.WriteLine(result);
            Console.ReadKey();
            
            //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", test);
            //http.DefaultRequestHeaders.Host = "api.sandbox.vm.co.mz";
            //http.BaseAddress = new Uri("api.sandbox.vm.co.mz");

            //var response = await http.PostAsync("/api.sandbox.vm.co.mz/ipg/v1x/c2bPayment/singleStage:18352", data);
            
            // var request = new HttpRequestMessage() {
            //     RequestUri = new Uri("http://api.sandbox.vm.co.mz:18352/ipg/v1x/c2bPayment/singleStage/"),
            //     Method = HttpMethod.Post,
            //     Headers =
            //     {
            //         Authorization = new AuthenticationHeaderValue("Bearer", test),
            //         Host = "api.sandbox.vm.co.mz"
            //     },
            //     Content = new StringContent(json)
            // };
            // request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // http.DefaultRequestHeaders.Add("Origin", "developer.mpesa.vm.co.mz");
            // var task = await http.SendAsync(request);

        }
    }
}