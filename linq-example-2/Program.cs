﻿using System;
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

        List<Employee> employeesList2 = new List<Employee> {
            new Employee { Id = 1, FirstName = "Bob", LastName = "Jones", AnnualSalary = 60000.3m, IsManager = true, DepartmentId = 1 },
            new Employee { Id = 2, FirstName = "Sarah", LastName = "Jameson", AnnualSalary = 80000.1m, IsManager = true, DepartmentId = 3 },
            new Employee { Id = 3, FirstName = "Douglas", LastName = "Roberts", AnnualSalary = 40000.2m, IsManager = false, DepartmentId = 1 },
            new Employee { Id = 4, FirstName = "Jane", LastName = "Stevens", AnnualSalary = 30000.2m, IsManager = false, DepartmentId = 3 }
        };
        IEnumerable<Employee> employeesListConcat = employeesList.Concat(employeesList2);
        foreach (var item in employeesListConcat)
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

