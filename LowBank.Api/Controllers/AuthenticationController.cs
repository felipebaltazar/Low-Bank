using LowBank.Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LowBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public static HashSet<string> AccessTokens = new HashSet<string>();


        private readonly IMongoCollection<Customer> _collection;

        public AuthenticationController()
        {
            var context = new MongoDbContext();
            _collection = context.Database.GetCollection<Customer>("Customer");
        }

        [HttpPost("Login", Name = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel.Login == null || string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return BadRequest();
            }
            
            var query = await _collection.FindAsync(c => c.Cpf == loginModel.Login || c.Account.Id == loginModel.Login);
            var customer = query.FirstOrDefault();

            if (customer.Password == loginModel.Password)
            {
                var accessToken = Guid.NewGuid().ToString();

                AccessTokens.Add(accessToken);

                return Ok(accessToken);
            }

            return BadRequest();
        }

    }
}
