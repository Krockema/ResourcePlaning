using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class ProductionOrderOperation
    {

        public ProductionOrderOperation(ProductionOrder productionOrder, Operation operation)
        {
            this.productionOrder = productionOrder;
            this.operation = operation;
            this.resourceGroup = operation.ResourceGroup;
            productionOrder.ProductionOrderOperations.Add(this);
            operation.ProductionOrderOperations.Add(this);
            resourceGroup.ProductionOrderOperations.Add(this);
        }

        public ProductionOrder ProductionOrder { get => productionOrder; }

        public ResourceGroup ResourceGroup { get => resourceGroup; }

        internal Operation Operation { get => operation; }

        private ProductionOrder productionOrder;

        private ResourceGroup resourceGroup;

        private Operation operation;

    }
}
