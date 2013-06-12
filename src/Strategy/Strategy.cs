using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCatalog
{
    class Strategy
    {

        // Begin Traditional Implementation
        public interface IOperation
        {
            int Compute(int number);
        }

        public class Operation : IOperation
        {
            public int Compute(int number)
            {
                return number * 5;
            }
        }

        public class Calculator
        {
            public IOperation Operation { get; set; }

            public Calculator(IOperation operation)
            {
                Operation = operation;
            }

            public int Calculate(int number)
            {
                return Operation.Compute(number);
            }
        }
        // End Traditional Implementation

        // Begin Functional Implementation
        public class Calculator_v2
        {
            public Func<int, int> Compute { get; set; }

            public Calculator_v2(Func<int, int> computer)
            {
                Compute = computer;
            }

            public int Calculate(int number)
            {
                return Compute(number);
            }
        }
        // End Functional Implementation

        public void Main()
        {
            // Traditional
            var calculator = new Calculator(new Operation());
            Console.WriteLine(calculator.Calculate(3));

            // Functional

            var calculator2 = new Calculator_v2(number => number * 5);
            Console.WriteLine(calculator2.Calculate(3));

        }
    }
}
