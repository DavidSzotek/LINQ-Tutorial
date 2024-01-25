using TCPData;
using TCPExtensions;

/*
 * .Where is a pre-defined Extension method in LINQ
 */

internal class Program
{
    private static void Main(string[] args)
    {
       List<Employee> employees = Data.GetEmployees();

        var filteredEmployees = employees.Filter(emp => emp.AnnualSalary < 50000);

        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine($"First name: {employee.FirstName}");
            Console.WriteLine($"Last name: {employee.LastName}");
            Console.WriteLine($"Salary: {employee.AnnualSalary}");
            Console.WriteLine($"Is manager: {employee.IsManager}");
            Console.WriteLine();
        }

        List<Department> departments = Data.GetDepartments();

        var filteredDepartments = departments.Where(dept => dept.ShortName == "FN" || dept.ShortName == "HR");

        foreach (var department in filteredDepartments)
        {
            Console.WriteLine($"Short name: {department.ShortName}");
            Console.WriteLine($"Long name: {department.LongName}");
            Console.WriteLine();
        }

        List<Employee> employees2 = Data.GetEmployees();
        List<Department> departments2 = Data.GetDepartments();

        var joinedList = from emp in employees2
                         join dept in departments2
                         on emp.DepartmentId equals dept.Id
                         select new
                         {
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             AnnualSalary = emp.AnnualSalary,
                             Manager = emp.IsManager,
                             Department = dept.LongName
                         };

        var averageAnnualSalary = joinedList.Average(a => a.AnnualSalary);
        var highestAnnualSalary = joinedList.Max(a => a.AnnualSalary);
        var lowestAnnualSalary = joinedList.Min(a => a.AnnualSalary);

        Console.WriteLine($"Average Annual Salary: {averageAnnualSalary}");
        Console.WriteLine($"Highest Annual Salary: {highestAnnualSalary}");
        Console.WriteLine($"Lowest Annual Salary: {lowestAnnualSalary}");

        Console.ReadKey();
    }
}