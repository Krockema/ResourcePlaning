using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class StorageLocation
    {

        public StorageLocation(string name)
        {
            this.name = name;
        }
        public string Name { get => name; }
        public IList<Stock> Stocks { get => stocks; }

        private string name;

        private IList<Stock> stocks = new List<Stock>();

    }
}
