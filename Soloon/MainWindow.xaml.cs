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
using Soloon.Windows;

namespace Soloon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshAll();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ServiceAddOrEdit serviceAddOrEdit = new ServiceAddOrEdit(new Service());
            serviceAddOrEdit.ShowDialog();

            RefreshAll();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ServiceAddOrEdit serviceAddOrEdit = new ServiceAddOrEdit(dgServise.SelectedItem as Service,true);
            serviceAddOrEdit.ShowDialog();

            RefreshAll();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            App.DB.Services.Remove(dgServise.SelectedItem as Service);
            App.DB.SaveChanges();

            RefreshAll();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            ClientAddOrEdit clientAddOrEdit = new ClientAddOrEdit(new Client());
            clientAddOrEdit.ShowDialog();

            RefreshAll();
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            ClientAddOrEdit clientAddOrEdit = new ClientAddOrEdit(dgClient.SelectedItem as Client,true);
            clientAddOrEdit.ShowDialog();

            RefreshAll();
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            App.DB.Clients.Remove(dgClient.SelectedItem as Client);
            App.DB.SaveChanges();

            RefreshAll();
        }
        private void RefreshAll()
        {
            dgServise.ItemsSource = null;
            dgServise.ItemsSource = App.DB.Services.ToList();

            dgClient.ItemsSource = null;
            dgClient.ItemsSource = App.DB.Clients.ToList();

            dgClientService.ItemsSource = null;
            dgClientService.ItemsSource = App.DB.ClientServices.ToList();
        }
        private void btnAddClientService_Click(object sender, RoutedEventArgs e)
        {
            ClientServiceAddOrEdit clientServiceAddOrEdit = new ClientServiceAddOrEdit(new ClientService());
            clientServiceAddOrEdit.ShowDialog();

            RefreshAll();
        }

        private void btnEditClientService_Click(object sender, RoutedEventArgs e)
        {
            ClientServiceAddOrEdit clientServiceAddOrEdit = new ClientServiceAddOrEdit(dgClientService.SelectedItem as ClientService,true);
            clientServiceAddOrEdit.ShowDialog();

            RefreshAll();
        }

        private void btnDeleteClientService_Click(object sender, RoutedEventArgs e)
        {
            App.DB.ClientServices.Remove(dgClientService.SelectedItem as ClientService);
            App.DB.SaveChanges();

            RefreshAll();
        }
    }
}
