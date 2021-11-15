using Controllers;
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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        private StockItemController _s;

        private OrderController _o;
        public AddItem(StockItemController s, OrderController o, OrderHeader order)

        {
            InitializeComponent();

            _s = s;
            _o = o;
            DataContext = order;
            dgItems.ItemsSource = _s.GetStockItems();


    }


    private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            OrderHeader order = (OrderHeader)DataContext;


            string action = (sender as Button).Content.ToString();

            StockItem item = (StockItem)((Button)e.Source).DataContext;

            string inputQuantity = quantityTB.Text;
            if (Int32.TryParse(inputQuantity,out int result))
            {
                int qty = int.Parse(inputQuantity);
                if (qty>=0)
                {
                    if (qty>item.InStock)
                    {
                        MessageBox.Show("Quantity Order Larger than Instock Quantity", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);

                        //enter number error message
                        //qty bigger than instock message
                    }
                    order =_o.UpsertOrderItem(order.Id, item.Id, qty);

                    NavigationService.Navigate(new AddOrder(_s, _o, order));
                }
                else
                {
                    MessageBox.Show("Enter Number 0 or above (No Negatives)", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

                    //enter number > 0 message
                }

            }
            else
            {
                if (inputQuantity=="")
                {
                    MessageBox.Show("Please Enter Quantity", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Enter Number Only", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

                    //enter number error message
                }


            }


        }

        
    }
}
