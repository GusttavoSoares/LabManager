using LabManager.Database;
using Microsoft.Data.Sqlite;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();
new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);
var labRepository = new LabRepository(databaseConfig);


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
        
        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);  

    }
}

if (modelName == "Lab")
{
    if (modelAction == "List")
    {
     Console.WriteLine ("Lab List");
     foreach (var lab in labRepository.GetAll())
     {
         var message = $"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}";
         Console.WriteLine(message);
     }
    } 

    if (modelAction == "New")
    {

    }

}
