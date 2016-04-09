using AseguradoraRESTUI.Models;
using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace AseguradoraRESTUI.Services
{
    class ClientServices
    {
        public List<Client> Get()
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ClientsAsync/", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Client> clientList = deserial.Deserialize<List<Client>>(response);
            return clientList;
        }

        public List<Client> Get(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ClientsAsync/{id}", Method.GET);

            // execute the request
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);
            var response = client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            List<Client> clientList = deserial.Deserialize<List<Client>>(response);
            return clientList;
        }

        public string Post(int id, string dni, string name)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ClientsAsync/", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { ID = id, name, DNI = dni }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public string Put(int id, string dni, string name)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ClientsAsync/{id}", Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddBody(new {ID = id, name, DNI = dni }); // uses JsonSerializer

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public string Delete(int id)
        {
            var client = new RestClient(" http://localhost:52558/");
            var request = new RestRequest("api/ClientsAsync/{id}", Method.DELETE);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("id", id);

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
    }
}
