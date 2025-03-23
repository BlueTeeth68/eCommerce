namespace Application.Configurations;

public class AppConfiguration
{
    public string DatabaseConnection { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string FireBaseApiKey { get; set; } = string.Empty;
    public string FireBaseBucket { get; set; } = string.Empty;
    public string FireBaseAuthEmail { get; set; } = string.Empty;
    public string FireBaseAuthPassword { get; set; } = string.Empty;

    public AppConfiguration()
    {
    }

    public AppConfiguration(string databaseConnection, string key, string issuer, string audience,
        string fireBaseApiKey, string fireBaseBucket, string fireBaseAuthEmail, string fireBaseAuthPassword)
    {
        DatabaseConnection = databaseConnection;
        Key = key;
        Issuer = issuer;
        Audience = audience;
        FireBaseApiKey = fireBaseApiKey;
        FireBaseBucket = fireBaseBucket;
        FireBaseAuthEmail = fireBaseAuthEmail;
        FireBaseAuthPassword = fireBaseAuthPassword;
    }
}