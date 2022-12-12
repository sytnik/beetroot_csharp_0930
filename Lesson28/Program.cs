using System.Data;
using System.Data.SqlClient;

var windowsAuth = "Integrated Security=True;";
var sqlAuth = "User=sa;Password=sa/ics5603;";
var connectionString = $"Server=127.0.0.1;{sqlAuth}Database=newdb;";
var users = new List<User1>();

ReadUsersSqlClient(users, connectionString);
var users2 = users;

static void ReadUsersSqlClient(ICollection<User1> users, string conn)
{
    using var connection = new SqlConnection(conn);
    var command = new SqlCommand("select * from users", connection);
    connection.Open();
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        ParseSingleRow(users, reader);
    }

    reader.Close();
}

static void OutputSingleRow(IDataRecord dataRecord) =>
    Console.WriteLine($"{dataRecord[0]}, {dataRecord[1]}, " +
                      $"{dataRecord[2]}, {dataRecord[3]}");

static void ParseSingleRow(ICollection<User1> users, IDataRecord dataRecord)
{
    var user = new User1(dataRecord.GetInt32(0),
        dataRecord.GetString(1),
        dataRecord.IsDBNull(2) ? "-" : dataRecord.GetString(2),
        dataRecord.IsDBNull(3) ? "-" : dataRecord.GetString(3));
    users.Add(user);
    Console.WriteLine($"User: Id: {user.Id1}, FirstName: {user.FirstName1}, " +
                      $"LastName: {user.LastName1}, Info: {user.Info1}");
}

public class User1
{
    public int Id1 { get; set; }
    public string FirstName1 { get; set; }
    public string LastName1 { get; set; }
    public string Info1 { get; set; }

    public User1(int id, string firstName1, string lastName1, string info1)
    {
        Id1 = id;
        FirstName1 = firstName1;
        LastName1 = lastName1;
        Info1 = info1;
    }
}