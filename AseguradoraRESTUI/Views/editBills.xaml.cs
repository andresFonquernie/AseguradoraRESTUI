using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Bill> bills = bS.Get();
            int size = bills.Count;
            for (var i = 0; i < size; i++)
            {
                if (bills[i] != null)
                {
                    if (bills[i].Client != null)
                    {
                        if (bills[i].Client.Bills != null)
                        {
                            List<Bill> clBills = bills[i].Client.Bills;

                            for (var j = 0; j < clBills.Count; j++)
                            {
                                clBills[j].Client = bills[i].Client;
                                bills.Add(clBills[j]);
                            }
                        }
                    }
                }
            }
            List<Bill> SortedList = bills.OrderBy(Bill => Bill.ID).ToList();

            for (int i = 0; i < SortedList.Count; i++)
            {
                if (SortedList[i].Client != null)
                {
                    if (SortedList[i].ID > 0)
                    {
                        CboxId.Items.Add(SortedList[i].ID);
                    }
                }
            }
        }

        private void CboxIdChange(object sender, SelectionChangedEventArgs e)
        {
            BillServices bS = new BillServices();
            int idBill = Int32.Parse(CboxId.SelectedItem.ToString());
            List<Bill> bill = bS.Get(idBill);
            TxtNameClient.Content = bill[0].Client.Name;
            TxtMoney.Text = bill[0].moneyToPay.ToString();
            TxtIdClient.Text = bill[0].Client.ID.ToString();
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
 
            idClient = int.Parse(TxtIdClient.Text);

            checkNumber = int.TryParse(TxtMoney.Text, out money);
            if (!checkNumber)
            {
                MessageBox.Show("Error, the money must be a number", "Error with parameter: Money", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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
