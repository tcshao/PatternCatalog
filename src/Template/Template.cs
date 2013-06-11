using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCatalog
{
    class Template
    {
        public abstract class Workflow
        {
            public abstract void YouShouldDoThisFirst();
            public abstract void ThenYouShouldDoThis();
            public abstract void ThisWillBeDoneLast();

            // this is the 
            public void Process()
            {
                YouShouldDoThisFirst();
                ThenYouShouldDoThis();
                ThisWillBeDoneLast();
            }
        }

        public class Headhunter : Workflow
        {
            public override void YouShouldDoThisFirst()
            {
                Console.WriteLine("Lock the target");
            }

            public override void ThenYouShouldDoThis()
            {
                Console.WriteLine("Bait the line");
            }

            public override void ThisWillBeDoneLast()
            {
                Console.WriteLine("Spread the net");
            }
        }
    }
}
