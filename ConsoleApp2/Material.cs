using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPlanningConsoleApp
{
    class Material
    {
        public Material(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }

        public IList<BOMPosition> BOMPositions { get => bOMPositions; }

        public IList<BOMPosition> Usages { get => usages; }

        public IList<Operation> Operations { get => operations; }

        public IList<PurchaseOrderPosition> PurchaseOrderPositions { get => purchaseOrderPositions; }

        public IList<SalesOrderPosition> SalesOrderPositions { get => salesOrderPositions; }

        public IList<Stock> Stocks { get => stocks; }

        public IList<ProductionOrder> ProductionOrders { get => productionOrders; }

        public IList<ProductionOrderBOMPosition> ProductionOrderBOMPositions { get => productionOrderBOMPositions; }

        private string name;

        private IList<BOMPosition> bOMPositions = new List<BOMPosition>();

        private IList<BOMPosition> usages = new List<BOMPosition>();

        private IList<Operation> operations = new List<Operation>();

        private IList<PurchaseOrderPosition> purchaseOrderPositions = new List<PurchaseOrderPosition>();

        private IList<SalesOrderPosition> salesOrderPositions = new List<SalesOrderPosition>();

        private IList<Stock> stocks = new List<Stock>();

        private IList<ProductionOrder> productionOrders = new List<ProductionOrder>();

        private IList<ProductionOrderBOMPosition> productionOrderBOMPositions = new List<ProductionOrderBOMPosition>();

    }
}
