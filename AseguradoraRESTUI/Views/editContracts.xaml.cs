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
    public partial class EditContracts
    {
        public EditContracts()
        {
            InitializeComponent();
        }

        private void editContract_initializated(object sender, EventArgs e)
        {
            ContractsServices cS = new ContractsServices();
            List<Contract> contract = cS.Get();
            foreach(Contract cnt in contract)
            {
                CboxId.Items.Add(cnt.Id);
            }
        }

        private void CboxIdChange(object sender, SelectionChangedEventArgs e)
        {
            ContractsServices cS = new ContractsServices();
            int idContract = Int32.Parse(CboxId.SelectedItem.ToString());
            List<Contract> contract = cS.Get(idContract);

            TxtIdClient.Content = contract[0].Client.Id.ToString();
            DateDate.SelectedDate = contract[0].Date;
            TxtIdPol.Content = contract[0].Policy.Id.ToString();

            BtnAceptar.IsEnabled = true;
            BtnBorrar.IsEnabled = true;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int idClient;
            int idPolicy;
            DateTime date = DateTime.Parse(DateDate.Text);
            Console.WriteLine(date);
            date = date.AddDays(1);
            Console.WriteLine(date);

            id = Int32.Parse(CboxId.SelectedItem.ToString());
            idClient = Int32.Parse(TxtIdClient.Content.ToString());
            idPolicy = Int32.Parse(TxtIdPol.Content.ToString());


            ContractsServices cnt = new ContractsServices();
            cnt.Put(idClient, id, date, idPolicy);
            MessageBox.Show("Edited the contract from our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            ContractsServices cS = new ContractsServices();
            int id = Int32.Parse(CboxId.SelectedItem.ToString());
            cS.Delete(id);
            MessageBox.Show("Contract deleted", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
