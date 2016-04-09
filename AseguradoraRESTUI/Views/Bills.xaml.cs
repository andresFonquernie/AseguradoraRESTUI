using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using AseguradoraRESTUI.Models;
using AseguradoraRESTUI.Services;

namespace AseguradoraRESTUI
{
    public partial class Bills
    {
        public Bills()
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

        private void RefreshTable(String text)
        {
            List<Bill> bills;
            if (!text.Equals("All"))
            {
                int idBill;
                Boolean idCheck = Int32.TryParse(TxtBoxSearch.Text, out idBill);

                if (idCheck)
                {
                    BillServices bS = new BillServices();
                    bills = bS.Get(idBill);
                    AddRows(bills);
                }
                else
                {
                    MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                BillServices bS = new BillServices();
                bills = bS.Get();
                RemoveRows();
                AddRows(bills);
            }
        }

        private void AddRows(List<Bill> bill)
        {
            var rg = new TableRowGroup();

            for (int i = 0; i < bill.Count; i++)
            {
                TableRow tR = new TableRow();
                rg.Rows.Add(tR);

                TableCell id = new TableCell(new Paragraph(new Run((bill[i].Id.ToString()))));
                TableCell idClient = new TableCell(new Paragraph(new Run(bill[i].Client.Id.ToString())));
                TableCell money = new TableCell(new Paragraph(new Run(bill[i].MoneyToPay.ToString())));

                if (i % 2 == 0)
                    tR.Background = Brushes.LightGray;
                else
                    tR.Background = Brushes.White;

                id.TextAlignment = TextAlignment.Center;
                idClient.TextAlignment = TextAlignment.Center;
                money.TextAlignment = TextAlignment.Center;

                tR.Cells.Add(idClient);
                tR.Cells.Add(id);
                tR.Cells.Add(money);
            }
            TableBills.RowGroups.Add(rg);
            BtnEditar.IsEnabled = true;
        }

        private void RemoveRows()
        {
            for (int i = 1; i < TableBills.RowGroups.Count; i++)
            {
                TableBills.RowGroups.Remove(TableBills.RowGroups[i]);
            }
        }

        private void editBills_Click(object sender, RoutedEventArgs e)
        {
            EditBills ed = new EditBills();
            ed.Show();
        }

        private void enviar_Click(object sender, RoutedEventArgs e)
        {
            int idClient;
            int id;
            int money;
            bool checkNumber;

            checkNumber = Int32.TryParse(TxtBoxId.Text, out id);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID must be a number", "Error with parameter: ID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            checkNumber = Int32.TryParse(TxtBoxId.Text, out idClient);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the ID Client must be a number", "Error with parameter: ID Client", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            checkNumber = Int32.TryParse(TxtBoxMoney.Text, out money);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the money must be a number", "Error with parameter: Money", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            BillServices bs = new BillServices();
            bs.Post(idClient, id, money);

            //if (!added)
            //{
            //    MessageBox.Show("Error, your policy exists in the database", "Error adding to DB", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
                MessageBox.Show("Added the new Bill to our database", "Action completed", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }

        private void wnClients_click(object sender, RoutedEventArgs e)
        {
            Clients cl = new Clients();
            cl.Show();
            Close();
        }

        private void wnContracts_click(object sender, RoutedEventArgs e)
        {
            Contracts cont = new Contracts();
            cont.Show();
            Close();
        }
    }
}
