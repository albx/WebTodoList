using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WebTodoList.Client.BlazorWASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            RegisterServices(builder);

            builder.RootComponents.Add<App>("#app");

            await builder.Build().RunAsync();
        }

        private static void RegisterServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44387/")
            });
        }
    }
}
