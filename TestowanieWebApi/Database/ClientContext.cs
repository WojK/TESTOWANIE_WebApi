using System;
using Microsoft.EntityFrameworkCore;
using TestowanieWebApi.Models;

namespace TestowanieWebApi.Database
{
    public class ClientContext : DbContext, IClientContext
    {

        public DbSet<Client> Clients { get; set; }


        public string DbPath { get; }


        public ClientContext()
        {
            DbPath = "./Database/Shop.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(p => p.ShoppingHistory)
                .WithOne(p => p.Client)
                .HasForeignKey<ShoppingHistory>(p => p.ClientForeignKey);
        }

        public Client? Find(int Id)
        {
            return Clients.Find(Id);
        }

        void IClientContext.SaveChanges()
        {
            SaveChanges();
        }

        public void Add(Client client)
        {
            Clients.Add(client);
        }

        public void Remove(Client client)
        {
            Clients.Remove(client);
        }

        IEnumerable<T> IClientContext.Set<T>()
        {
            return (IEnumerable<T>)Set<Client>();
        }
    }
}
