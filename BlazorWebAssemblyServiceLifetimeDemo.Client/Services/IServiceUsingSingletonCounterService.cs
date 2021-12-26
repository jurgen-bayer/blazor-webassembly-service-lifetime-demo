namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public interface IServiceUsingSingletonCounterService
{ 
    int Id { get; }
    
    int CounterServiceId { get; }

    int GetCount();
}