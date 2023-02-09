using LowBank.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LowBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet(Name = "GetAccounts")]
        public IEnumerable<Account> Get()
        {
            var listaDeContas = new List<Account>();

            listaDeContas.Add(new Account(123, 500, 100));

            listaDeContas.Add(new Account(999, 235.65m, 75));

            listaDeContas.Add(new Account(564, 5, 0));

            return listaDeContas;
        }
    }
}
