namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public interface IServiceUsingScopedCounterService
{
    Guid Id { get; }
    
    Guid CounterServiceId { get; }

    int GetCount();
}