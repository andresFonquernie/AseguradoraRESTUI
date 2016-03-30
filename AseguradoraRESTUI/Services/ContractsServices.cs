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
    class ContractsServices
    {
        public Task<List<Contract>> get()
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Contracts/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Contract> contractList = deserial.Deserialize<List<Contract>>(response);
            return Task.FromResult<List<Contract>>(contractList);
        }

        public Task<List<Contract>> get(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Contracts/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Contract> contractList = deserial.Deserialize<List<Contract>>(response);
            return Task.FromResult<List<Contract>>(contractList);
        }

        public async Task<String> post(int idClient, int id, DateTime date, int policy)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Contracts/", Method.POST);

            Client cl = await getClients(idClient);

            Policy p = new Policy();
            p.ID = policy;
            p.name = "Hogar";
            p.description = "Para el hogar";
            p.type = "Del bueno";

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { ID = id, Date = date, client = cl, policy = p }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public async Task<String> put(int idClient, int id, DateTime date, int policy)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Contracts/{id}", Method.PUT);

            Client cl = await getClients(idClient);

            Policy p = new Policy();
            p.ID = policy;
            p.name = "Hogar";
            p.description = "Para el hogar";
            p.type = "Del bueno";

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            request.AddBody(new { ID = id, Date = date, client = cl, policy = p }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public Task<string> delete(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Contracts/{id}", Method.DELETE);

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
