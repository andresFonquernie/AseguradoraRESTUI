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
    public partial class editContracts : Window
    {
        public editContracts()
        {
            InitializeComponent();
        }

        private async void editContract_initializated(object sender, EventArgs e)
        {
            ContractsServices cS = new ContractsServices();
            List<Contract> contract = await cS.get();
            foreach(Contract cnt in contract)
            {
                cboxID.Items.Add(cnt.ID);
            }
        }

        private async void cboxIDChange(object sender, SelectionChangedEventArgs e)
        {
            ContractsServices cS = new ContractsServices();
            int idContract = Int32.Parse(cboxID.SelectedItem.ToString());
            List<Contract> contract = await cS.get(idContract);
            txtIDClient.Text = contract[0].Client.ID.ToString();
            dateDate.SelectedDate = contract[0].Date;
            txtIDPol.Text = contract[0].policy.ID.ToString();
            btnAceptar.IsEnabled = true;
            btnBorrar.IsEnabled = true;
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int idClient;
            DateTime date = DateTime.Parse(dateDate.Text);
            int idPolicy;
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

            checkNumber = Int32.TryParse(txtIDPol.Text, out idPolicy);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID Policy must be a number", "Error with parameter: ID Policy", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            ContractsServices cnt = new ContractsServices();
            await cnt.put(idClient, id, date, idPolicy);
            //if (!added)
            //{
            //    MessageBox.Show("Error, your policy exists in the database", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            MessageBox.Show("Added the new contract to our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            ContractsServices cS = new ContractsServices();
            int id = Int32.Parse(cboxID.SelectedItem.ToString());
            await cS.delete(id);
            MessageBox.Show("Contract deleted", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
