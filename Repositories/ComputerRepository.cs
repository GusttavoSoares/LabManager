using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository // classe que fala com o banco de dados
{
    private DatabaseConfig databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig) => this.databaseConfig = databaseConfig;

    public List<Computer> GetAll()
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers;"; // atribuindo o texto a ser executado em command

        var reader = command.ExecuteReader(); // executa o texto informado anteriormente

        var computers = new List<Computer>();

        while (reader.Read()) // preenche uma lista de computadores
        {
            computers.Add(new Computer(
             reader.GetInt32(0),
             reader.GetString(1),
             reader.GetString(2)));
        }

        connection.Close();

        return computers;
    }

    public Computer GetById(int id)
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();

        command.Parameters.AddWithValue("@id", id);
        command.CommandText = "SELECT * FROM Computers  WHERE  (id LIKE  @id);";
        var reader = command.ExecuteReader(); // executa o texto informado anteriormente

        reader.Read();
        var computer = new Computer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

        connection.Close();

        return computer;
    }

    public Computer Update(Computer computer)
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();


        var command = connection.CreateCommand();

        command.CommandText = "UPDATE Computers SET  ram = $ram, processor = $processor WHERE id=$id;";
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);
        command.ExecuteNonQuery();

        connection.Close();
        return computer;
    }

    public Computer Save(Computer computer) // recebe os prametros de computer e salva
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor);";
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);
        command.ExecuteNonQuery();

        connection.Close();
        return computer;
    }

}

