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
using KT4.ApplicationData;

namespace KT4
{
    /// <summary>
    /// Логика взаимодействия для AccessControlPage.xaml
    /// </summary>
    public partial class AccessControlPage : Page
    {
        public AccessControlPage()
        {
            InitializeComponent();
            currentFIOBox.Text = "Уварова Агрипина Валентиновна";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            FamiliaBox.Text = "";
            NameBox.Text = "";
            OthcestvoBox.Text = "";
            jobBox.Text = "";
            MessageBox.Show("Поля были очищены!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e) // добавление пользователя в БД
        {
            char[] charTOTrim = {'s' , 'y' , 'S' , 'O'};
            try
            {
                Пользователи userObj = new Пользователи()
                {
                    FIO = FamiliaBox.Text + "" + NameBox.Text + "" + OthcestvoBox.Text,
                    Gender = polBox.SelectedItem.ToString().Trim(charTOTrim),
                    UserType = jobBox.Text,
                    SecretWord = NameBox.Text + "S"
                };
                AppConnect.model0db.Пользователи.Add(userObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cancelButton_MouseDoubleClick(object sender, MouseButtonEventArgs e) // блокировка элементов
        {
            if (FamiliaBox.Text == "")
            {
            FamiliaBox.IsEnabled = false;
            NameBox.IsEnabled = false;
            OthcestvoBox.IsEnabled = false;
            polBox.IsEnabled = false;
            jobBox.IsEnabled = false;
            saveButton.IsEnabled = false;
            cancelButton.IsEnabled = false;
            }
            
        }
    }
}
