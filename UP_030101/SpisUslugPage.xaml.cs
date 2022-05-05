using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UP_030101
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static beauty_saloonEn DataEntitiesEmployee { get; set; }
        ObservableCollection<Service> ListServise;
        public Page1()
        {
            var listTitle = new Service();
            this.Resources.Add(listTitle, "ListTitle");
            DataEntitiesEmployee = new beauty_saloonEn();
            InitializeComponent();
            ListServise = new ObservableCollection<Service>();
        }
        private void GetEmployees()
        {
            var servises = DataEntitiesEmployee.Service;
            var queryEmployee = from employee in servises
                                orderby employee.Title
                                select employee;
            foreach (Service emp in queryEmployee)
            {
                ListServise.Add(emp);
            }
            ListBoxEmployee.ItemsSource = ListServise;
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GetEmployees();
            ListBoxEmployee.SelectedIndex = 0;
        }
    }
}
