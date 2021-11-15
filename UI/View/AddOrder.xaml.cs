using Controllers;
using DataAccess;
using Domain;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {    //private StockRepo srepo;
        // OrderRepo orepo;
        private StockItemController _s;

        private OrderController _o;

        public AddOrder(StockItemController s, OrderController o, OrderHeader newOrder)
        {

            InitializeComponent();
            _s = s;
            _o = o;
            DataContext = newOrder;
            dgItems.ItemsSource = newOrder._orderItems;

        }





        private void AddItems_Click(object sender, RoutedEventArgs e)
        {
            string action = (sender as Button).Content.ToString();

            OrderHeader order = (OrderHeader)((Button)e.Source).DataContext;
            NavigationService.Navigate(new AddItem(_s,_o,order));
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            OrderHeader order = (OrderHeader)DataContext;
            _o.SubmitOrder(order.Id);
            NavigationService.Navigate(new OrderIndex(_s, _o));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            OrderHeader order = (OrderHeader)DataContext;

            if (order.State == OrderStates.New || order.State == OrderStates.Pending)
            {
                _o.DeleteOrderHeaderAndOrderItems(order.Id);
                NavigationService.Navigate(new OrderIndex(_s, _o));

            }
            else
            {
                //message about new and pending
                MessageBox.Show("Delete only New and Pending Orders", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }
    }
}
