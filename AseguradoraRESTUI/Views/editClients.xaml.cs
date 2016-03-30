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
    public partial class editClients : Window
    {
        public editClients()
        {
            InitializeComponent();
        }

        private async void editClient_initializated(object sender, EventArgs e)
        {
            ClientServices cl = new ClientServices();
            List<Client> client = await cl.get();
            foreach(Client person in client)
            {
                cboxID.Items.Add(person.ID);
            }
        }

        private async void cboxIDChange(object sender, SelectionChangedEventArgs e)
        {
            ClientServices cl = new ClientServices();
            int idClient = Int32.Parse(cboxID.SelectedItem.ToString());
            List<Client> client = await cl.get(idClient);
            txtDNI.Text = client[0].DNI;
            txtName.Text = client[0].Name;
            btnAceptar.IsEnabled = true;
            btnBorrar.IsEnabled = true;
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            string dni = txtDNI.Text;
            string name = txtName.Text;

            bool result = Int32.TryParse(cboxID.SelectedItem.ToString(), out id);
            if (!result)
            {
                MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ClientServices cl = new ClientServices();
            String resp = await cl.put(id, dni, name);
            txtName.Text = resp;

            Boolean added = true;
            Boolean dniCheck = false;

            //No funciona
            if (dniCheck)
            {
                MessageBox.Show("Error, the format of the DNI is 11111111A", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!added)
            {
                MessageBox.Show("Error, your client exists in the database", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Edited the client from our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            ClientServices cl = new ClientServices();
            int idClient = Int32.Parse(cboxID.SelectedItem.ToString());
            await cl.delete(idClient);
            MessageBox.Show("Deleted the client from our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
