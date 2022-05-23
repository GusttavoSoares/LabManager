using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;
namespace LabManager.Repositories;

class LabRepository
{

    private DatabaseConfig databaseConfig;

    public LabRepository(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public List<Lab> GetAll()
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Labs;";

        var reader = command.ExecuteReader();

        var labs = new List<Lab>();

        while (reader.Read())
        {
            labs.Add(new Lab(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetString(2),
                reader.GetString(3)
            ));
        }

        connection.Close();
        return labs;

    }
}