using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCatalog
{
    public class Composite
    {
        public void Main()
        {
            var composite = new CompositeTask("Make Batter");

            composite.AddItem(new Task("Add Dry Ingredients",TimeSpan.FromMinutes(1)));
            composite.AddItem(new Task("Mix Ingredients", TimeSpan.FromMinutes(3)));

            Console.WriteLine(composite.GetTimeRequired());
        }

        public interface IComponent
        {
            TimeSpan GetTimeRequired();
        }

        public interface IComposite
        {
            void AddItem(IComponent component);
            void RemoveItem(IComponent component);
        }

        // Task is also referred to as a Component
        public class Task : IComponent
        {
            public string _name;
            public TimeSpan _timeRequired;

            public Task(string name, TimeSpan timeRequired)
            {
                _name = name;
                _timeRequired = timeRequired;
            }

            public TimeSpan GetTimeRequired()
            {
                return _timeRequired;
            }
        }

        public class CompositeTask : IComponent, IComposite
        {
            public List<IComponent> SubTasks { get; set; }

            public CompositeTask(string name)
            {
                SubTasks = new List<IComponent>();
            }

            public TimeSpan GetTimeRequired()
            {
                return SubTasks.Aggregate(
                    TimeSpan.FromSeconds(0),
                    (total, comp) => total += comp.GetTimeRequired()
                    );
            }

            public void AddItem(IComponent component)
            {
                SubTasks.Add(component);
            }

            public void RemoveItem(IComponent component)
            {
                SubTasks.Remove(component);
            }
        }
    }
}
