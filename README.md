# M-Pesa SDK for C#

M-Pesa SDK for C# is an unofficial library aiming to help developer businesses integrating every [M-Pesa](https://developer.mpesa.vm.co.mz) operations to their ASP.NET applications.

## Features

- Receive money from a mobile account to a business account
- Send money from a business account to a mobile account
- Send money from a business account to another business account
- Revert a transaction
- Query the status of a transaction

## Usage

### Receive Money from a Mobile Account
```
var client = new Client.Builder()
    .ApiKey("<REPLACE>")
    .PublicKey("<REPLACE>")
    .ServiceProviderCode("<REPLACE>")
    .InitiatorIdentifier("<REPLACE>")
    .Environment(Environment.Production)
    .Build();

var request = new Request.Builder()
    .Amount(10.0)
    .From("258841234567")
    .Reference("12345")
    .Transaction("12345")
    .Build();

//Async
    try
    {
        var response = await client.Receive(paymentRequest);
        if(response.IsSuccessfully) {
            //Handle Success Scenario
        }
    }
    catch (Exception e)
    {
        //Handle Exception Scenario
    }
``` 
    
### Send Money to a Mobile Account
```
var client = new Client.Builder()
    .ApiKey("<REPLACE>")
    .PublicKey("<REPLACE>")
    .ServiceProviderCode("<REPLACE>")
    .InitiatorIdentifier("<REPLACE>")
    .Environment(Environment.Production)
    .Build();

var request = new Request.Builder()
    .Amount(10.0)
    .To("258841234567")
    .Reference("12345")
    .Transaction("12345")
    .Build();

//Async
    try
    {
        var response = await client.send(paymentRequest);
        if(response.IsSuccessfully) {
            //Handle Success Scenario
        }
    }
    catch (Exception e)
    {
        //Handle Exception Scenario
    } 
    
```  
    
### Send Money to a Business Account

```
var client = new Client.Builder()
    .ApiKey("<REPLACE>")
    .PublicKey("<REPLACE>")
    .ServiceProviderCode("<REPLACE>")
    .InitiatorIdentifier("<REPLACE>")
    .Environment(Environment.Production)
    .Build();

var request = new Request.Builder()
    .Amount(10.0)
    .To("54321")
    .Reference("12345")
    .Transaction("12345")
    .Build();

//Async
    try
    {
        var response = await client.send(paymentRequest);
        if(response.IsSuccessfully) {
            //Handle Success Scenario
        }
    }
    catch (Exception e)
    {
        //Handle Exception Scenario
    }
``` 
    
### Revert a Transaction

```
var client = new Client.Builder()
    .ApiKey("<REPLACE>")
    .PublicKey("<REPLACE>")
    .ServiceProviderCode("<REPLACE>")
    .InitiatorIdentifier("<REPLACE>")
    .Environment(Environment.Production)
    .SecurityCredential("<REPLACE>")
    .Build();

var reversalRequest = new Request.Builder()
    .Amount(10.0)
    .Reference("12345")
    .Transaction("12345")
    .Build();

//Async
    try
    {
        var response = await client.revert(reversalRequest);
        if(response.IsSuccessfully) {
            //Handle Success Scenario
        }
    }
    catch (Exception e)
    {
        //Handle Exception Scenario
    }

```   
    
### Query the status of a Transaction

```
var client = new Client.Builder()
    .ApiKey("<REPLACE>")
    .PublicKey("<REPLACE>")
    .ServiceProviderCode("<REPLACE>")
    .Build();

var queryRequest = new Request.Builder()
    .Reference("12345")
    .Subject("12345")
    .Build();

//Async
    try
    {
        var response = await client.query(queryRequest);
        if(response.IsSuccessfully) {
            //Handle Success Scenario
        }
    }
    catch (Exception e)
    {
        //Handle Exception Scenario
    }

```
