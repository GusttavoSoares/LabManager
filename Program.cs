using LabManager.Database;
using Microsoft.Data.Sqlite;
using LabManager.Repositories;

var databaseConfig = new DatabaseConfig();
new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);


// Routing
var modelName = args[0];
var modelAction = args[1];



if (modelName == "Computer")
{
    if (modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll()) // var = lista de computers
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }
    }

    if (modelAction == "New")
    {

        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);
        command.ExecuteNonQuery();

        connection.Close();
    }
}

if (modelName == "Lab")
{
    if (modelAction == "List")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Lab;";

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                "{0}, {1}, {2}, {3}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3)
            );
        }

        reader.Close();
        connection.Close();

    }

    if (modelAction == "New")
    {

        int id = Convert.ToInt32(args[2]);
        int number = Convert.ToInt32(args[3]);
        string name = args[4];
        string block = args[5];

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Lab VALUES($id, $number, $name, $block);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$number", number);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$block", block);
        command.ExecuteNonQuery();

        connection.Close();
    }

}
