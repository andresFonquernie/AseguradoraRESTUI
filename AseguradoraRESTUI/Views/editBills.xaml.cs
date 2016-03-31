using AseguradoraRESTUI.Models;
using AseguradoraRESTUI.Services;
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

namespace AseguradoraRESTUI.Views
{
    /// <summary>
    /// Lógica de interacción para editClients.xaml
    /// </summary>
    public partial class editBills : Window
    {
        public editBills()
        {
            InitializeComponent();
        }

        private async void editBills_initializated(object sender, EventArgs e)
        {
            BillServices bS = new BillServices();
            List<Bill> bill = await bS.get();
            foreach(Bill b in bill)
            {
                cboxID.Items.Add(b.ID);
            }
        }

        private async void cboxIDChange(object sender, SelectionChangedEventArgs e)
        {
            BillServices bS = new BillServices();
            int idBill = Int32.Parse(cboxID.SelectedItem.ToString());
            List<Bill> bill = await bS.get(idBill);
            txtIDClient.Text = bill[0].Client.ID.ToString();
            txtMoney.Text = bill[0].moneyToPay.ToString();
            btnAceptar.IsEnabled = true;
            btnBorrar.IsEnabled = true;
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            BillServices bill = new BillServices();

            int idClient;
            int id;
            int money;
            bool checkNumber;

            checkNumber = Int32.TryParse(cboxID.SelectedItem.ToString(), out id);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            checkNumber = Int32.TryParse(txtIDClient.Text, out idClient);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID Client must be a number", "Error with parameter: ID Client", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            checkNumber = Int32.TryParse(txtMoney.Text, out money);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the money must be a number", "Error with parameter: Money", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            BillServices bs = new BillServices();
            String resp = await bs.put(idClient, id, money);
            txtIDClient.Text = resp;

            //if (!added)
            //{
            //    MessageBox.Show("Error, your policy exists in the database", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            //    MessageBox.Show("Added the new Bill to our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            BillServices bill = new BillServices();
            int id = Int32.Parse(cboxID.SelectedItem.ToString());
            await bill.delete(id);
            this.Close();
        }
    }
}
