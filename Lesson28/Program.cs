using System.Data;
using System.Data.SqlClient;
using Bogus;
using Dapper;

var windowsAuth = "Integrated Security=True;";
var sqlAuth = "User=sa;Password=sa/ics5603;";
var connectionString = $"Server=127.0.0.1;{sqlAuth}Database=newdb;";
var users = new List<User1>();
await CreateTable(connectionString);
// await DeleteSomeDataById(connectionString);
// await InsertViaDapper(connectionString);
// ReadUsersSqlClient(users, connectionString);
// await UseDapper(connectionString);
var users2 = users;

static async Task CreateTable(string conn)
{
    await using var connection = new SqlConnection(conn);
    await connection.ExecuteAsync("create table newtable1(Id int)");
    Console.WriteLine();
}

static async Task UseDapper(string conn)
{
    var someId = 3;
    await using var connection = new SqlConnection(conn);
    var users = (await connection
        .QueryAsync<User>(
            "select * from users where id=@userId",
            new {userId = someId})).ToList();
    var infos = (await connection
        .QueryAsync<DetailsInfo1>("select * from detailsinfo")).ToList();
    Console.WriteLine("");
}

static async Task InsertViaDapper(string conn)
{
    // generate some data
    var seed = new Faker<User>()
        .RuleFor(user => user.Id,
            faker => faker.IndexFaker + 1)
        .RuleFor(person => person.FirstName,
            faker => faker.Name.FirstName())
        .RuleFor(person => person.LastName,
            faker => faker.Name.LastName())
        .RuleFor(person => person.Info,
            faker => faker.Lorem.Paragraph());
    var users = seed.Generate(100);
    await using var connection = new SqlConnection(conn);
    foreach (var user in users)
    {
        connection.Execute("insert into Users values (@Id, @FirstName, @LastName, @Info)",
            new {user.Id, user.FirstName, user.LastName, user.Info});
    }

    Console.WriteLine("");
}

static async Task UpdateWithDapper(string conn)
{
    var someInfo = "info to be updated";
    var someUserId = 10;
    await using var connection = new SqlConnection(conn);
    await connection.ExecuteAsync(
        "update users set info=@someInfo where id=@someUserId",
        new {someInfo, someUserId});
}

static async Task DeleteSomeDataById(string conn)
{
    var someId = 11;
    await using var connection = new SqlConnection(conn);
    await connection.ExecuteAsync(
        "delete from users where id=@someId",
        new {someId});
}

static async Task GetJoinedData(string conn)
{
    await using var connection = new SqlConnection(conn);
    var users = (await connection
            .QueryAsync<JoinResult>(
                "select * from DetailsInfo di full outer join Users us on di.UserId = us.Id"))
        .ToList();
    Console.WriteLine();
}


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

public class User
{
    public int Id;
    public string FirstName;
    public string LastName;
    public string Info;
}

// public record User(int Id, string FirstName, string LastName, string Info);

public record JoinResult
{
    public JoinResult()
    {
    }

    public JoinResult(int InfoId, string Data, int UserId, string FirstName,
        int Id, string LastName, string Info)
    {
        this.InfoId = InfoId;
        this.Data = Data;
        this.UserId = UserId;
        this.FirstName = FirstName;
        this.Id = Id;
        this.LastName = LastName;
        this.Info = Info;
    }

    public int InfoId { get; init; }
    public string Data { get; init; }
    public int UserId { get; init; }
    public string FirstName { get; init; }
    public int Id { get; init; }
    public string LastName { get; init; }
    public string Info { get; init; }

    public void Deconstruct(out int InfoId, out string Data, out int UserId, out string FirstName, out int Id,
        out string LastName, out string Info)
    {
        InfoId = this.InfoId;
        Data = this.Data;
        UserId = this.UserId;
        FirstName = this.FirstName;
        Id = this.Id;
        LastName = this.LastName;
        Info = this.Info;
    }
}


public class DetailsInfo1
{
    public string Data { get; set; }
    public int UserId { get; set; }
    public int Id { get; set; }
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