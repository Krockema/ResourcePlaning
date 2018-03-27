using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class RequiredAndSatisfied
    {
        public RequiredAndSatisfied(Requires requirement, Satisfies satisfier, double quantity)
        {
            this.requirement = requirement;
            this.satisfier = satisfier;
            this.quantity = quantity;
            requirement.RequiredAndSatisfieds.Add(this);
            satisfier.RequiredAndSatisfieds.Add(this);
        }

        public Requires Requirement { get => requirement; }

        public Satisfies Satisfier { get => satisfier; }

        private Requires requirement;

        private Satisfies satisfier;

        private double quantity;

    }
}
