using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data.Linq;
using System.Configuration;
using System.Data;
using static Manager_Linq.Model;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Data.Entity;

namespace Manager_Linq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        DataContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new DataContext(connectionString);

            var users = db.GetTable<Model.Users>().ToList();

            dataGridUsers.ItemsSource = users;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool CanAddPhone()
        {
            return !string.IsNullOrEmpty(textBoxSurName.Text)
                && !string.IsNullOrEmpty(textBoxName.Text)
                && !string.IsNullOrEmpty(textBoxPobatkovi.Text)
                && !string.IsNullOrEmpty(textBoxEmail.Text)
                 && int.TryParse(textBoxPhone.Text, out int phoneValue);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAddPhone())
            {
                MessageBox.Show("Заповніть всі поля перед додаванням запису!", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DateTime dateOfBirth = (DateTime)datePicker1.SelectedDate;

            int phoneValue;
            if (!int.TryParse(textBoxPhone.Text, out phoneValue))
            {
                MessageBox.Show("Введіть правильний номер телефона", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!DateTime.TryParse(datePicker1.Text, out dateOfBirth))
            {
                MessageBox.Show("Некоректна дата народження", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          

            var existingUser = db.GetTable<Model.Users>().FirstOrDefault(u => u.LSurname == textBoxSurName.Text 
            && u.LName == textBoxName.Text && u.LPobatkovi == textBoxPobatkovi.Text);

            if (existingUser != null)
            {
                MessageBox.Show("Користувач з такими ПІБ вже існує", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (db.GetTable<Model.Users>().Any(u => u.LEmail == textBoxEmail.Text))
            {
                MessageBox.Show("Користувач із таким email вже існує", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = new Model.Users
            {
                LSurname = textBoxSurName.Text,
                LName = textBoxName.Text,
                LPobatkovi = textBoxPobatkovi.Text,
                LEmail = textBoxEmail.Text,
                LPhone = phoneValue,
                LDateBrith = dateOfBirth
            };

            db.GetTable<Model.Users>().InsertOnSubmit(user);
            db.SubmitChanges();

            dataGridUsers.ItemsSource = db.GetTable<Model.Users>().ToList();

            MessageBox.Show("Користувач успішно доданий", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dataGridUsers.SelectedItem != null)
            {
                Model.Users selectedUsers = dataGridUsers.SelectedItem as Model.Users;

                if(selectedUsers != null) 
                {
                    textBoxSurName.Text = selectedUsers.LSurname;
                    textBoxName.Text = selectedUsers.LName;
                    textBoxPobatkovi.Text = selectedUsers.LPobatkovi;
                    textBoxEmail.Text = selectedUsers.LEmail;
                    int phoneValue;
                    if (int.TryParse(selectedUsers.LPhone.ToString(), out phoneValue))
                    {
                        textBoxPhone.Text = phoneValue.ToString();
                    }
                    else
                    {
                        // Обробка помилки перетворення
                    }
                    datePicker1.SelectedDate = selectedUsers.LDateBrith;
                }
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridUsers.SelectedItem != null)
            {
                Model.Users selectedUsers = dataGridUsers.SelectedItem as Model.Users;
                if(selectedUsers != null)
                {
                    if (!string.IsNullOrEmpty(textBoxSurName.Text) && !string.IsNullOrEmpty(textBoxName.Text) &&
               !string.IsNullOrEmpty(textBoxPobatkovi.Text) && !string.IsNullOrEmpty(textBoxEmail.Text) &&
               int.TryParse(textBoxPhone.Text, out int phone) && datePicker1.SelectedDate != null)
                    {
                        selectedUsers.LSurname = textBoxSurName.Text;
                        selectedUsers.LName = textBoxName.Text;
                        selectedUsers.LPobatkovi = textBoxPobatkovi.Text;
                        selectedUsers.LEmail = textBoxEmail.Text;
                        selectedUsers.LPhone = phone;
                        selectedUsers.LDateBrith = (DateTime)datePicker1.SelectedDate;
                        using (var db = new DataContext(connectionString))
                        {
                            db.SubmitChanges();
                        }
                        dataGridUsers.ItemsSource = db.GetTable<Model.Users>().ToList();

                        MessageBox.Show("Користувач успішно змінено", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Неможливо оновити запис. Перевірте, чи всі поля заповнені та вибрано запис в таблиці.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
               MessageBox.Show("Неможливо оновити запис. Перевірте, чи всі поля заповнені та вибрано запис в таблиці.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
