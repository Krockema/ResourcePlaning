using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class PurchaseOrderPosition : Satisfies
    {

        public PurchaseOrderPosition(Material material, double quantity)
        {
            this.material = material;
            this.quantity = quantity;
            material.PurchaseOrderPositions.Add(this);
        }

        public Material Material { get => material; }

        public double Quantity { get => quantity; }

        public IList<RequiredAndSatisfied> RequiredAndSatisfieds => requiredAndSatisfieds;

        public int Time { get => time; set => time = value; }

        public double YetUnrequiredQuantity { get; set; }

        private Material material;

        private double quantity;

        private int time;

        private IList<RequiredAndSatisfied> requiredAndSatisfieds = new List<RequiredAndSatisfied>();

    }
}
