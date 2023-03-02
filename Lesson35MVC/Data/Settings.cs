﻿using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;

namespace Lesson35MVC.Data;

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
}