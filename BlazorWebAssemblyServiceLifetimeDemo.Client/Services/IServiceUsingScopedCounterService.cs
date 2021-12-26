namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public interface IServiceUsingScopedCounterService
{
    int Id { get; }
    
    int CounterServiceId { get; }

    int GetCount();
}