using MongoDB.Bson.Serialization.Attributes;

namespace LowBank.Api.Models
{
    public class Customer
    {
        [BsonId]
        public long Cpf { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public long Telefone { get; set; }

        public Account Account { get; set; }
    }
}
