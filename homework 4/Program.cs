using System;

public abstract class Worker
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int WorkDay { get; set; }

   
    public Worker(string name, string position, int workDay)
    {
        Name = name;
        Position = position;
        WorkDay = workDay;
    }

    
    public abstract void FillWorkDay();

    
    public void Call()
    {
       
    }

    public void WriteCode()
    {
        
    }

    public void Relax()
    {
        
    }
}

public class Developer : Worker
{
    public Developer(string name, int workDay) : base(name, "Developer", workDay)
    {
     
    }

    public override void FillWorkDay()
    {
        
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }

}

public class Manager : Worker
{
    private Random random = new Random();
    public Manager(string name, int workDay) : base(name, "Meneger", workDay)
    {
    }

    public override void FillWorkDay()
    {
        int callsBeforeRelax = random.Next(1, 11);
        int callsAfterRelax = random.Next(1, 6);

        CallMultipleTimes(callsBeforeRelax);

        Relax();

        CallMultipleTimes(callsAfterRelax);
    }

    private void CallMultipleTimes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Call();
        }
    }

}


public class Team
{
    public string Name { get; private set; }
    private List<Worker> workers = new List<Worker>();

    public Team(string name)
    {
        Name = name;
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void PrintTeamInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        Console.WriteLine("Workers:");

        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name);
        }
    }

    public void PrintDetailedTeamInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        Console.WriteLine("Details about workers:");

        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write team`s name");
        string teamName = Console.ReadLine();
        Team team = new Team(teamName);

        while (true)
        {
            Console.WriteLine("Write worker`s name:");
            string input = Console.ReadLine();

            if (input.ToLower() == "done")
            {
                break;
            }

            Console.WriteLine("Write worker`s position (Developer or Manager):");
            string position = Console.ReadLine();

            Console.WriteLine("Write worker`s workday: ");
            int workDay = int.Parse(Console.ReadLine());

            Worker worker;

            if (position.ToLower() == "developer")
            {
                worker = new Developer(input, workDay);
            }
            else if (position.ToLower() == "manager")
            {
                worker = new Manager(input, workDay);
            }
            else
            {
                Console.WriteLine("Wrong position. Please enter 'Developer' or 'Manager'.");
                continue;
            }

            team.AddWorker(worker);
        }

        Console.WriteLine("Information about team:");
        team.PrintTeamInfo();

        Console.WriteLine("\nDetailed information about team:");
        team.PrintDetailedTeamInfo();
    }
}
