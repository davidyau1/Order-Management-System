using Controllers;
using Domain;
using System;
using UI.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StockItemController stockControl;
        private OrderController orderControl;
        public MainWindow()
        {
            InitializeComponent();
            stockControl = new StockItemController();
            orderControl = new OrderController();
            frame.Navigate(new OrderIndex(stockControl, orderControl));

        }

    
        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
           
            OrderHeader newOrder =orderControl.CreateNewOrderHeader();
            frame.Navigate(new AddOrder(stockControl, orderControl,newOrder));

        }

        private void OrderIndex_Click(object sender, RoutedEventArgs e)
        {
            
            frame.Navigate(new OrderIndex(stockControl,orderControl));
        }
    }
}
