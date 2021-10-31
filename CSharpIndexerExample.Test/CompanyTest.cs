using System;
using FluentAssertions;
using Xunit;

namespace CSharpIndexerExample.Test
{
    public class CompanyDataFixture : IDisposable
    {
        public Company Company { get; private set; }

        public CompanyDataFixture() {
            var softwareDepartment = new Department("Software");
            softwareDepartment.AddEmployee(new Employee("Alice", 15000));
            softwareDepartment.AddEmployee(new Employee("Bob", 12000));
            softwareDepartment.AddEmployee(new Employee("Carl", 14000));

            var salesDepartment = new Department("Sales");
            salesDepartment.AddEmployee(new Employee("Derek", 10000));
            salesDepartment.AddEmployee(new Employee("Eric", 9000));
            salesDepartment.AddEmployee(new Employee("Freya", 12000));

            Company = new Company();
            Company.AddDepartment(softwareDepartment);
            Company.AddDepartment(salesDepartment);
        }

        public void Dispose() {
        }
    }

    public class CompanyTest : IClassFixture<CompanyDataFixture>
    {
        private readonly CompanyDataFixture _fixture;

        public CompanyTest(CompanyDataFixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public void RetrieveValueShouldWork()
        {
            var company = _fixture.Company;

            var CarlSalary = company["Software"]["Carl"].Salary;
            CarlSalary.Should().Be(14000);

            var FreyaSalary = company["Sales"]["Freya"].Salary;
            FreyaSalary.Should().Be(12000);

        }
    }
}
