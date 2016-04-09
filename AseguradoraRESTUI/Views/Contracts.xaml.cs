using AseguradoraRESTUI.Models;
using AseguradoraRESTUI.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace AseguradoraRESTUI
{
    public partial class Contracts
    {
        public Contracts()
        {
            InitializeComponent();
        }

        private void search_CLick(object sender, RoutedEventArgs e)
        {
            RefreshTable(TxtBoxId.Text);
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable("All");
        }

        private void RefreshTable(String text)
        {
            List<Contract> contracts;
            if (!text.Equals("All"))
            {
                int idContract;
                Boolean idCheck = Int32.TryParse(TxtBoxSearch.Text, out idContract);

                if (idCheck)
                {
                    ContractsServices cS = new ContractsServices();
                    contracts = cS.Get(idContract);
                    RemoveRows();
                    AddRows(contracts);
                }
                else
                {
                    MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                ContractsServices cS = new ContractsServices();
                contracts = cS.Get();
                RemoveRows();
                AddRows(contracts);
            }
        }

        private void AddRows(List<Contract> contract)
        {
            var rg = new TableRowGroup();

            for (int i = 0; i < contract.Count; i++)
            {
                TableRow tR = new TableRow();
                rg.Rows.Add(tR);

                TableCell id = new TableCell(new Paragraph(new Run((contract[i].Id.ToString()))));
                TableCell idClient = new TableCell(new Paragraph(new Run(contract[i].Client.Id.ToString())));
                TableCell date = new TableCell(new Paragraph(new Run(contract[i].Date.ToString(CultureInfo.CurrentCulture))));
                TableCell policy = new TableCell(new Paragraph(new Run(contract[i].Policy.Id.ToString())));


                if (i % 2 == 0)
                    tR.Background = Brushes.LightGray;
                else
                    tR.Background = Brushes.White;

                id.TextAlignment = TextAlignment.Center;
                idClient.TextAlignment = TextAlignment.Center;
                date.TextAlignment = TextAlignment.Center;
                policy.TextAlignment = TextAlignment.Center;

                tR.Cells.Add(idClient);
                tR.Cells.Add(id);
                tR.Cells.Add(date);
                tR.Cells.Add(policy);
            }
            TableContracts.RowGroups.Add(rg);
            BtnEditar.IsEnabled = true;
        }

        private void RemoveRows()
        {
            for (int i = 1; i < TableContracts.RowGroups.Count; i++)
            {
                TableContracts.RowGroups.Remove(TableContracts.RowGroups[i]);
            }
        }

        private void editContract_Click(object sender, RoutedEventArgs e)
        {
            EditContracts ed = new EditContracts();
            ed.Show();
        }

        private void enviar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int idClient;
            DateTime date = DateTime.Parse(DatePicker.Text);
            int idPolicy;
            bool checkNumber;

            checkNumber = Int32.TryParse(TxtBoxId.Text, out id);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            checkNumber = Int32.TryParse(TxtBoxIdClient.Text, out idClient);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID Client must be a number", "Error with parameter: ID Client", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            checkNumber = Int32.TryParse(TxtBoxPolicy.Text, out idPolicy);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID Policy must be a number", "Error with parameter: ID Policy", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            ContractsServices cnt = new ContractsServices();
            cnt.Post(idClient, id, date, idPolicy);
            //if (!added)
            //{
            //    MessageBox.Show("Error, your policy exists in the database", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
                MessageBox.Show("Added the new contract to our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }

        private void wnBills_click(object sender, RoutedEventArgs e)
        {
            Bills bill = new Bills();
            bill.Show();
            Close();
        }

        private void wnClients_click(object sender, RoutedEventArgs e)
        {
            Clients cl = new Clients();
            cl.Show();
            Close();
        }
    }
}
