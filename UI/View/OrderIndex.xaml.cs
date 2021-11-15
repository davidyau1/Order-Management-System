using Domain;
using Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI.View
{ 
    /// <summary>
    /// Interaction logic for OrderIndex.xaml
    /// </summary>
    public partial class OrderIndex : Page
    {
        private StockItemController _s;
        private OrderController _o;

        public OrderIndex(StockItemController s,OrderController o)
        {
            InitializeComponent();

            _s = s;
            _o = o;                    
            dgOrders.ItemsSource = _o.GetOrderHeaders();

            

        }
     

        private void OrderDetails_Click(object sender, RoutedEventArgs e)
        {
            string action = (sender as Button).Content.ToString();

            OrderHeader order = (OrderHeader)((Button)e.Source).DataContext;
            NavigationService.Navigate(new OrderDetails(_s,_o, order));
        }
       

     
    }
}
