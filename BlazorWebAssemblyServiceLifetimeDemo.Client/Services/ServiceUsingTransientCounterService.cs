namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public class ServiceUsingTransientCounterService: IServiceUsingTransientCounterService
{
    private readonly ITransientCounterService counterService;

    public ServiceUsingTransientCounterService(ITransientCounterService counterService)
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