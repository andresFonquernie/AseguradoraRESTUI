using AseguradoraRESTUI.Models;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace AseguradoraRESTUI.Services
{
    class ContractsServices
    {
        public List<Contract> Get()
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ContractsAsync/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Contract> contractList = deserial.Deserialize<List<Contract>>(response);

            if (contractList.Count == 0)
            {
                contractList = new List<Contract>();
                Contract c = new Contract();
                c.ID = -1;
                contractList.Add(c);
            }

            Console.WriteLine(response.Content);
            return contractList;
        }

        public List<Contract> Get(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ContractsAsync/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Contract> contractList;

            try
            {
                contractList = deserial.Deserialize<List<Contract>>(response);
            }
            catch (Exception)
            {
                contractList = new List<Contract>();
                Contract c = new Contract();
                c.ID = -1;
                contractList.Add(c);
            }

            return contractList;
        }

        public String Post(int idClient, DateTime date, int policy)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ContractsAsync/", Method.POST);

            Client cl = GetClients(idClient);
            string content;

            if (cl == null)
            {
                content = "Client Error";
            }

            else
            {
                Policy p = new Policy();
                p.ID = policy;
                p.name = "Hogar";
                p.description = "Para el hogar";
                p.type = "Del bueno";
                int id = policy;

                request.RequestFormat = DataFormat.Json;
                request.AddBody(new {ID = id, Date = date, client = cl, policy = p}); // uses JsonSerializer

                var response = client.Execute(request);
                Console.Write(response.Content);
                content = response.Content;
            }
            return content;
        }

        public string Put(int idClient, int id, DateTime date, int policy)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ContractsAsync/{id}", Method.PUT);

            Client cl = GetClients(idClient);

            Policy p = new Policy();
            p.ID = policy;
            p.name = "Hogar";
            p.description = "Para el hogar";
            p.type = "Del bueno";

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddBody(new { ID = id, Date = date, client = cl, policy = p }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public string Delete(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ContractsAsync/{id}", Method.DELETE);

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
                Console.Write("TENEMOS CLIENTE");
                client.ID = lc[0].ID;
                client.DNI = lc[0].DNI;
                client.Name = lc[0].Name;
            }

            return client;
        }
    }
}
