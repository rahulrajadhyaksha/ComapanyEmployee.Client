using ComapanyEmployee.Client.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComapanyEmployee.Client.Service
{
    public class HttpClientCurdService : IHttpClientServiceImplementation
    {
        HttpClient _httpClient = new HttpClient();
        JsonSerializerOptions _options;

        public HttpClientCurdService()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/companies");
            _httpClient.Timeout = new TimeSpan(0, 0, 3);
            _httpClient.DefaultRequestHeaders.Clear();
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        public async Task Execute()
        {
            await GetCompanies();
        }

        private async Task GetCompanies()
        {
            var response = await _httpClient.GetAsync("companies");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var companies = JsonSerializer.Deserialize<List<CompanyDto>>(content, _options);
            var result = from c in companies
                         select c;
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.Address}, {item.Country}");
            }






        }
    }
}
