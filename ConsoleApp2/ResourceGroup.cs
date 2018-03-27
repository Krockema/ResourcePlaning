using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class ResourceGroup
    {

        public ResourceGroup(string name)
        {
            this.name = name;
        }

        public IList<Resource> Resources { get => resources; }

        public IList<Operation> Operations { get => operations; }

        public IList<ProductionOrderOperation> ProductionOrderOperations { get => productionOrderOperations; }

        private string name;

        private IList<Resource> resources = new List<Resource>();

        private IList<Operation> operations = new List<Operation>();

        private IList<ProductionOrderOperation> productionOrderOperations = new List<ProductionOrderOperation>();

    }
}
