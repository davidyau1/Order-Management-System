using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Controllers
{
    public class OrderController
    {
        //declare two private fields; OrderRepo instance called _orderRepository and StockRepo instance called _stockItemRepository
        private StockRepo _srepo = new StockRepo();
        private OrderRepo _orepo = new OrderRepo();
        public OrderController()
        {
         
        }
        //implement the following methods
        public IEnumerable<OrderHeader> GetOrderHeaders()
        {
            //call GetOrderHeaders method in OrderRepo
            return _orepo.GetOrderHeaders();
          
        }
        
        public OrderHeader CreateNewOrderHeader()
        {
            //call InsertOrderHeader method in OrderRepo
            return _orepo.InsertOrderHeader();
        }
       
      
        public OrderHeader UpsertOrderItem(int orderHeaderId, int stockItemId, int quantity)
        {
            //call GetStockItem method in StockRepo to get the details of stock item to add to the order	
           StockItem item= _srepo.GetStockItem(stockItemId);
            //call GetOrderHeader method in OrderRepo to get the details of order header 
           OrderHeader order=_orepo.GetOrderHeader(orderHeaderId);
            //call AddOrderItem method in OrderHeader to add the stock item to order
            OrderItem orderItem= order.AddOrderItem(item.Id, item.Price, item.Name, quantity);
            //call UpsertOrderItem method in OrderRepo 
            _orepo.UpsertOrderItem(orderItem);
            //return updated OrderHeader object	
            return order;
        }
        public OrderHeader SubmitOrder(int orderHeaderId)
        {
            //call GetOrderHeader method in OrderRepo to get the details of order header 
            OrderHeader header = _orepo.GetOrderHeader(orderHeaderId);
            //call Submit method of OrderHeader 
            header.Submit();
            //call UpdateOrderState method in OrderRepo
            _orepo.UpdateOrderState(header);
            //return updated OrderHeader object
            return header;
        }
        public OrderHeader ProcessOrder(int orderHeaderId)
        {
            var order = _orepo.GetOrderHeader(orderHeaderId);
            try
            {
                try
                {
                    _srepo.UpdateStockItemAmount(order);
                    order.Complete();
                }
                catch (SqlException ex)
                {
                    //Check Constraint Violation
                    if (ex.Number == 547)
                    {
                        order.Rejected();
                    }
                }
                _orepo.UpdateOrderState(order);
            }
            catch (InvalidOrderStateException ex)
            {
                throw ex;
            }
            return order;
        }
        public void DeleteOrderHeaderAndOrderItems(int orderHeaderId)
        {
            //call DeleteOrderHeaderAndOrderItems method in OrderRepo;
            _orepo.DeleteOrderHeaderAndOrderItems(orderHeaderId);
        }
        public OrderHeader DeleteOrderItem(int orderHeaderId, int stockItemId)
        {
            //call DeleteOrderItem method in OrderRepo
           _orepo.DeleteOrderItem(orderHeaderId, stockItemId);
            //call  GetOrderHeader method in OrderRepo to get the details of order header
            OrderHeader header= _orepo.GetOrderHeader(orderHeaderId);
            //return 
            return header;
        }
    }
}
