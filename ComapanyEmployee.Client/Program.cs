using ComapanyEmployee.Client.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ComapanyEmployee.Client
{
    class Program
    {
        static async  Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();
            try
            {
                await provider.GetRequiredService<IHttpClientServiceImplementation>().Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Something went wrong: {ex}");
            }

            Console.ReadKey();

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IHttpClientServiceImplementation, HttpClientCurdService>();
        }
    }
}
