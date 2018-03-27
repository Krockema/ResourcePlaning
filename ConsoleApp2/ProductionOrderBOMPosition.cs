using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class ProductionOrderBOMPosition : Requires
    {

        public ProductionOrderBOMPosition(ProductionOrder productionOrder, BOMPosition bOMPosition)
        {
            this.productionOrder = productionOrder;
            this.bOMPosition = bOMPosition;
            this.material = bOMPosition.Component;
            productionOrder.ProductionOrderBOMPositions.Add(this);
            bOMPosition.ProductionOrderBOMPositions.Add(this);
            material.ProductionOrderBOMPositions.Add(this);
        }

        public ProductionOrder ProductionOrder { get => productionOrder; }

        public Material Material { get => material; }

        public double Quantity { get => quantity; set => quantity = value; }

        public IList<RequiredAndSatisfied> RequiredAndSatisfieds { get => requiredAndSatisfieds; }

        public BOMPosition BOMPosition { get => bOMPosition; }

        public int Time { get => time; set => time = value; }

        public double NotYetSatisfiedQuantity { get; set; }

        private ProductionOrder productionOrder;

        private BOMPosition bOMPosition;

        private Material material;

        private double quantity = 0;

        private int time = 0;

        private IList<RequiredAndSatisfied> requiredAndSatisfieds = new List<RequiredAndSatisfied>();

    }
}
