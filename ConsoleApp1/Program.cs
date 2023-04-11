//

using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        string[] allLines = File.ReadAllLines("Employees.txt");
        for (int i = 0; i < allLines.Length; i++)
        {
            string[] tmp = allLines[i].Split(" ");
            employees.Add(new Employee(tmp[0], tmp[1], Enum.Parse<Jobs>(tmp[2])));
        }
        bool workOn = true;

        chooseOption();

        void addOption()
        {
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter birth date: ");
            var birthDate = Console.ReadLine();
            //regex или 

            Console.WriteLine("Enter job:");
            Console.WriteLine($"{(int)Jobs.Developer} - {Jobs.Developer}");
            Console.WriteLine($"{(int)Jobs.QA} - {Jobs.QA}");
            Console.WriteLine($"{(int)Jobs.PMO} - {Jobs.PMO}");
            Console.WriteLine($"{(int)Jobs.BA} - {Jobs.BA}");
            Console.WriteLine($"{(int)Jobs.HR} - {Jobs.HR}");
            int jobName = int.Parse(Console.ReadLine());
            Jobs job;

            switch (jobName)
            {
                case (int)Jobs.Developer:
                    job = Jobs.Developer;
                    break;
                case (int)Jobs.QA:
                    job = Jobs.QA;
                    break;
                case (int)Jobs.PMO:
                    job = Jobs.PMO;
                    break;
                case (int)Jobs.BA:
                    job = Jobs.BA;
                    break;
                case (int)Jobs.HR:
                    job = Jobs.HR;
                    break;
                default:
                    throw new Exception("Incorrect job name!");
            }
            employees.Add(new Employee(name, birthDate, job));
            Console.Write($"Added: {employees.Last()}");
        }

        void changeOption()
        {
            Console.WriteLine("changeOption");
            Console.WriteLine("Enter name: ");
            List<int> result = searchEmployee(Console.ReadLine());
            Console.WriteLine("Enter new position: ");
            Console.WriteLine($"{(int)Jobs.Developer} - {Jobs.Developer}");
            Console.WriteLine($"{(int)Jobs.QA} - {Jobs.QA}");
            Console.WriteLine($"{(int)Jobs.PMO} - {Jobs.PMO}");
            Console.WriteLine($"{(int)Jobs.BA} - {Jobs.BA}");
            Console.WriteLine($"{(int)Jobs.HR} - {Jobs.HR}");
            employees[result[0]].Job = Enum.Parse<Jobs>(Console.ReadLine());
            Console.Write($"Updated: {employees[result[0]]}");
        }

        void printOption()
        {
            Console.WriteLine("Enter name: ");
            List<int> result = searchEmployee(Console.ReadLine());
            for (int i=0; i < result.Count; i++)
            {
               Console.Write(employees[result[i]]);
            }
            if (result == null)
            {
                Console.WriteLine("There is no such employee");
            }
        }

        void deleteOption()
        {
            Console.WriteLine("Enter name: ");
            List<int> result = searchEmployee(Console.ReadLine());
            for (int i = result.Count - 1; i >= 0; i--)
            {
                Console.Write($"Deleted: {employees[result[i]]}");
                employees.RemoveAt(result[i]);
            }
            if (result.Count == 0)
            {
                Console.WriteLine("There is no such employee");
            }

        }

        void exitOption()
        {
            workOn = false;
            Console.WriteLine("Bye!");
            File.Delete("Employees.txt");
            foreach(Employee employee in employees)
            {
                File.AppendAllText("Employees.txt", employee.ToString());
            }
        }

        void chooseOption()
        {
            while (workOn)
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine($"{(int)Options.Add} - {Options.Add}");
                Console.WriteLine($"{(int)Options.Change} - {Options.Change}");
                Console.WriteLine($"{(int)Options.Print} - {Options.Print}");
                Console.WriteLine($"{(int)Options.Delete} - {Options.Delete}");
                Console.WriteLine($"{(int)Options.Exit} - {Options.Exit}");
                int answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case (int)Options.Add:
                        addOption();
                        break;
                    case (int)Options.Change:
                        changeOption();
                        break;
                    case (int)Options.Print:
                        printOption();
                        break;
                    case (int)Options.Delete:
                        deleteOption();
                        break;
                    case (int) Options.Exit:
                        exitOption();
                        break;
                    default:
                        throw new Exception("Incorrect option name");
                }
            }
        }

        List<int> searchEmployee(string inputName)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name == inputName)
                    result.Add(i);
            }
            return result;
        }
        string? enterName()
        {
            Console.WriteLine("Enter name: ");
            string? name = null;
            try {
                name = Console.ReadLine();
                if (name.All(char.IsLetter)){
                    throw new Exception("Incorrect name!");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            return name;
               
        }
    }

    public class Employee
    {
        private string name;
        private string date;
        private Jobs job;

        public Employee (string name, string date, Jobs job)
        {
            this.name = name;
            this.date = date;
            this.job = job;
        }

        public string Name
        {
            get { return name;}
            set { name = value;}
        }
        public string Date
        {
            get { return date;}
            set { date = value;}
        }
        public Jobs Job
        {
            get { return job;}
            set { job = value;}
        }

        public override string ToString()
        {
            return Name + " " + Date + " " + Job + "\n";
        }
    }
}

enum Jobs 
{
    Developer = 1,
    QA = 2,
    PMO = 3,
    BA = 4,
    HR = 5
}

enum Options
{
    Exit = 0,
    Add = 1,
    Change = 2,
    Print = 3,
    Delete =4
}

