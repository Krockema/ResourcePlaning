using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    /*
     * TODO
     * - separate RequiredAndSatisfieds in Requires and Satisfies
     * - integrate ResourceGroup
     * - add this to aggregate (multiple times) ==> explicite setters
     * - take lorry into account
     * - central collections for instances?
     * - central collections as parameter of constructor?
     * - bidirectional links?
     * - links "over" n:m-relations?
     * - setup and processing times
     * - delivery times at materials
     * - customer/supplier and material2...-relations?
     * - ???
     * - fix git
     * - fix git 2
     * - git test
     * - git test 2
     */

    class CentralPlanning
    {
        public static void Main(string[] args)
        {
            CentralPlanning cp = new CentralPlanning();
            cp.createData();
            new CentralPlanning().PlanCentrally();
            Console.ReadKey();
        }

        private IList<ResourceGroup> resourceGroups = new List<ResourceGroup>();
        private IList<Material> materials = new List<Material>();
        private StorageLocation storageLocation = new StorageLocation("Warehouse");
        private IList<Requires> requirements = new List<Requires>();
        private IList<Satisfies> satisfiers = new List<Satisfies>();

        private void createData()
        {
            ResourceGroup assemblyStations = new ResourceGroup("Assembly Stations");
            resourceGroups.Add(assemblyStations);
            ResourceGroup screwDrivers = new ResourceGroup("Screw Drivers");
            resourceGroups.Add(screwDrivers);
            ResourceGroup paintBrushs = new ResourceGroup("Paintbrushs");
            resourceGroups.Add(paintBrushs);
            ResourceGroup saws = new ResourceGroup("Saws");
            resourceGroups.Add(saws);
            ResourceGroup turningLathes = new ResourceGroup("Turning Lathes");
            resourceGroups.Add(turningLathes);

            Resource assemblyStation1 = new Resource("Assembly Station 1", assemblyStations);
            Resource assemblyStation2 = new Resource("Assembly Station 2", assemblyStations);
            Resource assemblyStation3 = new Resource("Assembly Station 3", assemblyStations);
            Resource screwDriver1 = new Resource("Screwdriver 1", screwDrivers);
            Resource screwDriver2 = new Resource("Screwdriver 2", screwDrivers);
            Resource screwDriver3 = new Resource("Screwdriver 3", screwDrivers);
            Resource paintBrush1 = new Resource("Paintbrush 1", paintBrushs);
            Resource paintBrush2 = new Resource("Paintbrush 2", paintBrushs);
            Resource paintBrush3 = new Resource("Paintbrush 3", paintBrushs);
            Resource saw1 = new Resource("Saw 1", saws);
            Resource saw2 = new Resource("Saw 2", saws);
            Resource saw3 = new Resource("Saw 3", saws);
            Resource turningLathe1 = new Resource("Turning Lathe 1", turningLathes);
            Resource turningLathe2 = new Resource("Turning Lathe 2", turningLathes);
            Resource turningLathe3 = new Resource("Turning Lathe 3", turningLathes);

            Material table = new Material("Table") { Production = Production.Inhouse };
            materials.Add(table);
            Material tableTop = new Material("Table Top") { Production = Production.Inhouse };
            materials.Add(tableTop);
            Material tableLeg = new Material("Table Leg") { Production = Production.Inhouse };
            materials.Add(tableLeg);
            Material chair = new Material("Chair") { Production = Production.Inhouse };
            materials.Add(chair);
            Material chairSeat = new Material("Chair Seat") { Production = Production.Inhouse };
            materials.Add(chairSeat);
            Material backRest = new Material("Back Rest") { Production = Production.Inhouse };
            materials.Add(backRest);
            Material chairLeg = new Material("Chair Leg") { Production = Production.Inhouse };
            materials.Add(chairLeg);
            Material screw = new Material("Screw") { Production = Production.External };
            materials.Add(screw);
            Material squareTimber = new Material("Square Timber") { Production = Production.External };
            materials.Add(squareTimber);
            Material roundTimber = new Material("Round Timber") { Production = Production.External };
            materials.Add(roundTimber);
            Material paint = new Material("Paint") { Production = Production.External };
            materials.Add(paint);

            
            new BOMPosition(table) { Component = tableTop, Quantity = 1 };
            new BOMPosition(table) { Component = tableLeg, Quantity = 4 };
            new BOMPosition(table) { Component = screw, Quantity = 16 };
            new BOMPosition(table) { Component = paint, Quantity = 0.5};

            new BOMPosition(chair) { Component = chairSeat, Quantity = 1 };
            new BOMPosition(chair) { Component = chairLeg, Quantity = 4 };
            new BOMPosition(chair) { Component = backRest, Quantity = 1 };
            new BOMPosition(chair) { Component = screw, Quantity = 24 };
            new BOMPosition(chair) { Component = paint, Quantity = 0.5};

            new BOMPosition(tableTop) { Component = squareTimber, Quantity = 1 };

            new BOMPosition(tableLeg) { Component = roundTimber, Quantity = 1 };

            new BOMPosition(chairSeat) { Component = squareTimber, Quantity = 0.5 };

            new BOMPosition(backRest) { Component = squareTimber, Quantity = 0.5 };

            new BOMPosition(chairLeg) { Component = roundTimber, Quantity = 0.5 };
            

            new Operation("Assemble Table", table, 2);
            new Operation("Screw Tightly Table", table, 3);
            new Operation("Paint Table", table, 4);
            new Operation("Assemble BackRest", backRest, 2);
            new Operation("Screw Tightly Back Rest", backRest, 2);
            new Operation("Assemble Chair", chair, 2);
            new Operation("Screw Tightly Chair", chair, 3);
            new Operation("Paint Chair", chair, 4);
            new Operation("Lathe Table Leg", tableLeg, 4);
            new Operation("Lathe Chair Leg", chairLeg, 4);
            new Operation("Saw Table Top", tableTop, 4);
            new Operation("Saw Chair Seat", chairSeat, 4);
            new Operation("Saw Backrest", backRest, 4);

            requirements.Add(new SalesOrderPosition(table, 10, 90));
            requirements.Add(new SalesOrderPosition(chair, 40, 90));
            requirements.Add(new SalesOrderPosition(table, 5, 100));
            requirements.Add(new SalesOrderPosition(chair, 20, 100));
            requirements.Add(new SalesOrderPosition(table, 4, 110));
            requirements.Add(new SalesOrderPosition(chair, 16, 110));
            requirements.Add(new Stock(screw, storageLocation, 20.0, 80));

            satisfiers.Add(new Stock(paint, storageLocation, 15, 70));
        }

        void PlanCentrally()
        {
            while (requirements.Count > 0)
            {
                Requires requirement = requirements.First<Requires>();
                requirements.RemoveAt(0); // TODO get and remove first in one operation/method?
                foreach(Satisfies satisfier in satisfiers)
                {
                    if (satisfier.Material.Equals(requirement.Material) && satisfier.NotYetRequiredQuantity > 0.0) // TODO equals by what? name?
                    {
                        // TODO calculate the following rather than branch applying ifs
                        if (requirement.NotYetSatisfiedQuantity > satisfier.NotYetRequiredQuantity)
                        {
                            new RequiredAndSatisfied(requirement, satisfier, satisfier.NotYetRequiredQuantity);
                            requirement.NotYetSatisfiedQuantity -= satisfier.NotYetRequiredQuantity;
                            satisfier.NotYetRequiredQuantity = 0.0;
                            // TODO extract satisfier from satisfiers? no for each!
                        }
                        else if (requirement.NotYetSatisfiedQuantity < satisfier.NotYetRequiredQuantity)
                        {
                            new RequiredAndSatisfied(requirement, satisfier, satisfier.NotYetRequiredQuantity);
                            satisfier.NotYetRequiredQuantity -= requirement.NotYetSatisfiedQuantity;
                            requirement.NotYetSatisfiedQuantity = 0.0;
                            requirements.Remove(requirement);
                        }
                        else
                        {
                            new RequiredAndSatisfied(requirement, satisfier, satisfier.NotYetRequiredQuantity);
                            satisfier.NotYetRequiredQuantity = 0.0;
                            requirement.NotYetSatisfiedQuantity = 0.0;
                            requirements.Remove(requirement);
                        }
                    }
                }
                if (requirement.NotYetSatisfiedQuantity > 0.0)
                {
                    switch (requirement.Material.Production)
                    {
                        case Production.External:
                            PurchaseOrderPosition purchaseOrderPosition = new PurchaseOrderPosition(requirement.Material, requirement.NotYetSatisfiedQuantity); // TODO lot-sizing at this point?
                            new RequiredAndSatisfied(requirement, purchaseOrderPosition, purchaseOrderPosition.Quantity);
                            // TODO schedule backwards
                            break;
                        case Production.Inhouse:
                            ProductionOrder productionOrder = new ProductionOrder(requirement.Material, requirement.NotYetSatisfiedQuantity); // TODO lot-sizing at this point?
                            new RequiredAndSatisfied(requirement, productionOrder, productionOrder.Quantity);
                            // TODO schedule backwards
                            break;
                        default:
                            throw new Exception("No such value of enum Production.");
                    }
                    requirement.NotYetSatisfiedQuantity = 0.0;
                    requirements.Remove(requirement);
                }
            }
            /*
            // version with no purchase order and no production order (breadth first):
            // build network of requirements and satisfiers and schedule backwards:
            add each requirement to a collection sorted by its end date descending
            while the collection of requirements is not empty
              take the first requirement out of the collection
              find satisfiers for the requirement
              connect the satisfiers with the requirement // If
              calculate remaining requirement not yet satisfied
              if remaining requirement > 0 then 			// else if
                create appropriate satisfiers
                connect satisfiers with the remaining requirement
                for each satisfier do
                  schedule satisfier backwards
                  for each component of the satisfier do
                    add requirement to the collection of requirements
                  end for each // component of the satisfier
                end for each // satisfier
              end if // remaining requirement > 0
            end while // the collection of requirements is not empty
            if at least one start date of a satisfier lies in the past then
              // forwards scheduling:
              find all satisfiers with a start date in the past and no predecessors
              add these satisfiers to a collection sorted by its start date ascending
              while the collection of satisfiers is not empty
                take the first satisfier out of the collection
                schedule satisfier forwards
                for each requirement satisfied by this satisfier
                  if the requirement is fully satisfied // (by this satisfier and/or other satisfiers) // by all siblings
                    add the requirement as satisfier to the collection of satisfiers
                  end if // the requirement is fully satisfied (by this satisfier and/or other satisfiers)
                end for each // requirement satisfied by this satisfier
              end while // the collection of satisfiers is not empty
              // backwards scheduling:
              find all requirements with no successors
              add these requirements to a collection sorted by its start date descending
              while the collection of requirements is not empty
                take the first requirement out of the collection
                schedule requirement backwards
                for each satisfier required by this requirement
                  if the satisfier is fully required (by this requirement and/or other requirements)
                    add the satisfier as requirement to the collection of requirements
                  end if // the satisfier is fully required (by this requirement and/or other requirements)
                end for each // requirement satisfied by this satisfier
              end while // the collection of satisfiers is not empty
            end if // at least one start date lies in the past
            // finite capacity planning:
            apply Giffler-Thompson algorithm to the net of requirements and satisfiers
             */
        }
    }
}
