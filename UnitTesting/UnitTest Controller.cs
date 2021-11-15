using Controllers;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting_Controller
{
    [TestClass()]
    public class UnitTesting_Controller
    {
        private StockItemController _sc;
        private OrderController _oc;
        [TestInitialize]
        public void Init()
        {
            _sc = new StockItemController();
            _oc = new OrderController();
        }

        // •	Orders

        //o   GetOrderHeaders() : IEnumerable<OrderHeader>
        [TestMethod()]
        public void GetOrderHeaders()
        {

        }

        //o   CreateNewOrderHeader() : OrderHeader
        [TestMethod()]
        public void CreateNewOrderHeader()
        {

        }
        //o   UpsertOrderItem(int orderHeaderId, int stockItemId, int quantity) : OrderHeader
        [TestMethod()]
        public void UpsertOrderItem()
        {

        }

        //o   SubmitOrder(int orderHeaderId) : OrderHeader
        [TestMethod()]
        public void SubmitOrder()
        {

        }

        //o   ProcessOrder(int orderHeaderId) : OrderHeader
        [TestMethod()]
        public void ProcessOrder()
        {

        }

        //o   DeleteOrderHeaderAndOrderItems(int orderHeaderId)
        [TestMethod()]
        public void DeleteOrderHeaderAndOrderItems()
        {

        }

        //o DeleteOrderItem(int orderHeaderId, int stockItemId)
        [TestMethod()]
        public void DeleteOrderItem()
        {

        }

        //•	Stock Items
        //o GetStockItems() : IEnumerable<StockItem>.
        [TestMethod()]
        public void GetStockItems()
        {

        }
    }
}
