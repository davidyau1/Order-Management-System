using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
  
    public class StockRepo
    {
       //tafe connection
       //private string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OrderManagementDb;Integrated Security=True";
        
        
        //home connection
        private string _connectionString = @"Data Source=./;Initial Catalog=OrderManagementDb;Integrated Security=True";

        public IEnumerable<StockItem> GetStockItems()
        {

            List<StockItem> allStocks = new List<StockItem>();

            //get all stockitem details -SELECT * FROM StockItems
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            SqlCommand command = new SqlCommand("sp_SelectStockItems", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                StockItem p = new StockItem(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
              

                allStocks.Add(p);
            }
            connection.Close();

            return allStocks;

        }

        public StockItem GetStockItem(int id)
        {
            StockItem myItem = null;
            //get a selected stockitems details- SELECT * FROM StockItems WHERE id=@id 
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            SqlCommand command = new SqlCommand("sp_SelectStockItemById", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                myItem = new StockItem(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
            }
            
            return myItem;
        }
        public void UpdateStockItemAmount(OrderHeader order)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sp_UpdateStockItemAmount", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var oi in order._orderItems)
            {
                command.Parameters.Add(new SqlParameter("@id", oi.StockItemId));
                command.Parameters.Add(new SqlParameter("@amount", -oi.Quantity));
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            connection.Close();
        }
    } 
}


