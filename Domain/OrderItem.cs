using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    
	public class OrderItem
	{
        //props
        //OrderHeaderId - int (public getter, private setter)
        public int OrderHeaderId { get; private set; }
        //OrderHeader - OrderHeader(public getter, private setter)
        public OrderHeader OrderHeader { get;private set; }
        //StockItemId - int (public getter, private setter)
        public int StockItemId { get; private set; }
        //Price - decimal (public getter, private setter)
        public decimal Price { get; private set; }
        //Description - string (public getter, private setter)
        public string Description { get;private set; }
        //Quantity - int (public getter, public setter)
        public int Quantity { get; set; }
        //Total - decimal (public getter returns price * quantity)
        public decimal Total { get { return Price * Quantity; } }

        //cons
        public OrderItem(OrderHeader order, int stockItemId, decimal price, string description, int quantity)
		{
            //assign value from param to OrderHeaderId prop
            OrderHeaderId = order.Id;
            //assign value from param to OrderHeader prop
            OrderHeader = order;
            //assign value from param to StockItemId prop
            StockItemId = stockItemId;
            //assign value from param to Price prop
            Price = price;
            //assign value from param to Description prop
            Description = description;
            //assign value from param to Quantity prop
            Quantity = quantity;
		}
	}
	
}
