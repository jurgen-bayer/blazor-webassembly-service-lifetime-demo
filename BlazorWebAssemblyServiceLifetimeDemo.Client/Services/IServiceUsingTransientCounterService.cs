namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public interface IServiceUsingTransientCounterService
{
    Guid Id { get; }
    
    Guid CounterServiceId { get; }

    int GetCount();
}