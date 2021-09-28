using System;
using System.Threading.Tasks;
using MPesa;
using Environment = MPesa.Environment;

namespace Caller
{
    class Program
    {
        private static async Task Main(string[] args)
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
                .SecurityCredential("Mpesa2019")
                .Build();


            //C2B
            var paymentRequest = new Request.Builder()
                .Amount(10.0)
                .From("258840396628")
                .Reference("T12344ZL")
                .Transaction("T12344Q")
                .Build();
            
            try
            {
                var response = await client.Receive(paymentRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            //B2C (Change the 'To' Field to phone number) | B2B
            // var request = new Request.Builder()
            //     .Amount(10.0)
            //     .To("258840396628")
            //     .Reference("JKR37E")
            //     .Transaction("T12344C")
            //     .Build();
            //
            // var response = await client.Send(request);
            //
            // Console.WriteLine(response);
            
            //Reversal
            // var reversalRequest = new Request.Builder()
            //     .Amount(10.0)
            //     .Reference("T12344ZV")
            //     .Transaction("T12344Q")
            //     .Build();
            //
            // try
            // {
            //     var response = await client.Revert(reversalRequest);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
            
            //Query
            
            // var queryRequest = new Request.Builder()
            //     .Reference("T12344ZF")
            //     .Subject("12345")
            //     .Build();
            //
            //
            //
            // try
            // {
            //     var response = await client.Query(queryRequest);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
            
            //Query Customer Name
            // var queryCustomerNameRequest = new Request.Builder()
            //     .From("258840396628")
            //     .Reference("11114")
            //     .Build();
            //
            // try
            // {
            //     var response = await client.QueryCustomerName(queryCustomerNameRequest);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
            
            
            
        }
    }
}