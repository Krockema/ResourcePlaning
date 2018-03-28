using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class Operation
    {
        public Operation(string name, Material material, int setUpDuration, int processingDuration)
        {
            this.name = name;
            this.material = material;
            this.setUpDuration = setUpDuration;
            this.processingDuration = processingDuration;
            material.Operations.Add(this);
        }

        public string Name { get => name; }

        public Material Material { get => material; }

        public ResourceGroup ResourceGroup
        {
            get => resourceGroup; set
            {
                resourceGroup = value;
                resourceGroup.Operations.Add(this);
            }
        }

        public IList<ProductionOrderOperation> ProductionOrderOperations { get => productionOrderOperations; }

        public int SetUpDuration { get => setUpDuration; }

        public int ProcessingDuration { get => processingDuration; }

        private string name;

        private Material material;

        private ResourceGroup resourceGroup = null;

        private IList<ProductionOrderOperation> productionOrderOperations = new List<ProductionOrderOperation>();

        private int setUpDuration;

        private int processingDuration;

    }
}
