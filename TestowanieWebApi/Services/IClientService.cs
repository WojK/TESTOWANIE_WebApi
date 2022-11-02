using TestowanieWebApi.Models;

namespace TestowanieWebApi.Services
{
    public interface IClientService
    {
        public IEnumerable<Client> GetClients();

        public Client GetClient(int id);

        public Client AddClient(ClientDTO clientDto);

        public Client EditClient(int Id, ClientDTO clientDto);

        public Client DeleteClient(int Id);
    }
}
