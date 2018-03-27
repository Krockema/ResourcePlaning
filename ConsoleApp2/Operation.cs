using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class Operation
    {
        public Operation(string name, Material material, int duration)
        {
            this.name = name;
            this.material = material;
            this.duration = duration;
            material.Operations.Add(this);
        }

        public string Name { get => name; }

        public Material Material { get => material; }

        public int Duration { get => duration; set => duration = value; }

        public ResourceGroup ResourceGroup
        {
            get => resourceGroup; set
            {
                resourceGroup = value;
                resourceGroup.Operations.Add(this);
            }
        }

        public IList<ProductionOrderOperation> ProductionOrderOperations { get => productionOrderOperations; }

        private string name;

        private Material material;

        private int duration;

        private ResourceGroup resourceGroup = null;

        private IList<ProductionOrderOperation> productionOrderOperations = new List<ProductionOrderOperation>();

    }
}
