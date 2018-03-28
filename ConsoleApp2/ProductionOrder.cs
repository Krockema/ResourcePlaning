using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class ProductionOrder : Satisfies
    {

        public ProductionOrder(Material material, double quantity)
        {
            this.material = material;
            this.quantity = quantity;
            NotYetRequiredQuantity = quantity;
            material.ProductionOrders.Add(this);
            createProductionOrderOperations();
            createProductionOrderBomPositions();
        }

        private void createProductionOrderBomPositions()
        {
            foreach (BOMPosition bOMPosition in material.BOMPositions)
            {
                new ProductionOrderBOMPosition(this, bOMPosition);
            }
        }

        private void createProductionOrderOperations()
        {
            foreach (Operation operation in material.Operations)
            {
                new ProductionOrderOperation(this, operation);
            }
        }

        public Material Material { get => material; }

        public double Quantity { get => quantity; }

        public IList<ProductionOrderBOMPosition> ProductionOrderBOMPositions { get => productionOrderBOMPositions; set => productionOrderBOMPositions = value; }

        public IList<ProductionOrderOperation> ProductionOrderOperations { get => productionOrderOperations; set => productionOrderOperations = value; }

        public IList<RequiredAndSatisfied> RequiredAndSatisfieds { get => requiredAndSatisfieds; }
        
        public int Time { get; set; }

        public double NotYetRequiredQuantity { get; set; }

        private Material material;

        private double quantity;

        private IList<ProductionOrderBOMPosition> productionOrderBOMPositions = new List<ProductionOrderBOMPosition>();

        private IList<ProductionOrderOperation> productionOrderOperations = new List<ProductionOrderOperation>();

        private IList<RequiredAndSatisfied> requiredAndSatisfieds = new List<RequiredAndSatisfied>();

    }
}
