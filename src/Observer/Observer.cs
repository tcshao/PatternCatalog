using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCatalog
{
    public class Observer
    {
        public class Employee
        {
            public string Name { get; set; }
            public double Salary { get; private set; }
            public event EventHandler SalaryChanged;

            public void SetSalary(double salary)
            {
                Salary = salary;
                var handler = SalaryChanged;

                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }

        public class TaxMan
        {
            public void HandleSalaryChange(object sender, EventArgs args)
            {
                var emp = sender as Employee;
                Console.WriteLine("{0}'s salary has been changed to {1}", emp.Name, emp.Salary);
            }
        }

        public void Main()
        {
            var employee = new Employee();
            var irs = new TaxMan();

            employee.Name = "Florence";
            employee.SalaryChanged += irs.HandleSalaryChange;

            employee.SetSalary(45999.00);
        }
    }
}
