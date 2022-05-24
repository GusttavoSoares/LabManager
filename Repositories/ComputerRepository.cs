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

    public void Save (Computer computer) // recebe os prametros de computer e salva
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
    }

}

