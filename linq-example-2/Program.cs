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

        // method syntax
        // var results = employeesList.Join(departmentsList, e => e.DepartmentId, d => d.Id, (emp, dept) => new
        // {
        //     Id = emp.Id,
        //     FirstName = emp.FirstName,
        //     LastName = emp.LastName,
        //     AnnualSalary = emp.AnnualSalary,
        //     DepartmentId = emp.DepartmentId,
        //     DepartmentName = dept.LongName,
        // }).OrderBy(o => o.DepartmentId).ThenBy(o => o.AnnualSalary);

        // query syntax
        // var results = from e in employeesList
        //              join d in departmentsList on e.DepartmentId equals d.Id
        //              orderby e.DepartmentId, e.AnnualSalary
        //              select new
        //              {
        //                  Id = e.Id,
        //                  FirstName = e.FirstName,
        //                  LastName = e.LastName,
        //                  AnnualSalary = e.AnnualSalary,
        //                  DepartmentId = e.DepartmentId,
        //                  DepartmentName = d.LongName
        //              };

        // foreach (var result in results)
        // {
        //     Console.WriteLine($"Id: {result.Id}, FirstName: {result.FirstName}, LastName: {result.LastName}, AnnualSalary: {result.AnnualSalary}, DepartmentId: {result.DepartmentId}, DepartmentName: {result.DepartmentName}");
        // }

        // group by operations - deferred execution
        // var groupResults = from e in employeesList
        //                    orderby e.DepartmentId descending
        //                    group e by e.DepartmentId;
        // foreach (var empGroup in groupResults)
        // {
        //     Console.WriteLine($"DepartmentId: {empGroup.Key}");
        //     foreach (var employee in empGroup)
        //     {
        //         Console.WriteLine($"Id: {employee.Id}, FirstName: {employee.FirstName}, LastName: {employee.LastName}, AnnualSalary: {employee.AnnualSalary}, DepartmentId: {employee.DepartmentId}");
        //     }
        // }

        // ToLookup Operator - immidiate execution
        // var groupResults = employeesList.OrderBy(o=>o.DepartmentId).ToLookup(e=>e.DepartmentId);
        // foreach (var empGroup in groupResults)
        // {
        //     Console.WriteLine($"DepartmentId: {empGroup.Key}");
        //     foreach (var employee in empGroup)
        //     {
        //         Console.WriteLine($"Id: {employee.Id}, FirstName: {employee.FirstName}, LastName: {employee.LastName}, AnnualSalary: {employee.AnnualSalary}, DepartmentId: {employee.DepartmentId}");
        //     }
        // }

        // All, Any, Contains Quantifier Operators
        // All and Any Operators
        // var annualSalaryCompare = 20000;
        // bool isTrueAll = employeesList.All(e => e.AnnualSalary > annualSalaryCompare);

        // if(isTrueAll){
        //     Console.WriteLine($"All employees have annual salary greater than {annualSalaryCompare}");
        // }else{
        //     Console.WriteLine($"Not all employees have annual salary are above {annualSalaryCompare}");
        // }

        // bool isTrueAny = employeesList.Any(e => e.AnnualSalary > annualSalaryCompare);
        // if(isTrueAny){
        //     Console.WriteLine($"At least one employee has annual salary greater than {annualSalaryCompare}");
        // }else{           
        //     Console.WriteLine($"No employee has annual salary greater than {annualSalaryCompare}");
        // };


        // Contains Operator
        var searchEmployee = new Employee
        {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 40000.2m,
            IsManager = false,
            DepartmentId = 1
        };
        bool containsEmployee = employeesList.Contains(searchEmployee, new EmployeeComparer());


        // Using Record Type
        // EmployeeR searchEmployeeR = new EmployeeR
        // {
        //     Id = 3,
        //     FirstName = "Douglas",
        //     LastName = "Roberts",
        //     AnnualSalary = 40000.2m,
        //     IsManager = false,
        //     DepartmentId = 1
        // };

        // EmployeeR searchEmployeeR1 = new EmployeeR
        // {
        //     Id = 3,
        //     FirstName = "Douglas",
        //     LastName = "Roberts",
        //     AnnualSalary = 40000.2m,
        //     IsManager = false,
        //     DepartmentId = 1
        // };

        // List<EmployeeR> employeesListR = new List<EmployeeR>();
        // employeesListR.Add(searchEmployeeR);
        // bool containsEmployeeR = employeesListR.Contains(searchEmployeeR1);

        // if (containsEmployee)
        //     Console.WriteLine($"Employee found in the list");
        // else
        //     Console.WriteLine($"Employee not found in the list");


        //OfType filter Operator
        // ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

        // var stringResult = from s in mixedCollection.OfType<string>()
        //                    select s;
        // foreach (var item in stringResult)
        //     Console.WriteLine(item);

        // var intResult = from i in mixedCollection.OfType<int>()
        //                 select i;
        // foreach (var item in intResult)
        //     Console.WriteLine(item);

        // var employeeResults = from e in mixedCollection.OfType<Employee>()
        //                       select e;
        // foreach (var item in employeeResults)
        //     Console.WriteLine(item);

        // var departmentResults = from d in mixedCollection.OfType<Department>()
        //                         select d;
        // foreach (var dept in departmentResults)
        //     Console.WriteLine($"{dept.Id,-5} {dept.LongName,-30} {dept.ShortName,-10}");

        var emp = employeesList.ElementAt(1);

        Console.WriteLine($"{emp.Id} {emp.FirstName} {emp.LastName} {emp.AnnualSalary} {emp.IsManager} {emp.DepartmentId}");

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

