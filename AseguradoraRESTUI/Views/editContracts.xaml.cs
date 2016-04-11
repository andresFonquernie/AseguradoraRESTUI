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
    public partial class EditContracts
    {
        public EditContracts()
        {
            InitializeComponent();
        }

        private void editContract_initializated(object sender, EventArgs e)
        {
            ContractsServices cS = new ContractsServices();
            List<Contract> contracts = cS.Get();

            int size = contracts.Count;
            for (var i = 0; i < size; i++)
            {
                if (contracts[i] != null)
                {
                    if (contracts[i].client != null)
                    {
                        if (contracts[i].client.Contracts != null)
                        {
                            List<Contract> clContract = contracts[i].client.Contracts;

                            for (var j = 0; j < clContract.Count; j++)
                            {
                                clContract[j].client = contracts[i].client;
                                contracts.Add(clContract[j]);
                            }
                        }
                    }
                }
            }
            List<Contract> SortedList = contracts.OrderBy(Contract => Contract.ID).ToList();

            for (int i = 0; i < SortedList.Count; i++)
            {
                if (SortedList[i].client != null)
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
            ContractsServices cS = new ContractsServices();
            int idContract = Int32.Parse(CboxId.SelectedItem.ToString());
            List<Contract> contract = cS.Get(idContract);

            TxtIdClient.Content = contract[0].client.ID.ToString();
            DateDate.SelectedDate = contract[0].Date;
            TxtIdPol.Content = contract[0].policy.ID.ToString();

            BtnAceptar.IsEnabled = true;
            BtnBorrar.IsEnabled = true;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int idClient;
            int idPolicy;
            DateTime date = DateTime.Parse(DateDate.Text);
            date = date.AddDays(1);

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
