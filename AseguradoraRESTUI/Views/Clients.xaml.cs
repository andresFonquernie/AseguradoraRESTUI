using AseguradoraRESTUI.Models;
using AseguradoraRESTUI.Services;
using AseguradoraRESTUI.Views;
using RestSharp;
using RestSharp.Deserializers;
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


namespace AseguradoraRESTUI
{
    public partial class Clients : Window
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void search_CLick(object sender, RoutedEventArgs e)
        {
            refreshTable(txtBoxSearch.Text);
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            refreshTable("All");
        }

        private async void refreshTable(String text)
        {
            List<Client> client;
            if (!text.Equals("All"))
            {
                int idClient;
                Boolean idCheck = Int32.TryParse(txtBoxSearch.Text, out idClient);

                if (idCheck)
                {
                    ClientServices cl = new ClientServices();
                    client = await cl.get(idClient);
                    RemoveRows();
                    AddRows(client);
                }
                else
                {
                    MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                ClientServices cl = new ClientServices();
                client = await cl.get();
                RemoveRows();
                AddRows(client);
            }
        }

        private void AddRows(List<Client> client)
        {
            var rg = new TableRowGroup();

            for (int i=0; i<client.Count; i++)
            {
                TableRow tR = new TableRow();
                rg.Rows.Add(tR);

                TableCell id = new TableCell(new Paragraph(new Run((client[i].ID.ToString()))));
                TableCell dni = new TableCell(new Paragraph(new Run(client[i].DNI.ToString())));
                TableCell name = new TableCell(new Paragraph(new Run(client[i].Name)));

                if (i % 2 == 0)
                    tR.Background = Brushes.LightGray;
                else
                    tR.Background = Brushes.White;

                id.TextAlignment = TextAlignment.Center;
                dni.TextAlignment = TextAlignment.Center;
                name.TextAlignment = TextAlignment.Center;

                tR.Cells.Add(id);
                tR.Cells.Add(dni);
                tR.Cells.Add(name);
            }
            TableClients.RowGroups.Add(rg);
            btnEditar.IsEnabled = true;
        }

        private void RemoveRows()
        {
            for (int i = 1; i < TableClients.RowGroups.Count; i++)
            {
                TableClients.RowGroups.Remove(TableClients.RowGroups[i]);
            }
        }

        private void editClient_Click(object sender, RoutedEventArgs e)
        {
            editClients ed = new editClients();
            ed.Show();
        }

        private async void enviar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            string dni = txtBoxDNI.Text;
            string name = txtBoxName.Text;

            bool result = Int32.TryParse(txtBoxID.Text, out id);
            if (!result)
            {
                MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            ClientServices cl = new ClientServices();
            await cl.post(id, dni, name);

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
                MessageBox.Show("Added the new client to our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void wnBills_click(object sender, RoutedEventArgs e)
        {
            Bills bill = new Bills();
            bill.Show();
            this.Close();
        }

        private void wnContracts_click(object sender, RoutedEventArgs e)
        {
            Contracts cont = new Contracts();
            cont.Show();
            this.Close();
        }
    }
}
