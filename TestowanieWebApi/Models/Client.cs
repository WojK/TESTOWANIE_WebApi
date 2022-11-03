namespace TestowanieWebApi.Models
{
    public class Client       
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public ShoppingHistory ShoppingHistory { get; set; }

    }
}