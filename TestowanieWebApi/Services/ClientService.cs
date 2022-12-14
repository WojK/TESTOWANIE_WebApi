using Microsoft.EntityFrameworkCore;
using TestowanieWebApi.Database;
using TestowanieWebApi.Models;
using System.ComponentModel.DataAnnotations;


namespace TestowanieWebApi.Services
{
    public class ClientService : IClientService
    {

        private readonly IClientContext _context;

        public ClientService(IClientContext context)
        {
            _context = context;
        }

        public ClientService()
        {
            _context = new ClientContext();
        }


        public Client AddClient(ClientDTO clientDTO)
        {
            if(clientDTO.Age <= 0)
            {
                throw new ArgumentException();
            }

            if(clientDTO.Name == null || clientDTO.Surname == null ||
                clientDTO.Gender == null || clientDTO.Country == null || clientDTO.Email == null)
            {
                throw new ArgumentException();
            }

            if (clientDTO.Gender != "Female" && clientDTO.Gender != "Male") {
                throw new ArgumentException();
            }

            if (!(new EmailAddressAttribute().IsValid(clientDTO.Email)))
            {
                throw new ArgumentException();
            }

            Client newClient = new Client()
            {
                Name = clientDTO.Name,
                Surname = clientDTO.Surname,
                Age = clientDTO.Age,
                Gender = clientDTO.Gender,
                Country = clientDTO.Country,
                Email = clientDTO.Email
            };

            _context.Add(newClient);
            _context.SaveChanges();

            return newClient;
        }

        public Client DeleteClient(int Id)
        {
            Client? client = _context.Find(Id);
            if (client == null)
            {
                throw new Exception("Not found client with id -> " + Id);
            }
            _context.Remove(client);
            _context.SaveChanges();
                return client;
        }

        public Client EditClient(int Id, ClientDTO clientDTO)
        {
            Client? client = _context.Find(Id);
            if (client == null)
            {
                throw new Exception("Not found client with id -> " + Id);
            }
            if (clientDTO.Age <= 0)
            {
                throw new ArgumentException("Client's age must be greater than 0");
            }
            if (clientDTO.Gender != "Female" && clientDTO.Gender != "Male")
            {
                throw new ArgumentException();
            }
            if (clientDTO.Name == null || clientDTO.Surname == null ||
                clientDTO.Gender == null || clientDTO.Country == null) {
                throw new ArgumentException();
            }

            client.Name = clientDTO.Name;
            client.Surname = clientDTO.Surname;
            client.Age = clientDTO.Age;
            client.Gender = clientDTO.Gender;
            client.Country = clientDTO.Country;
            _context.SaveChanges();

            return client;
        }

        public Client GetClient(int id)
        {
            Client? client = _context.Find(id);
            if (client == null)
            {
                throw new Exception("Not found client with id -> " + id);
            }

            return client;
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Set<Client>();
        }
    }
}
