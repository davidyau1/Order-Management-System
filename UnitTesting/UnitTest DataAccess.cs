using DataAccess;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting_DataAccess
{
    [TestClass()]
    public class UnitTesting_DA
    {
        private StockRepo _srepo;
        private OrderRepo _orepo;
        
        [TestInitialize]
        public void Init()
        {
            _srepo = new StockRepo();
            _orepo = new OrderRepo();
        }

     
        //•	Stock Items
        //o GetStockItems() : IEnumerable<StockItem>
   

        [TestMethod()]
        public void GetStockItems()
        {
            IEnumerable<StockItem> allstock = _srepo.GetStockItems();
            Assert.IsTrue(allstock.Count() > 0);

        }
        //o   GetStockItem(int id) : StockItem
        [TestMethod()]
        public void GetStockItem()
        {
            StockItem stock = _srepo.GetStockItem(1);
            Assert.IsTrue(stock != null);

        }

        //o   UpdateStockItemAmount(OrderHeader order).

        [TestMethod()]
        public void UpdateStockItemAmount()
        {
            DateTime date = new DateTime(2015, 12, 25);
            OrderHeader order = new OrderHeader(1, date, 1);

            _srepo.UpdateStockItemAmount(order);


        }
        //•	Orders
        //o   InsertOrderHeader() : OrderHeader
   
        [TestMethod()]
        public void InsertOrderHeader()
        {
            OrderHeader order = _orepo.InsertOrderHeader();
            Assert.IsTrue(order != null);
        }

        //o   GetOrderHeader(int id) : OrderHeader
   
        [TestMethod()]

        public void GetOrderHeader()
        {

            OrderHeader order = _orepo.GetOrderHeader(1);
            Assert.IsTrue(order != null);
        }
        //o   GetOrderHeaders() : IEnumerable<OrderHeader>
     
        [TestMethod()]
        public void GetOrderHeaders()
        {
            IEnumerable<OrderHeader> allstock = _orepo.GetOrderHeaders();
            Assert.IsTrue(allstock.Count() > 0);
        }

        //o   UpsertOrderItem(OrderItem orderItem)

        [TestMethod()]
        public void UpsertOrderItem()
        {
            OrderHeader order = _orepo.InsertOrderHeader();
            Assert.IsTrue(order != null);
        }
        //o UpdateOrderState(OrderHeader order)
      
        [TestMethod()]
        public void UpdateOrderState()
        {
            //OrderHeader order = _orepo.InsertOrderHeader();
            //Assert.IsTrue(order != null);
        }

        //o DeleteOrderHeaderAndOrderItems(int orderHeaderId)
        [TestMethod()]
        public void DeleteOrderHeaderAndOrderItems()
        {
            //OrderHeader order = _orepo.InsertOrderHeader();
            //Assert.IsTrue(order != null);
        }

        //o DeleteOrderItem(int orderHeaderId, int stockItemId)
        [TestMethod()]
        public void DeleteOrderItem()
        {
            //OrderHeader order = _orepo.InsertOrderHeader();
            //Assert.IsTrue(order != null);
        }
    }
}
