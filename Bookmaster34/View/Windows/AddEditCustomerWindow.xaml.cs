using Bookmaster34.AppData;
using Bookmaster34.Models;
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
using System.Windows.Shapes;

namespace Bookmaster34.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCustomerWindow.xaml
    /// </summary>
    public partial class AddEditCustomerWindow : Window
    {
        private List<City> _cities;
        public AddEditCustomerWindow()
        {
            InitializeComponent();

            _cities = App.GetContext().Cities.ToList();

            LoadCities();

            Title = "Добавление читателя";
            AddBtn.Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Collapsed;

        }
        public AddEditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();

            _cities = App.GetContext().Cities.ToList();

            LoadCities();

            
            Title = "Редактировать читателя";
            AddBtn.Visibility = Visibility = Visibility.Collapsed;
            EditBtn.Visibility = Visibility.Collapsed;

            CustomerIDTb.Text = selectedCustomer.Id;
        }
        
        private string GenerateId()
        {
            int lastId= Convert.ToInt32(App.GetContext().Customers.Max(x => x.Id).Substring(1));//=>"C1015"=>"1015"=>1015
            ++lastId;//=>1015+1=>1016
            return $"C{lastId}";//"C1016"
        }

        private void AddCustomer()
        {
            try
            {
                //Проверяем заполнение всех полей.
                if (string.IsNullOrWhiteSpace(NameTb.Text)||
                    string.IsNullOrWhiteSpace(AddressTb.Text) || 
                    string.IsNullOrWhiteSpace(PhoneTb.Text) || 
                    string.IsNullOrWhiteSpace(EmailTb.Text))
                {
                    FeedbackService.Warning("Заполните все поля!");
                }
                else
                {
                    //При заполнении всех полей реализуем добавление.
                    Customer newCustomer = new Customer()
                    {
                        Id = CustomerIDTb.Text,
                        Name = NameTb.Text,
                        Address = AddressTb.Text,
                        CityId = (int)CustomerCityCmb.SelectedValue,
                        Phone = PhoneTb.Text,
                        Email = EmailTb.Text,
                        Zip = CustomerIDTb.Text
                    };

                    App.GetContext().Customers.Add(newCustomer);

                    App.GetContext().SaveChanges();

                    FeedbackService.Information("Читатель успешно добавлен!");

                    DialogResult= true;
                }
             }
            catch (Exception exception)
            {
                FeedbackService.Error(exception);
            }
           
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
           DialogResult = false;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LoadCities()
        {
            CustomerCityCmb.ItemsSource = _cities;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }
    }
}
