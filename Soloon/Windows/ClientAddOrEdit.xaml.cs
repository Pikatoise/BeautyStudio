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

namespace Soloon.Windows
{
    /// <summary>
    /// Interaction logic for ClientAddOrEdit.xaml
    /// </summary>
    public partial class ClientAddOrEdit : Window
    {
        private bool isEdit;
        public ClientAddOrEdit(Client client, bool isEdit = false)
        {
            InitializeComponent();
            this.isEdit = isEdit;
            DataContext = client;
        }

        private void btnSaveOrEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!isEdit)
                App.DB.Clients.Add(DataContext as Client);
            App.DB.SaveChanges();

            Close();
        }
    }
}
