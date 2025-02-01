using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Author: Zeynep Ozdemir
 * Lab 2 Inheritance
 * Date: January 
 */

namespace InheritanceLab2
{
    // Base class for employees
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public long SIN { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string Department { get; set; }

        // Constructor
        public Employee(string employeeId, string fullName, long sin, string address, string phone, string dateOfBirth, string department)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            SIN = sin;
            Phone = phone;
            Address = address;
            DateOfBirth = dateOfBirth;
            Department = department;
        }

        // base class 
        public virtual double CalculatePay()
        {
            return 0.0;  // No pay logic in base class
        }

        // Employee details string
        public override string ToString()
        {
            return $"ID: {EmployeeId}\nName: {FullName}\nSIN: {SIN}\nDepartment: {Department}\nDate of Birth: {DateOfBirth}";
        }
    }

    // Salaried employee class
    public class SalariedEmployee : Employee
    {
        public double WeeklySalary { get; set; }

        // Constructor
        public SalariedEmployee(
            string employeeId,
            string fullName,
            long sin,
            string address,
            string phone,
            string dateOfBirth,
            string department,
            double weeklySalary
        ) : base(employeeId, fullName, sin, address, phone, dateOfBirth, department)
        {
            WeeklySalary = weeklySalary;
        }

        // Salaried employees
        public override double CalculatePay()
        {
            return WeeklySalary;
        }

        
        public override string ToString()
        {
            return base.ToString() + $"\nPosition: Salaried Employee\nWeekly Salary: {WeeklySalary:C}";
        }
    }

    // Wage employee class
    public class WageEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        // Constructor
        public WageEmployee(
            string employeeId,
            string fullName,
            long sin,
            string address,
            string phone,
            string dateOfBirth,
            string department,
            double hourlyRate,
            double hoursWorked
        ) : base(employeeId, fullName, sin, address, phone, dateOfBirth, department)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Wage employees overtime
        public override double CalculatePay()
        {
            const double overtimeRate = 1.5;
            double overtimeHours = Math.Max(0, HoursWorked - 40);
            double regularHours = Math.Min(HoursWorked, 40);

            return (regularHours * HourlyRate) + (overtimeHours * HourlyRate * overtimeRate);
        }

        // String representation
        public override string ToString()
        {
            return base.ToString() + $"\nPosition: Wage Employee\nHourly Rate: {HourlyRate:C}\nHours Worked: {HoursWorked}\nWeekly Pay: {CalculatePay():C}";
        }
    }

    // Part-time employee class
    public class PartTimeEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        // Constructor
        public PartTimeEmployee(
            string employeeId,
            string fullName,
            long sin,
            string address,
            string phone,
            string dateOfBirth,
            string department,
            double hourlyRate,
            double hoursWorked
        ) : base(employeeId, fullName, sin, address, phone, dateOfBirth, department)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

       
        public override double CalculatePay()
        {
            return HoursWorked * HourlyRate;
        }

        
        public override string ToString()
        {
            return base.ToString() + $"\nPosition: Part-Time Employee\nHourly Rate: {HourlyRate:C}\nHours Worked: {HoursWorked}\nWeekly Pay: {CalculatePay():C}";
        }
    }
}
