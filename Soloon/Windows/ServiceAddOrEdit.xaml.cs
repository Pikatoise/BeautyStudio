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
    /// Interaction logic for ServiceAddOrEdit.xaml
    /// </summary>
    public partial class ServiceAddOrEdit : Window
    {
        private bool isEdit;
        public ServiceAddOrEdit(Service service,bool isEdit = false)
        {
            InitializeComponent();
            DataContext = service;
            this.isEdit = isEdit;
        }

        private void btnSaveOrEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!isEdit)
            {
                App.DB.Services.Add(DataContext as Service);
            }
            App.DB.SaveChanges();

            Close();
        }
    }
}
