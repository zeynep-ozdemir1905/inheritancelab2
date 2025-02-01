using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceLab2;

/*Author: Zeynep Ozdemir
 * Lab 2 Inheritance
 * Date: January 
 */

namespace InheritanceLab2
{
    public class Application
    {
        private List<Employee> Employees;

        // Constructor to initialize the employee list
        public Application(List<Employee> employees)
        {
            Employees = employees;
        }

        //Calculate average weekly pay
        public double CalculateAveragePay()
        {
            return Employees.Count > 0 ? Employees.Average(e => e.CalculatePay()) : 0.0;
        }

        //Get highest wage employee
        public Employee GetHighestWageEmployee()
        {
            return Employees.OfType<WageEmployee>().OrderByDescending(e => e.CalculatePay()).FirstOrDefault();
        }

        //Get lowest salaried employee
        public Employee GetLowestSalariedEmployee()
        {
            return Employees.OfType<SalariedEmployee>().OrderBy(e => e.CalculatePay()).FirstOrDefault();
        }

        //Display employee category percentages
        public void DisplayEmployeeCategoryPercentages()
        {
            int totalEmployees = Employees.Count;

            

            int salariedCount = Employees.Count(e => e is SalariedEmployee);
            int wageCount = Employees.Count(e => e is WageEmployee);
            int partTimeCount = Employees.Count(e => e is PartTimeEmployee);

            Console.WriteLine("\nEmployee Category Percentages:");
            Console.WriteLine($"Salaried Employees: {(salariedCount / (double)totalEmployees) * 100:F2}%");
            Console.WriteLine($"Wage Employees: {(wageCount / (double)totalEmployees) * 100:F2}%");
            Console.WriteLine($"Part-Time Employees: {(partTimeCount / (double)totalEmployees) * 100:F2}%");
        }

        // Print employee details
        public static void PrintEmployeeDetails(Employee employee)
        {
            if (employee != null)
            {
                Console.WriteLine("\nEmployee Details:");
                Console.WriteLine("--------------------------");
                Console.WriteLine(employee);
                Console.WriteLine($"Weekly Pay: {employee.CalculatePay():C}");
                Console.WriteLine("--------------------------");
            }
            
        }

        // Load employees from file
        public static List<Employee> LoadEmployees()
        {
            string filePath = "res/employees.txt";  
            var employees = new List<Employee>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return employees;
            }

            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(':');

               
                if (parts.Length == 8)
                {
                    string employeeId = parts[0];
                    string name = parts[1];
                    string address = parts[2];
                    string phone = parts[3];
                    long sin = long.Parse(parts[4]);
                    string dateOfBirth = parts[5];
                    string department = parts[6];
                    double rateOrSalary = double.Parse(parts[7]);

                    // Create and add the employee to the list
                    CreateEmployee(employees, employeeId, name, sin, address, phone, dateOfBirth, department, rateOrSalary);
                }
                
            }

            return employees;
        }

        // Create employee based on ID
        public static void CreateEmployee(
            List<Employee> employees,
            string employeeId,
            string name,
            long sin,
            string address,
            string phone,
            string dateOfBirth,
            string department,
            double rateOrSalary,
            double hoursWorked = 0.0
        )
        {
            if (employeeId.StartsWith("0") || employeeId.StartsWith("1") || employeeId.StartsWith("2") || employeeId.StartsWith("3") || employeeId.StartsWith("4"))
            {
                // Salaried Employee creation
                employees.Add(new SalariedEmployee(employeeId, name, sin, address, phone, dateOfBirth, department, rateOrSalary));
            }
            else if (employeeId.StartsWith("5") || employeeId.StartsWith("6") || employeeId.StartsWith("7"))
            {
                // Wage Employee creation
                employees.Add(new WageEmployee(employeeId, name, sin, address, phone, dateOfBirth, department, rateOrSalary, hoursWorked));
            }
            else if (employeeId.StartsWith("8") || employeeId.StartsWith("9"))
            {
                // Part-Time Employee creation
                employees.Add(new PartTimeEmployee(employeeId, name, sin, address, phone, dateOfBirth, department, rateOrSalary, hoursWorked));
            }
            else
            {
                Console.WriteLine($"Invalid employee ID format: {employeeId}");
            }
        }
    }
}
