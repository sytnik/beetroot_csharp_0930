namespace Lesson34.Values;

public static class Settings
{
    public static string ConnectionString = new SqlConnectionStringBuilder
    {
        DataSource = "127.0.0.1", InitialCatalog = "newdb",
        IntegratedSecurity = true, TrustServerCertificate = true
    }.ConnectionString;

    public static JsonSerializerOptions SerializerOptions = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };

    public static string HostAddress = "https://localhost:443/";
    public static byte[] JwtKey = "3Bmhkh4pq2sGsy7W9amGNTEq"u8.ToArray();

}