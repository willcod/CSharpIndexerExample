using System.Collections.Generic;

namespace CSharpIndexerExample
{
    public class Company
    {
        private List<Department> _departments = new();

        public void AddDepartment(Department department) {
            _departments.Add(department);
        }
    }

    public class Department
    {
        public string Name { get; private set; }

        public Department(string name) {
            Name = name;
        }

        private List<Employee> _employees = new();

        public void AddEmployee(Employee employee) {
            _employees.Add(employee);
        }
    }

    public class Employee
    {
        public string Name { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(string name, decimal salary) {
            Name = name;
            Salary = salary;
        }
    }
}