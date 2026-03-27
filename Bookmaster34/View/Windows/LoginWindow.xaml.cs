using Bookmaster34.AppData;
using Bookmaster34.Models;
using System.Windows;

namespace Bookmaster34.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {

                Administrator administrator = App.GetContext().Administrators.FirstOrDefault(
                    administrator => administrator.Username == LoginTb.Text && administrator.Password ==
                    PasswordPb.Password);
                if (administrator != null)
                {
                    if (RememberMeCb.IsChecked == true) CredentialsService.SaveCredentials(LoginTb.Text, PasswordPb.Password);
                    else CredentialsService.ClearCredentials();
                        FeedbackService.Information("Успешная авторизация.");

                    // DialogResult возвращает результат работы диалогового окна
                    DialogResult = true;
                }

                else
                {
                    FeedbackService.Error("Пользователь не найден.");
                }
                CredentialsService.Administrator = administrator;
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                FeedbackService.Warning("Введите логин.");
                LoginTb.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
            {
                FeedbackService.Warning("Введите пароль.");
                PasswordPb.Focus();
                return false;
            }
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CredentialsService.AutoLogin && !string.IsNullOrWhiteSpace(CredentialsService.SavedLogin))
            {
                LoginTb.Text = CredentialsService.SavedLogin;
                PasswordPb.Password = CredentialsService.SavedPassword;
                RememberMeCb.IsChecked = CredentialsService.AutoLogin;
            }
        }
    }
}
