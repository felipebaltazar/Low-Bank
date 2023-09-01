using Microsoft.AspNetCore.Mvc;

namespace Low_Bank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private MongoDbContext _db;

        public CustomerController()
        {
            _db = new MongoDbContext();
        }

        [HttpPost]
        public void Cadastrar(string nome, string cpf, string senha)
        {
            var novoCliente = new Customer()
            {
                Nome = nome,
                Cpf = cpf,
                Password = senha
            };

            //Armazenar no banco de dados
            _db.CreateUser(novoCliente);
        }

        [HttpGet]
        public List<Customer> PegaUsuarios()
        {
            return _db.GetCustomers();
        }
    }
}
