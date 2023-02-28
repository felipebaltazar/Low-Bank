using LowBank.Windows.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace LowBank.Windows.Data
{
    public class ApiCustomerRepository : BaseCustomerRepository
    {
        private HttpClient _apiClient;

        public ApiCustomerRepository()
        {
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri("https://localhost:7154");
        }

        public override bool Exists(long account)
        {
            var response = _apiClient.GetAsync($"/Customer/Exists/{account}").GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var existsString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var exists = bool.Parse(existsString);

                return exists;
            }

            return false;
        }

        public override Customer GetCustomerOrDefault(long account)
        {
            var response = _apiClient.GetAsync($"/Customer/GetCustomerOrDefault/{account}").GetAwaiter().GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var customerString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var customer = JsonConvert.DeserializeObject<Customer>(customerString);
                return customer;
            }

            return null;
        }

        public override void LoadData()
        {
        }

        public override int Save(Customer customer)
        {
            if (customer.Account == null)
            {
                customer.Account = new Account();
            }

            var customerString = JsonConvert.SerializeObject(customer);
            var content = new StringContent(customerString);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = _apiClient.PostAsync("/Customer", content).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var accountString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return int.Parse(accountString);
            }

            return 0;
        }

        public override void Update(params Customer[] customer)
        {
            throw new NotImplementedException();
        }
    }
}
