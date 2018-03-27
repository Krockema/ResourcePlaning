using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    interface Requires
    {
        IList<RequiredAndSatisfied> RequiredAndSatisfieds { get; }

        Material Material { get; }

        double NotYetSatisfiedQuantity { get; set; }
    }
}
