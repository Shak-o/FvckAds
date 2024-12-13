using System.Security.Cryptography;
using FvckAds.Domain.Auth;
using Npgsql;

namespace FvckAds.Persistence;

public class JwtHelper()
{
    public ECDsa GetKey(string connectionString)
    {
        using var sqlConnection = new NpgsqlConnection(connectionString);
        sqlConnection.Open();
        var query = @"SELECT * FROM ""Keys""";
        using var command = new NpgsqlCommand(query, sqlConnection);
        using var reader = command.ExecuteReader();
        var key = new Key
        {
            Id = 0,
            CreateDate = default,
            PrivateKey = [],
            PublicKey = []
        };
        while (reader.Read())
        {
            key.Id = reader.GetInt32(0);
            key.PrivateKey = (byte[])reader["PrivateKey"];
            key.PublicKey = (byte[])reader["PublicKey"];
        }
        var publicKey = ECDsa.Create();
        publicKey.ImportSubjectPublicKeyInfo(key.PublicKey, out _);
        return publicKey;
    }
}