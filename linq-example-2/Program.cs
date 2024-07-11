using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace linq_example_2;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employeesList = Data.GetEmployees();
        List<Department> departmentsList = Data.GetDepartments();

        //// Equality Operator
        //// SequenceEqual
        // var interList1 = new List<int> { 1, 2, 3, 4, 5 };
        // var interList2 = new List<int> { 1, 2, 3, 4, 5 };
        // var boolSequnceEqual = interList1.SequenceEqual(interList2);
        // Console.WriteLine($"SequenceEqual: {boolSequnceEqual}");



        // // SequenceEqual does not work with complex types, unless use IEqualityComparer
        // var employeesListCompare = Data.GetEmployees();
        // // bool boolSE = employeesList.SequenceEqual(employeesListCompare);
        // bool boolSE = employeesList.SequenceEqual(employeesListCompare, new EmployeeComparer());
        // Console.WriteLine($"boolSE: {boolSE}");

        // // Concatenation Operator

        // List<int> integerList1 = new List<int> { 1, 2, 3, 4, };
        // List<int> integerList2 = new List<int> { 5, 6, 7, 8, 9, 10 };

        // IEnumerable<int> integerListConcat = integerList1.Concat(integerList2);

        // foreach (var item in integerListConcat)
        // {
        //     Console.WriteLine(item);
        // }

        // List<Employee> employeesList2 = new List<Employee> {
        //     new Employee { Id = 1, FirstName = "Bob", LastName = "Jones", AnnualSalary = 60000.3m, IsManager = true, DepartmentId = 1 },
        //     new Employee { Id = 2, FirstName = "Sarah", LastName = "Jameson", AnnualSalary = 80000.1m, IsManager = true, DepartmentId = 3 },
        //     new Employee { Id = 3, FirstName = "Douglas", LastName = "Roberts", AnnualSalary = 40000.2m, IsManager = false, DepartmentId = 1 },
        //     new Employee { Id = 4, FirstName = "Jane", LastName = "Stevens", AnnualSalary = 30000.2m, IsManager = false, DepartmentId = 3 }
        // };
        // IEnumerable<Employee> employeesListConcat = employeesList.Concat(employeesList2);
        // foreach (var item in employeesListConcat)
        // {
        //     Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");
        // }

        // Aggregation Operator
        // decimal totalAnnualSalary = employeesList.Aggregate<Employee, decimal>(0, (total, employee) => 
        // {
        //     var bonus = employee.IsManager ? 0.04m : 0.02m;
        //     total += employee.AnnualSalary + (employee.AnnualSalary * bonus);
        //     return total; 
        // });

        // Console.WriteLine($"Total Annual Salary (including bonus): {totalAnnualSalary}");
        // string data = employeesList.Aggregate<Employee, string, string>("Employee Annual Salaries (including bonus)", (total, employee) =>
        // {
        //     var bonus = employee.IsManager ? 0.04m : 0.02m;
        //     total += $"{employee.Id} {employee.FirstName} {employee.LastName} - {employee.AnnualSalary + (employee.AnnualSalary * bonus)}\n";
        //     return total;
        // }, s=>s.Substring(0, s.Length-2));

        // Console.WriteLine(data);

        // Average Operator
        // decimal averageAnnualSalary = employeesList.Where(d => d.DepartmentId == 3).Average(employee => employee.AnnualSalary);
        // Console.WriteLine($"Average Annual Salary: {averageAnnualSalary}");

        // count operator
        // int count = employeesList.Count();
        // int count = employeesList.Count(e => e.DepartmentId == 3);
        // Console.WriteLine($"Count: {count}");

        // sum operator
        // decimal sum = employeesList.Sum(e => e.AnnualSalary);
        // Console.WriteLine($"Sum: {sum}");

        // max operator
        // decimal max = employeesList.Max(e => e.AnnualSalary);
        // Console.WriteLine($"Max: {max}");

        // Generation Operator - DefaultIfEmpty, Empty, Range, Repeat
        // DefaultIfEmpty
        // List<int> intList = new List<int>();
        // var newList = intList.DefaultIfEmpty(0);
        // List<Employee> employees = new List<Employee>();
        // var newList = employees.DefaultIfEmpty(new Employee { Id = 0, FirstName = "No Employee", LastName = "No Employee", AnnualSalary = 0, IsManager = false, DepartmentId = 0 });
        // var result = newList.ElementAt(0);

        // Console.WriteLine($"{result.Id} {result.FirstName} {result.LastName}");

        // Empty
        // List<Employee> emptyEmployees = Enumerable.Empty<Employee>().ToList();
        // emptyEmployees.Add(new Employee { Id = 1, FirstName = "Bob", LastName = "Jones", AnnualSalary = 60000.3m, IsManager = true, DepartmentId = 1 });

        // foreach (var item in emptyEmployees)
        // {
        //     Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");
        // }

        // Range
        // var range = Enumerable.Range(25, 20);
        // foreach (var item in range)
        // {
        //     Console.WriteLine(item);
        // }

        // Repeat Operator
        // var strCollection = Enumerable.Repeat<string>("Hello World", 5);
        // foreach (var item in strCollection)
        // {
        //     Console.WriteLine(item);
        // }

        // Set Operator - Distinct, Except, Intersect, Union
        // Distinct
        // var distinctDepartments = employeesList.Select(e => e.DepartmentId).Distinct();
        // foreach (var item in distinctDepartments)
        // {
        //     Console.WriteLine(item);
        // }

        // Except
        // IEnumerable<int> collection1 = new List<int> { 1, 2, 3, 4, 5 };
        // IEnumerable<int> collection2 = new List<int> { 3, 4, 5, 6, 7 };
        // var exceptCollection = collection1.Except(collection2);
        // foreach (var item in exceptCollection)
        // {
        //     Console.WriteLine(item);
        // }
        var employeesList2 = new List<Employee> {
            new Employee { Id = 1, FirstName = "Bob", LastName = "Jones", AnnualSalary = 60000.3m, IsManager = true, DepartmentId = 1 },
            new Employee { Id = 2, FirstName = "Sarah", LastName = "Jameson", AnnualSalary = 80000.1m, IsManager = true, DepartmentId = 3 },
            new Employee { Id = 3, FirstName = "Douglas", LastName = "Roberts", AnnualSalary = 40000.2m, IsManager = false, DepartmentId = 1 },
            new Employee { Id = 9, FirstName = "Jane", LastName = "Stevens", AnnualSalary = 30000.2m, IsManager = false, DepartmentId = 3 }
        };
        var result = employeesList.Except(employeesList2, new EmployeeComparer());
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");
        }


        Console.ReadLine();

    }
}


