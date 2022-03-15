using System;
using System.Threading.Tasks;
using MPesa;
using Environment = MPesa.Environment;

namespace Example
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            const string apiKey = "";
            const string publicKey = "";

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
                .From("00258840340634")
                .Reference("T12344ZP")
                .Transaction("T12344Q")
                .Build();
            
            try
            {
                var response = await client.Receive(paymentRequest);
                if (response.IsSuccessfully)
                {
                    Console.WriteLine(response);
                }
                else
                {
                    throw new Exception(response.Description);
                }
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