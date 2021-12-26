namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public class ServiceUsingSingletonCounterService: IServiceUsingSingletonCounterService
{
    private readonly ISingletonCounterService counterService;

    public ServiceUsingSingletonCounterService(ISingletonCounterService counterService)
    {
        this.counterService = counterService;
    }

    public Guid Id { get; } = Guid.NewGuid();
    
    public Guid CounterServiceId => this.counterService.Id;

    public int GetCount()
    {
        return this.counterService.Count;
    }
}