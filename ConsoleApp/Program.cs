using System;
using System.Collections.Generic;
using DataAccess;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        

        static void Main(string[] args)
        {

            StockRepo _s = new StockRepo();
            OrderRepo _o = new OrderRepo();

            //•	Orders
            //o InsertOrderHeader() : OrderHeader




            ////o GetOrderHeader(int id) : OrderHeader
            
            //OrderHeader OH = _o.GetOrderHeader(2);
            //Console.WriteLine(OH.Id+" "+OH.Total+" "+OH._orderItems.Count);
            //Console.WriteLine(OH.State);

            ////o GetOrderHeaders() : IEnumerable<OrderHeader>
            
            //Console.WriteLine("GetOrderHeaders");
            //IEnumerable<OrderHeader> allOH= _o.GetOrderHeaders();
            //foreach (var item in allOH)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.DateTime);
            //    Console.WriteLine(item.State);
            //    Console.WriteLine(item._orderItems.Count);
            //    Console.WriteLine(item.Total);
            //}


            //o UpsertOrderItem(OrderItem orderItem)


            //o UpdateOrderState(OrderHeader order)



            //o DeleteOrderHeaderAndOrderItems(int orderHeaderId)


            //o DeleteOrderItem(int orderHeaderId, int stockItemId)




            //•	Stock Items
            ////o GetStockItems() : IEnumerable<StockItem>
            //IEnumerable<StockItem> items= _s.GetStockItems();
            //Console.WriteLine("s.GetStockItems()");
            //foreach (var item in items)
            //{
            //    Console.WriteLine("Id:"+item.Id);
            //    Console.WriteLine("Name:"+ item.Name);
            //    Console.WriteLine("Price:"+item.Price);
            //    Console.WriteLine("Instock:"+item.InStock);

            //}

            ////o GetStockItem(int id) : StockItem
            //StockItem oneitem = _s.GetStockItem(9);
            //Console.WriteLine("s.GetStockItem(9)");

            //Console.WriteLine(oneitem.Id);
            //Console.WriteLine(oneitem.Name);
            //Console.WriteLine(oneitem.Price);
            //Console.WriteLine(oneitem.InStock);

            //o UpdateStockItemAmount(OrderHeader order).



        }
    }
}
