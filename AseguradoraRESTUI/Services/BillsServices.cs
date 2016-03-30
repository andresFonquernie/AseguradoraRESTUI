using AseguradoraRESTUI.Models;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraRESTUI.Services
{
    class BillServices
    {
        public Task<List<Bill>> get()
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Bills/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Bill> billList = deserial.Deserialize<List<Bill>>(response);
            return Task.FromResult<List<Bill>>(billList);
        }

        public Task<List<Bill>> get(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Bills/{id}", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Bill> billList = deserial.Deserialize<List<Bill>>(response);
            return Task.FromResult<List<Bill>>(billList);
        }

        public async Task<string> post(int idClient, int id, int money)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Bills/", Method.POST);

            Client cl = await getClients(idClient);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { ID = id, moneyToPay = money, Client = cl }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public async Task<String> put(int idClient, int id, int money)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Bills/{id}", Method.PUT);

            Client cl = await getClients(idClient);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            request.AddBody(new { ID = id, moneyToPay = money, Client = cl }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public Task<string> delete(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Bills/{id}", Method.DELETE);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);

            var response = client.Execute(request);
            var content = response.Content;
            return Task.FromResult<string>(content);
        }

        public async Task<Client> getClients(int idClient)
        {
            ClientServices clS = new ClientServices();
            List<Client> lc = await clS.get(idClient);

            Client client = new Client();
            client.ID = lc[0].ID;
            client.DNI = lc[0].DNI;
            client.Name = lc[0].Name;

            return client;
        }
    }
}
