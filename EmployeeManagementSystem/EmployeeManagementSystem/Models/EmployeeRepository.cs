using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees;

        static EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee {EmployeeId=1, FirstName="Jenny", LastName="Jones", Phone = "888-888-8888", DepartmentId =1},
                new Employee {EmployeeId=2, FirstName="Bob", LastName="Ross", Phone = "555-555-5555", DepartmentId =2},
                new Employee {EmployeeId=3, FirstName="Jane", LastName="Smith", Phone = "111-111-1111", DepartmentId =3},                    
            };
        }
        public static List<Employee> GetAllEmployee()
        {
            return _employees;

        }
        public static void Add(Employee employee)
        {
            if(_employees.Any())
            {
                employee.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;
            }
            else
            {
                employee.EmployeeId = 1;
            }
            _employees.Add(employee);        
        }
        public static void Edit(Employee employee)
        {
            _employees.RemoveAll(e => e.EmployeeId == employee.EmployeeId);
            _employees.Add(employee);
            //Employee found = _employees.First(e => employee.EmployeeId == e.EmployeeId);
            //found = employee;
        }

        public static void Delete(int employeeId)
        {
            //Employee toRemove = _employees.First(e => e.EmplyeeId == employeeId);
            //_employees.Remove(toRemove);

            // this way is much faster 

            _employees.RemoveAll(e => e.EmployeeId == employeeId);
         
        }

        public static Employee GetEmployee(int employeeId)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }
    }
}