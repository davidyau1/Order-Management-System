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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Page
    {
        private StockItemController _s;

        private OrderController _o;

        public OrderDetails(StockItemController s, OrderController o, OrderHeader order)
        {
            InitializeComponent();

            _s = s;
            _o = o;
            DataContext = order;
            dgItems.ItemsSource = order._orderItems;
        }
        
   

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            string action = (sender as Button).Content.ToString();

            OrderHeader order = (OrderHeader)DataContext;
            if (order.State==OrderStates.New)
            {
                _o.SubmitOrder(order.Id);
                _o.ProcessOrder(order.Id);
                NavigationService.Navigate(new OrderIndex(_s, _o));

            }
            else if (order.State==OrderStates.Pending)
            {
                _o.ProcessOrder(order.Id);
                NavigationService.Navigate(new OrderIndex(_s, _o));
            }
            else
            {
                MessageBox.Show("Process only New and Pending Orders", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            OrderHeader order = (OrderHeader)DataContext;

            if (order.State == OrderStates.New||order.State==OrderStates.Pending)
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            string action = (sender as Button).Content.ToString();

            OrderHeader order = (OrderHeader)((Button)e.Source).DataContext;
            if (order.State==OrderStates.New||order.State==OrderStates.Pending)
            {
                NavigationService.Navigate(new AddOrder(_s, _o, order));

            }
            else
            {
                MessageBox.Show("Edit only New and Pending Orders", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
