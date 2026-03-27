using Bookmaster34.Models;
using Bookmaster34.View.Windows;
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
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        // Создаем локальный список для единоразового вытягивания данных из таблицы БД
        private readonly List<Book> _books;

        // Создаем поле для хранения выбранной книги;
        private Book _selectedBook;

        public BrowseCatalogPage()
        {
            InitializeComponent();

            // Заполняем локальный список
            _books = App.GetContext().Books.ToList();

            LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadData()
        {
            BookAuthorsLv.ItemsSource = _books;

        }

        private void BookAuthorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookAuthorsLv.SelectedItem;

            BookDetailsGrid.DataContext = _selectedBook;
        }

        private void BookAuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null)
            {
                BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow(_selectedBook.BookAuthors);
                bookAuthorsDetailsWindow.ShowDialog();
            }
        }
    }
}
