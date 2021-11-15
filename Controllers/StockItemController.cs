using DataAccess;
using Domain;
using System;
using System.Collections.Generic;

namespace Controllers
{
    public class StockItemController
    {
        private StockRepo _srepo= new StockRepo ();
        public StockItemController()
        {
        }
        public IEnumerable<StockItem> GetStockItems()
        {
            //call the method in stock repo to return all stock items
            return _srepo.GetStockItems();
        }
    }
}
