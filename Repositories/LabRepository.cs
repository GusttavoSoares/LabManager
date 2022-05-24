using Dapper; 
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
        using var connection = new SqliteConnection(databaseConfig.ConnectionString); // está definindo um escopo no final do qual um objeto será descartado, dessa forma não precisa fechar a conexão
        connection.Open();
        return connection.Query<Lab>("SELECT * FROM Labs;").ToList(); // esse é o getall
    }

    public Lab Save(Lab lab) // recebe os prametros de computer e salva
    {
        using var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();
        connection.Execute("INSERT INTO Labs VALUES(@id, @number, @name, @block);", lab);
        return lab;
    }   
}