public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals([AllowNull] Employee x, [AllowNull] Employee y)
    {
        if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower())
        {
            return true;
        };
        return false;
    }

    public int GetHashCode([DisallowNull] Employee obj)
    {
        return obj.Id.GetHashCode();
    }
}

public record EmployeeR
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
}

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }
}

public static class Data
{
    public static ArrayList GetHeterogeneousDataCollection()
    {
        ArrayList arrayList = new ArrayList();

        arrayList.Add(100);
        arrayList.Add("Bob Jones");
        arrayList.Add(2000);
        arrayList.Add(3000);
        arrayList.Add("Bill Henderson");
        arrayList.Add(new Employee { Id = 6, FirstName = "Jennifer", LastName = "Dale", AnnualSalary = 90000, IsManager = true, DepartmentId = 1 });
        arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2 });
        arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
        arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" });
        arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });

        return arrayList;
    }

    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "Bob",
            LastName = "Jones",
            AnnualSalary = 60000.3m,
            IsManager = true,
            DepartmentId = 1
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 2,
            FirstName = "Sarah",
            LastName = "Jameson",
            AnnualSalary = 80000.1m,
            IsManager = true,
            DepartmentId = 3
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 40000.2m,
            IsManager = false,
            DepartmentId = 1
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 4,
            FirstName = "Jane",
            LastName = "Stevens",
            AnnualSalary = 30000.2m,
            IsManager = false,
            DepartmentId = 3
        };
        employees.Add(employee);

        return employees;
    }

    public static List<Department> GetDepartments()
    {
        List<Department> departments = new List<Department>();

        Department department = new Department
        {
            Id = 1,
            ShortName = "HR",
            LongName = "Human Resources"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 2,
            ShortName = "FN",
            LongName = "Finance"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 3,
            ShortName = "TE",
            LongName = "Technology"
        };
        departments.Add(department);

        return departments;
    }

}

