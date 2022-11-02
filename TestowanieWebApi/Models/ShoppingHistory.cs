namespace TestowanieWebApi.Models
{
    public class ShoppingHistory
    {

        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public int ClientForeignKey { get; set; }
        public Client Client { get; set; }
    }
}
