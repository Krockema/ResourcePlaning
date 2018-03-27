using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class SalesOrderPosition : Requires
    {

        public SalesOrderPosition(Material material, double quantity, int time)
        {
            this.material = material;
            this.quantity = quantity;
            this.time = time;
            material.SalesOrderPositions.Add(this);
        }

        public Material Material { get => material; }

        public double Quantity { get => quantity; }

        public IList<RequiredAndSatisfied> RequiredAndSatisfieds => requiredAndSatisfieds;

        public int Time { get => time; }

        public double NotYetSatisfiedQuantity { get; set; }

        private Material material;

        private double quantity;

        private int time;

        private IList<RequiredAndSatisfied> requiredAndSatisfieds = new List<RequiredAndSatisfied>();

    }
}
