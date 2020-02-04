using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace WebTodoList.Client.BlazorWASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            RegisterServices(builder);

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }

        private static void RegisterServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped<HttpClient>(s => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44387/")
            });
        }
    }
}
