namespace MPesa.interfaces
{
    public interface IRsaUtility
    {
        string GenerateAuthorizationToken(string publicKey, string apiKey);
    }
}