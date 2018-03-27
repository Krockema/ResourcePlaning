using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    interface Satisfies
    {

        IList<RequiredAndSatisfied> RequiredAndSatisfieds { get; }

        int Time { get; }

        Material Material { get; }

        double YetUnrequiredQuantity { get; set; }
    }
}
