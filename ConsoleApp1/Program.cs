//

using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        void chooseOption()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine($"{(int)Options.Add} - {Options.Add}");
            Console.WriteLine($"{(int)Options.Change} - {Options.Change}");
            Console.WriteLine($"{(int)Options.Print} - {Options.Print}");
            Console.WriteLine($"{(int)Options.Delete} - {Options.Delete}");
            switch (int.Parse(Console.ReadLine()))
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
                default:
                    throw new Exception("Incorrect option name");
            }
        }

        void changeOption()
        {
            Console.WriteLine("changeOption");
        }

        void printOption()
        {
            Console.WriteLine("printOption");
            Console.WriteLine("Enter name: ");
            Employee? result = searchEmployee(Console.ReadLine());
            if (result != null)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("There is no such employee");
            }
            //StreamReader streamReader = new("Employees.txt", true);
            //streamWriter.WriteLine(name + " " + birthDate + " " + job);
            //streamReader.Close();
        }

        void deleteOption()
        {
            Console.WriteLine("deleteOption");
        }

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
            //Console.WriteLine(File.Exists("Employees.txt"));
            //File.AppendAllText("C:\\Users\\User\\Documents\\test.txt", name + " " + birthDate + " " + (int)job);

            StreamWriter streamWriter = new("Employees.txt", true);
            //streamWriter.WriteLine(name + " " + birthDate + " " + job);
            streamWriter.WriteLine(new Employee(name, birthDate, job));
            streamWriter.Close();
        }

        chooseOption();

        Employee? searchEmployee(string inputName)
        {
            Employee?[] result = null;
            string[] allLines = File.ReadAllLines("Employees.txt");
            for (int i =0; i < allLines.Length; i++)
            {
                string[] tmp = allLines[i].Split(" ");
                result.Append(new Employee(tmp[0], tmp[1], Enum.Parse<Jobs>(tmp[2])));
            }
            for (int i=0; i < result.Length; i++)
            {
                if (result[i].Name == inputName)
                    return result[i];
            }

            return null;
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
            return Name + " " + Date + " " + Job;
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
    Add = 1,
    Change = 2,
    Print = 3,
    Delete =4
}

