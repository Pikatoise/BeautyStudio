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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Soloon.Windows
{
    /// <summary>
    /// Interaction logic for ClientServiceAddOrEdit.xaml
    /// </summary>
    public partial class ClientServiceAddOrEdit : Window
    {
        private bool isEdit;
        public ClientServiceAddOrEdit(ClientService clientService, bool isEdit = false)
        {
            InitializeComponent();
            this.isEdit = isEdit;
            DataContext = clientService;

            foreach (var item in App.DB.Clients.ToList())
                cmbClient.Items.Add(item.LastName +" "+ item.FirstName + " "+item.Patronymic);

            foreach (var item in App.DB.Services.ToList())
                cmbService.Items.Add(item.Title);
            if (isEdit)
            {
                cmbClient.Text = clientService.ClientStr;
                cmbService.Text = clientService.ServiceStr;
            }



        }

        private void btnSaveOrEdit_Click(object sender, RoutedEventArgs e)
        {
            ClientService clientService = DataContext as ClientService;
            clientService.ClientStr = cmbClient.Text;
            clientService.ServiceStr = cmbService.Text;

            if (!isEdit)
                App.DB.ClientServices.Add(clientService);
            App.DB.SaveChanges();

            Close();
        }
    }
}
