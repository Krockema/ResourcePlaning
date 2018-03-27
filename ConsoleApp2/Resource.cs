using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class Resource
    {

        public Resource(string name, ResourceGroup resourceGroup)
        {
            this.name = name;
            this.resourceGroup = resourceGroup;
            resourceGroup.Resources.Add(this);
        }

        public string Name { get => name; set => name = value; }

        private string name;

        private ResourceGroup resourceGroup;

    }
}
