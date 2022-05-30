﻿using LabManager.Database;
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

    }

    if (modelAction == "Show"){
        int id = Convert.ToInt32(args[2]);
        Console.WriteLine(computerRepository.GetById(id).Id);
        Console.WriteLine(computerRepository.GetById(id).Ram);
        Console.WriteLine(computerRepository.GetById(id).Processor);
    }
}


