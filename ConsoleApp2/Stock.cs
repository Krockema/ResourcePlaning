using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class Stock : Requires, Satisfies
    {

        public Stock(Material material, StorageLocation storageLocation, double quantity, int time)
        {
            this.material = material;
            this.storageLocation = storageLocation;
            this.quantity = quantity;
            this.time = time;
            material.Stocks.Add(this);
            storageLocation.Stocks.Add(this);
        }

        public Material Material { get => material; }

        public StorageLocation StorageLocation { get => storageLocation; }

        public double Quantity { get => quantity; }

        public Requires Requirement { get => requirement; set => requirement = value; }

        public Satisfies Satisfier { get => satisfier; set => satisfier = value; }

        public IList<RequiredAndSatisfied> RequiredAndSatisfieds => satisfier.RequiredAndSatisfieds;

        public int Time { get => time; set => time = value; }

        private Material material;

        private StorageLocation storageLocation;

        private double quantity;

        private int time = 0;

        private Requires requirement = null;

        private Satisfies satisfier = null;

    }
}
