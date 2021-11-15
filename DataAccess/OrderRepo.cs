using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class OrderRepo
    {
        //field - connectionString
        //tafe connection
        //private string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OrderManagementDb;Integrated Security=True";
       
        //home connection
        private string _connectionString = @"Data Source=./;Initial Catalog=OrderManagementDb;Integrated Security=True";
        public OrderHeader InsertOrderHeader()
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            //get a new order header
            OrderHeader order = null;
            //step 1: execute sp_InsertOrderHeader and get the generated id
            SqlCommand command = new SqlCommand("sp_InsertOrderHeader", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = int.Parse(reader[0].ToString());
            //step 2: call GetOrderHeader method and get the order header details	
            order = GetOrderHeader(id);
            connection.Close();

            return order;
        }
        public OrderHeader GetOrderHeader(int id)
        {
            OrderHeader myOrder = null;
            List<OrderItem> items = new List<OrderItem>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            //get an existing order header by id - execute sp_SelectOrderHeaderById
            SqlCommand command = new SqlCommand("sp_SelectOrderHeaderById", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {


                myOrder = new OrderHeader(reader.GetInt32(0), reader.GetDateTime(2), reader.GetInt32(1));
                if (reader[3] != DBNull.Value)
                {
                    OrderItem item = new OrderItem(myOrder, reader.GetInt32(3), reader.GetDecimal(5), reader.GetString(4), reader.GetInt32(6));
                    items.Add(item);
                }




            }
            foreach (var item in items)
            {
                myOrder.AddOrderItem(item.StockItemId, item.Price, item.Description, item.Quantity);
            }

            command.Parameters.Clear();

            connection.Close();

            return myOrder;


        }
        public IEnumerable<OrderHeader> GetOrderHeaders()
        {
            List<OrderHeader> allOrders = new List<OrderHeader>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            //get all existing order headers - execute sp_SelectOrderHeaders
            SqlCommand command = new SqlCommand("sp_SelectOrderHeaders", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            OrderHeader orderHeader = null;
            int testId = -1;
            while (reader.Read())
            {
                
                                                       
                    if (orderHeader == null)
                    {
                        orderHeader = new OrderHeader(reader.GetInt32(0), reader.GetDateTime(2), reader.GetInt32(1));
                        orderHeader.AddOrderItem(reader.GetInt32(3), reader.GetDecimal(5), reader.GetString(4), reader.GetInt32(6));
                        testId = reader.GetInt32(0);
                    }
                    else if (testId != reader.GetInt32(0))
                    { 
                        allOrders.Add(orderHeader);
                        orderHeader = new OrderHeader(reader.GetInt32(0), reader.GetDateTime(2), reader.GetInt32(1));
                        orderHeader.AddOrderItem(reader.GetInt32(3), reader.GetDecimal(5), reader.GetString(4), reader.GetInt32(6));
                        testId = reader.GetInt32(0);

                    }
                    else if (testId == reader.GetInt32(0))
                    {
                        orderHeader.AddOrderItem(reader.GetInt32(3), reader.GetDecimal(5), reader.GetString(4), reader.GetInt32(6));
                    }
                

            }
            connection.Close();
            if (orderHeader!=null)
            {
                allOrders.Add(orderHeader);

            }
            return allOrders;
        }
       
       

        public void UpsertOrderItem(OrderItem orderItem)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            //insert or update an order item - execute sp_UpsertOrderItem
            SqlCommand command = new SqlCommand("sp_UpsertOrderItem", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            
            command.Parameters.Add(new SqlParameter("@orderHeaderId", orderItem.OrderHeaderId));
            command.Parameters.Add(new SqlParameter("@stockItemId", orderItem.StockItemId));
            command.Parameters.Add(new SqlParameter("@description", orderItem.Description));
            command.Parameters.Add(new SqlParameter("@price", orderItem.Price));
            command.Parameters.Add(new SqlParameter("@quantity", orderItem.Quantity));
            
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            
            connection.Close();

        }
        public void UpdateOrderState(OrderHeader order)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            //update the state of an existing order header - execute sp_UpdateOrderState
            SqlCommand command = new SqlCommand("sp_UpdateOrderState", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@orderHeaderId", order.Id));
            command.Parameters.Add(new SqlParameter("@stateId", (int)order.State));
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();


        }
        public void DeleteOrderHeaderAndOrderItems(int orderHeaderId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            //delete an existing order header and its items - execute sp_DeleteOrderHeaderAndOrderItems
            SqlCommand command = new SqlCommand("sp_DeleteOrderHeaderAndOrderItems", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@orderHeaderId", orderHeaderId));

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }
        public void DeleteOrderItem(int orderHeaderId, int stockItemId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            //delete an existing order item - execute sp_DeleteOrderItem
            SqlCommand command = new SqlCommand("sp_DeleteOrderItem", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@orderHeaderId", orderHeaderId));
            command.Parameters.Add(new SqlParameter("@stockItemId", stockItemId));

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();

        }
    }
}
