using System.Data.Common;

Console.WriteLine("Hello Factory");

string conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true;TrustServerCertificate=true";
//string conString = "Server=.;Database=Northwind;Trusted_Connection=true;";
//DbProviderFactory factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
DbProviderFactory factory = FirebirdSql.Data.FirebirdClient.FirebirdClientFactory.Instance;

DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();
Console.WriteLine("Datenbankverbindung wurde hergestellt");

DbCommand dbCommand = factory.CreateCommand();
dbCommand.Connection = con;
dbCommand.CommandText = "SELECT COUNT(*) FROM Employees";

var count = (int)dbCommand?.ExecuteScalar();

Console.WriteLine($"{count} Employees in DB");



