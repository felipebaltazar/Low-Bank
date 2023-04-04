using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace LowBank_Mobile
{
    public class ApiCustomerRepository
    {
        private string accessToken;
        private HttpClient _apiClient;

        public ApiCustomerRepository()
        {
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri("https://api-lowbank2.azurewebsites.net");
        }

        public bool Exists(long account)
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

        public Customer GetCustomerOrDefault(long account)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/Customer/GetCustomerOrDefault/{account}");
            request.Headers.Add("Authentication", accessToken);

            var response = _apiClient.SendAsync(request).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var customerString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var customer = JsonConvert.DeserializeObject<Customer>(customerString);
                return customer;
            }

            return null;
        }

        public int Save(Customer customer)
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

        public void Update(params Customer[] customer)
        {
            var customerString = JsonConvert.SerializeObject(customer);
            var content = new StringContent(customerString);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            _apiClient.PatchAsync("/Customer", content).GetAwaiter().GetResult();

        }

        public bool Login(LoginModel loginModel)
        {
            var loginString = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(loginString);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = _apiClient.PostAsync("/Authentication/Login", content).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                accessToken = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return true;
            }

            return false;
        }
    }
}
