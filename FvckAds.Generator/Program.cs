using System.Security.Cryptography;
using Npgsql;


var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256); // Use the P-256 curve
var privateKey = ecdsa.ExportECPrivateKey();
var publicKey = ecdsa.ExportSubjectPublicKeyInfo();
using var sqlConnection = new NpgsqlConnection("Host=localhost;Port=9943;Username=postgres;Password=Qwerty1$;Database=UserDb");
sqlConnection.Open();
var insertQuery = "INSERT INTO \"Keys\" (\"PrivateKey\", \"PublicKey\") VALUES (@value1, @value2)";
using var command = new NpgsqlCommand(insertQuery, sqlConnection);
command.Parameters.AddWithValue("value1", privateKey);
command.Parameters.AddWithValue("value2", publicKey);
var rowsAffected = command.ExecuteNonQuery();
Console.WriteLine($"{rowsAffected} row(s) inserted.");