namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public interface IServiceUsingSingletonCounterService
{ 
    Guid Id { get; }
    
    Guid CounterServiceId { get; }

    int GetCount();
}