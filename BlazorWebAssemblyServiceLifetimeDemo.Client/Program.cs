using BlazorWebAssemblyServiceLifetimeDemo.Client;
using BlazorWebAssemblyServiceLifetimeDemo.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register the services
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add three counter service instances based on the same class but with different lifetimes
builder.Services.AddTransient<ITransientCounterService, CounterService>();
builder.Services.AddScoped<IScopedCounterService, CounterService>();
builder.Services.AddSingleton<ISingletonCounterService, CounterService>();

// Add service instances for the services using the counter service
builder.Services.AddTransient<IServiceUsingTransientCounterService, ServiceUsingTransientCounterService>();
builder.Services.AddScoped<IServiceUsingScopedCounterService, ServiceUsingScopedCounterService>();
builder.Services.AddSingleton<IServiceUsingSingletonCounterService, ServiceUsingSingletonCounterService>();

await builder.Build().RunAsync();