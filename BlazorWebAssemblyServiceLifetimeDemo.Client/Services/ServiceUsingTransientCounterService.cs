namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public class ServiceUsingTransientCounterService: IServiceUsingTransientCounterService
{
    private readonly ITransientCounterService counterService;

    public ServiceUsingTransientCounterService(ITransientCounterService counterService)
    {
        this.counterService = counterService;
    }
    
    public int Id { get; } = IdHelper.GetNextId();

    public int CounterServiceId => this.counterService.Id;

    public int GetCount()
    {
        return this.counterService.Count;
    }
}