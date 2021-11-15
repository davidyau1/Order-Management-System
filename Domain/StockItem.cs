using System;

namespace Domain
{
    public class StockItem
    {
        //create 4 prop =get only and private set
        //prop names:int Id, string Name, decimal Price, int InStock
        //create contstuctor with 4 params id,name,price, inStock

        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int InStock { get; private set; }

        public StockItem(int id, string name, decimal price, int inStock)
        {
            Id = id;
            Name = name;
            Price = price;
            InStock = inStock;

        }
    }
}
