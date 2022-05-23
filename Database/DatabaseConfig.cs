namespace LabManager.Database; // recurso que mostra onde essa classe está, separando o nome de outras classes

// Essa classe serve apenas para que não se repita o Data Source-database.db o tempo todo
class DatabaseConfig
{
    public string ConnectionString {get => "Data Source=database.db";}
}