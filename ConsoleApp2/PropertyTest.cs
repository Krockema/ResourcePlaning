using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{

    class Foo
    {

        public Foo(int id)
        {
            this.id = id;
        }
        public int Id { get => id; }

        private int id;

    }

    class PropertyTest
    {

        public static void _Main()
        {
            PropertyTest propertyTest = new PropertyTest();
            propertyTest.Foos.Add(new Foo(1));
            propertyTest.Foos.Add(new Foo(2));
            foreach (Foo foo in propertyTest.Foos)
            {
                Console.WriteLine(foo.Id);
            }
            Console.ReadKey();
        }

        internal IList<Foo> Foos { get => foos; }

        private IList<Foo> foos = new List<Foo>();

    }
}
