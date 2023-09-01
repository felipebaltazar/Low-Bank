using MongoDB.Bson.Serialization.Attributes;

namespace Low_Bank.Api
{
    public class Customer
    {
        public string Nome { get; set; }

        [BsonId]
        public string Cpf { get; set; }

        public string Password { get; set; }

        public int Conta { get; set; }

    }
}
