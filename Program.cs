using LabManager.Models;

Console.WriteLine("Hello, World!");

SystemContext context = new SystemContext();
context.Database.EnsureCreated();

Computer c1 = new Computer(1, "16gb", "i7");
context.Computers.Add(c1);
context.SaveChanges();

Computer c2 = new Computer(2, "2gb", "i3");
context.Computers.Add(c2);

Computer c3 = new Computer(3, "2gb", "i3");
context.Computers.Add(c3);
context.SaveChanges();

IEnumerable<Computer> computers = context.Computers;

foreach (var item in computers)
{
    Console.WriteLine($"{item.Id}, {item.Ram}, {item.Processor}");
}

Computer encontrado = context.Computers.Find(2);
Console.WriteLine($"{encontrado.Id}, {encontrado.Ram}, {encontrado.Processor}");

encontrado.Ram = "20GB";
encontrado.Processor = "amd";
context.Computers.Update(encontrado);
context.SaveChanges();

Console.WriteLine(context.Computers.Find(2));

context.Computers.Remove(encontrado);
context.SaveChanges();

computers = context.Computers;

foreach (var item in computers)
{
    Console.WriteLine($"{item.Id}, {item.Ram}, {item.Processor}");
}
