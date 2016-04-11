using AseguradoraRESTUI.Models;
using AseguradoraRESTUI.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace AseguradoraRESTUI
{
    public partial class Clients
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void search_CLick(object sender, RoutedEventArgs e)
        {
            RefreshTable(TxtBoxSearch.Text);
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable("All");
        }

        private void RefreshTable(string text)
        {
            List<Client> client;
            if (!text.Equals("All"))
            {
                int idClient;
                Boolean idCheck = Int32.TryParse(TxtBoxSearch.Text, out idClient);

                if (idCheck)
                {
                    ClientServices cl = new ClientServices();
                    client = cl.Get(idClient);
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
                client = cl.Get();
                RemoveRows();
                AddRows(client);
            }
        }

        private void AddRows(List<Client> client)
        {
            var rg = new TableRowGroup();

            if (client[0].ID == -1)
            {
                MessageBox.Show("Error, there is no client in our database", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                for (var i = 0; i < client.Count; i++)
                {
                    var tR = new TableRow();
                    rg.Rows.Add(tR);

                    var id = new TableCell(new Paragraph(new Run((client[i].ID.ToString()))));
                    var dni = new TableCell(new Paragraph(new Run(client[i].DNI)));
                    var name = new TableCell(new Paragraph(new Run(client[i].Name)));

                    tR.Background = i%2 == 0 ? Brushes.LightGray : Brushes.White;

                    id.TextAlignment = TextAlignment.Center;
                    dni.TextAlignment = TextAlignment.Center;
                    name.TextAlignment = TextAlignment.Center;

                    tR.Cells.Add(id);
                    tR.Cells.Add(dni);
                    tR.Cells.Add(name);
                }
                TableClients.RowGroups.Add(rg);
                BtnEditar.IsEnabled = true;
            }
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
            EditClients ed = new EditClients();
            ed.Show();
        }

        private void enviar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            string dni = TxtBoxDni.Text;
            string name = TxtBoxName.Text;

            bool result = Int32.TryParse(TxtBoxId.Text, out id);

            if (!result)
            {
                MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            ClientServices cl = new ClientServices();
            string resp = cl.Post(id, dni, name);

            var dniFormatCheck = resp.Contains("DNI malformed");
            var dniLengthCheck = resp.Contains("longitud mínima de '9'");

            if (dniFormatCheck || dniLengthCheck)
            {
                MessageBox.Show("Error, the format of the DNI is 11111111A", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Added the new client to our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void wnBills_click(object sender, RoutedEventArgs e)
        {
            var bill = new Bills();
            bill.Show();
            Close();
        }

        private void wnContracts_click(object sender, RoutedEventArgs e)
        {
            var cont = new Contracts();
            cont.Show();
            Close();
        }
    }
}
