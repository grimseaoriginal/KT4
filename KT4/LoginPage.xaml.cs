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
using System.Data.OleDb;
using System.Data;
using System.Data.Odbc;
using KT4.ApplicationData;

namespace KT4
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {      

        public LoginPage()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();                           
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;
            try
            {
                var userObj = AppConnect.model0db.Пользователи.FirstOrDefault(x => x.Login == loginBox.Text && x.Password == passBox.Text);
                if (loginBox.Text == "Agripina17" && passBox.Text == "obdxbosmqa" && SecretWordBox.Text == "Сова") // авторизация
                {
                    this.NavigationService.Navigate(new Uri("AccessControlPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (userObj!=null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (n) // заглушка, потому что не могу получить доступ к sql на данный момент
                    {
                        case 1:MessageBox.Show("Здравствуйте, Администратор " + userObj.FIO + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.NavigationService.Navigate(new Uri("AccessControlPage.xaml", UriKind.Relative));
                            break;
                    }
                }
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}