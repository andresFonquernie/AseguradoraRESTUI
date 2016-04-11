using System;
using AseguradoraRESTUI.Models;
using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace AseguradoraRESTUI.Services
{
    class BillServices
    {
        public List<Bill> Get()
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/BillsAsync/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Bill> billList = deserial.Deserialize<List<Bill>>(response);

            if (billList.Count == 0)
            {
                billList = new List<Bill>();
                Bill b = new Bill();
                b.ID = -1;
                billList.Add(b);
            }

            return billList;
        }

        public List<Bill> Get(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/BillsAsync/{id}", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Bill> billList;

            try
            {
                billList = deserial.Deserialize<List<Bill>>(response);
            }
            catch (Exception)
            {
                billList = new List<Bill>();
                Bill b = new Bill();
                b.ID = -1;
                billList.Add(b);
            }

            return billList;
        }

        public string Post(int idClient, int money)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/BillsAsync/", Method.POST);

            string content;

            Client cl = GetClients(idClient);

            if (cl == null)
            {
                content = "Client Error";
            }

            else
            {
                int id = 1;
                request.RequestFormat = DataFormat.Json;
                request.AddBody(new { ID = id, moneyToPay = money, Client = cl }); // uses JsonSerializer

                var response = client.Execute(request);
                content = response.Content;
            }
            
            return content;
        }

        public string Put(int idClient, int id, int money)
        {

            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/BillsAsync/{id}", Method.PUT);

            // execute the request
            request.RequestFormat = DataFormat.Json;

            Client cl = GetClients(idClient);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddBody(new { ID = id, moneyToPay = money, Client = cl }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public string Delete(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/BillsAsync/{id}", Method.DELETE);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public Client GetClients(int idClient)
        {
            ClientServices clS = new ClientServices();
            List<Client> lc = clS.Get(idClient);

            Client client = new Client();

            if (lc[0].ID == -1)
                client = null;
            else
            {
                client.ID = lc[0].ID;
                client.DNI = lc[0].DNI;
                client.Name = lc[0].Name;
            }

            return client;
        }
    }
}
