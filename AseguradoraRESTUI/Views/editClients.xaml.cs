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
    public partial class EditClients
    {
        public EditClients()
        {
            InitializeComponent();
        }

        private void editClient_initializated(object sender, EventArgs e)
        {
            ClientServices cl = new ClientServices();
            List<Client> client = cl.Get();
            foreach(Client person in client)
            {
                CboxId.Items.Add(person.Id);
            }
        }

        private void CboxIdChange(object sender, SelectionChangedEventArgs e)
        {
            ClientServices cl = new ClientServices();
            int idClient = Int32.Parse(CboxId.SelectedItem.ToString());
            List<Client> client = cl.Get(idClient);
            TxtDni.Text = client[0].Dni;
            TxtName.Text = client[0].Name;
            BtnAceptar.IsEnabled = true;
            BtnBorrar.IsEnabled = true;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(CboxId.SelectedItem.ToString());
            string dni = TxtDni.Text;
            string name = TxtName.Text;

            ClientServices cl = new ClientServices();
            String resp = cl.Put(id, dni, name);


            Boolean dniCheck = resp.Contains("DNI malformed");

            //No funciona
            if (dniCheck)
            {
                MessageBox.Show("Error, the format of the DNI is 11111111A", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Edited the client from our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            var cl = new ClientServices();
            var idClient = int.Parse(CboxId.SelectedItem.ToString());
            cl.Delete(idClient);
            MessageBox.Show("Deleted the client from our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
