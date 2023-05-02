

using Employees.Entities;
using System.Globalization;

Console.Write("Enter full file path: ");
string path = Console.ReadLine();

List<Employee> list = new List<Employee>();

using (StreamReader sr = File.OpenText(path))
{
    while (!sr.EndOfStream)
    {
        string[] fields = sr.ReadLine().Split(',');
        string name = fields[0];
        string email = fields[1];
        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
        list.Add(new Employee(name, email, salary));
    }
}

Console.Write("Enter salary: ");
double salaryParameter = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

var result = list.Where(e => e.Salary > salaryParameter).OrderBy(e => e.Email).Select(e => e.Email);

foreach(string name in result)
{
    Console.WriteLine(name);
}

Console.Write("Sum of salary of people whose name starts with 'M': ");

var result2 = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);

Console.Write(result2.ToString("F2", CultureInfo.InvariantCulture));



