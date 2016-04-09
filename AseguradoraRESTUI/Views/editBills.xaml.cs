using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AseguradoraRESTUI.Models;
using AseguradoraRESTUI.Services;

namespace AseguradoraRESTUI
{
    /// <summary>
    /// Lógica de interacción para editClients.xaml
    /// </summary>
    public partial class EditBills
    {
        public EditBills()
        {
            InitializeComponent();
        }

        private void editBills_initializated(object sender, EventArgs e)
        {
            BillServices bS = new BillServices();
            List<Bill> bill = bS.Get();
            foreach(Bill b in bill)
            {
                CboxId.Items.Add(b.Id);
            }
        }

        private void CboxIdChange(object sender, SelectionChangedEventArgs e)
        {
            BillServices bS = new BillServices();
            int idBill = Int32.Parse(CboxId.SelectedItem.ToString());
            List<Bill> bill = bS.Get(idBill);
            TxtIdClient.Content = bill[0].Client.Id.ToString();
            TxtMoney.Text = bill[0].MoneyToPay.ToString();
            BtnAceptar.IsEnabled = true;
            BtnBorrar.IsEnabled = true;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            int idClient;
            int money;
            int id;

            bool checkNumber;

            id = int.Parse(CboxId.SelectedItem.ToString());
 
            idClient = int.Parse(TxtIdClient.Content.ToString());

            checkNumber = int.TryParse(TxtMoney.Text, out money);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the money must be a number", "Error with parameter: Money", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Console.WriteLine(@"IDDDDD: " + idClient);

            BillServices bs = new BillServices();
            bs.Put(idClient, id, money);

            MessageBox.Show("Edited the Bill from our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            BillServices bill = new BillServices();
            int id = Int32.Parse(CboxId.SelectedItem.ToString());
            bill.Delete(id);
            Close();
        }
    }
}
