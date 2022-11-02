using Microsoft.EntityFrameworkCore;
using TestowanieWebApi.Models;

namespace TestowanieWebApi.Database
{
	public interface IClientContext
	{

		public Client Find(int Id);
		void SaveChanges();
		public void Add(Client client);
		void Remove(Client client);
		IEnumerable<T> Set<T>();
	}
}
