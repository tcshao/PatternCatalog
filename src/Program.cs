using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var strat = new Strategy();

            strat.Main();

            var template = new Template.Headhunter();

            template.Process();

            var observer = new Observer();

            observer.Main();
        }
    }
}
