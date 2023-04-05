using LowBank.Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace LowBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMongoCollection<Customer> _collection;

        public CustomerController()
        {
            var context = new MongoDbContext();
            _collection = context.Database.GetCollection<Customer>("Customer");
        }

        [HttpPost(Name = "Create")]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] Customer newCustomer)
        {
            var lastCustomer = _collection
                .AsQueryable()
                .OrderByDescending(c => c.Account.Id)
                .FirstOrDefault();

            long accountId = 1000;
            if (lastCustomer != null)
            {
                accountId = lastCustomer.Account.Id + 1;
            }

            newCustomer.Account.Id = accountId;
            var options = new InsertOneOptions();
            await _collection.InsertOneAsync(newCustomer, options, CancellationToken.None);

            return Ok(accountId);
        }

        [HttpGet("Exists/{accountId}", Name = "Exists")]
        public async Task<ActionResult<bool>> Exists([Required] long accountId)
        {
            var query = await _collection.FindAsync(c => c.Cpf == accountId || c.Account.Id == accountId);
            var customer = query.FirstOrDefault();

            return Ok(customer != null);
        }

        [HttpGet("GetCustomerOrDefault/{accountId}", Name = "GetCustomerOrDefault")]
        public async Task<ActionResult<Customer>> GetCustomerOrDefault([FromHeader(Name = "Authentication")] string token, [Required] long accountId)
        {
            if (!IsValid(token))
                return Unauthorized();

            var query = await _collection.FindAsync(c => c.Cpf == accountId || c.Account.Id == accountId);
            var customer = query.FirstOrDefault();

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPatch(Name = "Update")]
        public async Task<IActionResult> Update([FromHeader(Name = "Authentication")] string token, [FromBody] Customer[] customers)
        {
            if (!IsValid(token))
                return Unauthorized();

            foreach (var customer in customers)
            {
                await _collection.ReplaceOneAsync(c => c.Cpf == customer.Cpf, customer);
            }

            return Ok();
        }

        private bool IsValid(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                return false;

            if (!AuthenticationController.AccessTokens.Contains(accessToken))
                return false;

            return true;
        }
    }
}
