namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public class ServiceUsingScopedCounterService: IServiceUsingScopedCounterService
{
    private readonly IScopedCounterService counterService;

    public ServiceUsingScopedCounterService(IScopedCounterService counterService)
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