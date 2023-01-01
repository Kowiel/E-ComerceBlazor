global using Microsoft.AspNetCore.Components.Authorization;

using BlazorEcomerce.Client;
using BlazorEcomerce.Client.IService;
using BlazorEcomerce.Client.Service;
using BlazorEcomerce.Client.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace BlazorEcomerce.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddMudServices();
            //Add custom services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IAutenticationService, AutenticationService>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProviderClass>();

            await builder.Build().RunAsync();
        }
    }
}