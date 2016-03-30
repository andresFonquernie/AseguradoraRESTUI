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
    class ClientServices
    {
        public Task<List<Client>> get()
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Clients/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Client> clientList = deserial.Deserialize<List<Client>>(response);
            return Task.FromResult <List<Client>> (clientList);
        }

        public Task<List<Client>> get(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Clients/{id}", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            var response = client.Execute(request);

            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
            List<Client> clientList = deserial.Deserialize<List<Client>>(response);
            return Task.FromResult<List<Client>>(clientList);
        }

        public Task<string> post(int id, string dni, string Name)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Clients/", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { ID = id, name = Name, DNI = dni }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return Task.FromResult<string>(content);
        }

        public Task<string> put(int id, string dni, string Name)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Clients/{id}", Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            request.AddBody(new { name = Name, DNI = dni }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return Task.FromResult<string>(content);
        }

        public Task<string> delete(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/Clients/{id}", Method.DELETE);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);

            var response = client.Execute(request);
            var content = response.Content;
            return Task.FromResult<string>(content);
        }
    }
}
