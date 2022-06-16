using LabManager.Database;
using Microsoft.Data.Sqlite;
using LabManager.Repositories;
using LabManager.Models;

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

        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
        Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
    }

    if (modelAction == "Show")
    {
        int id = Convert.ToInt32(args[2]);
        if (computerRepository.existsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }
        else
            Console.WriteLine($"O computador com id {id} não existe");
    }

    if (modelAction == "Update")
    {
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var computer = new Computer(id, ram, processor);
        if (computerRepository.existsById(id))
            computerRepository.Update(computer);
        else
            Console.WriteLine($"Comptador com {id} não encontrado");
    }

    if (modelAction == "Delete")
    {
        int id = Convert.ToInt32(args[2]);

        if (computerRepository.existsById(id))
        {
            computerRepository.Delete(id);
            Console.WriteLine($"Computador {id} deletado.");
        }
        else
            Console.WriteLine($"Comptador com {id} não encontrado");
    }
}


