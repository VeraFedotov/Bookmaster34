using Bookmaster34.AppData;
using Bookmaster34.Models;
using Bookmaster34.View.Windows;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
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

namespace Bookmaster34.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        private List<Customer> _customers;

        private Customer _selectedCustomer;
        public ManageCustomersPage()
        {
            InitializeComponent();

            _customers = App.GetContext().Customers.ToList();
            LoadData();
        }

        private void EditCustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer? selectedCustomer = CustomerLv.SelectedItem as Customer;

            if (selectedCustomer != null)
            {
                AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
                addEditCustomerWindow.ShowDialog();
            }
            else
            {
                FeedbackService.Error("Невозможно открыть окно для редактирования читателя. Сначала выберите его из списка.");
            }
        }

        private void AddCustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            if (addEditCustomerWindow.ShowDialog() == true)
            {
                CustomerLv.ItemsSource = _customers = App.GetContext().Customers.ToList();
            }
        }

        private void SearchCustomersBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCustomer = (Customer)CustomerLv.SelectedItem;
        }
        private void LoadData()
        {
            CustomerLv.ItemsSource = _customers = App.GetContext().Customers.ToList();
        }
    }
}
