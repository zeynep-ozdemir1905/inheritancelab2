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
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load employees from the file
            List<Employee> employees = Application.LoadEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees were found.");
                return;
            }

            
            var employeeService = new Application(employees);

            // Calculate and display the average weekly pay
            double averagePay = employeeService.CalculateAveragePay();
            Console.WriteLine($"Average Weekly Pay: {averagePay:C}");

            // Find and display the highest wage employee's details
            Employee highestWageEmployee = employeeService.GetHighestWageEmployee();
            Console.WriteLine("\nHighest Wage Employee Details:");
            Application.PrintEmployeeDetails(highestWageEmployee);

            // Find and display the lowest salaried employee's details
            Employee lowestSalariedEmployee = employeeService.GetLowestSalariedEmployee();
            Console.WriteLine("\nLowest Salaried Employee Details:");
            Application.PrintEmployeeDetails(lowestSalariedEmployee);

            // Display employee category percentages
            employeeService.DisplayEmployeeCategoryPercentages();
        }
    }
}
