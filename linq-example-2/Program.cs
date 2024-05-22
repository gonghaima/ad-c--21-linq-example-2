using System;
using System.Collections.Generic;

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

        var results = from e in employeesList
                     join d in departmentsList on e.DepartmentId equals d.Id
                     orderby e.DepartmentId, e.AnnualSalary
                     select new
                     {
                         Id = e.Id,
                         FirstName = e.FirstName,
                         LastName = e.LastName,
                         AnnualSalary = e.AnnualSalary,
                         DepartmentId = e.DepartmentId,
                         DepartmentName = d.LongName
                     };

        foreach (var result in results)
        {
            Console.WriteLine($"Id: {result.Id}, FirstName: {result.FirstName}, LastName: {result.LastName}, AnnualSalary: {result.AnnualSalary}, DepartmentId: {result.DepartmentId}, DepartmentName: {result.DepartmentName}");
        }
        Console.ReadLine();

    }
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
            DepartmentId = 2
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

