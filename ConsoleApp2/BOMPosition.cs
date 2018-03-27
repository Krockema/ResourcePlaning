using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class BOMPosition
    {

        public BOMPosition(Material assemblyGroup)
        {
            this.assemblyGroup = assemblyGroup;
            assemblyGroup.BOMPositions.Add(this);
        }

        public Material AssemblyGroup { get => assemblyGroup; }

        public Material Component
        {
            get => component; set
            {
                component = value;
                component.BOMPositions.Add(this);
            }
        }

        public IList<ProductionOrderBOMPosition> ProductionOrderBOMPositions { get => productionOrderBOMPositions; set => productionOrderBOMPositions = value; }

        public double Quantity { get => quantity; set => quantity = value; }

        private Material assemblyGroup;

        private Material component = null;

        private double quantity = 0;

        private IList<ProductionOrderBOMPosition> productionOrderBOMPositions = new List<ProductionOrderBOMPosition>();

    }
}
