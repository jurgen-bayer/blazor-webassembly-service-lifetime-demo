using BlazorWebAssemblyServiceLifetimeDemo.Client.Model;

namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Shared;

public partial class ComponentUsingSingletonServices
{
    public DemoResult? SingletonServicesResult { get; set; }

    protected override void OnInitialized()
    {
        this.SingletonServicesResult = this.GetDemoResultFromSingletonService();
    }
    
    public void IncreaseSingletonServiceCount()
    {
        this.singletonCounterService.Increase(1);
        this.SingletonServicesResult = new DemoResult
        {
            CountDirectlyFromCounterService = this.singletonCounterService.Count,
            CountFromDemoServiceUsingCounterService = this.serviceUsingSingletonCounterService.GetCount(),
            CounterServiceId = this.singletonCounterService.Id,
            DemoServiceId = this.serviceUsingSingletonCounterService.Id,
            DemoServiceCounterServiceId = this.serviceUsingSingletonCounterService.CounterServiceId
        };
        this.StateHasChanged();
    }
    
   private DemoResult GetDemoResultFromSingletonService()
    {
        return new DemoResult
        {
            CountDirectlyFromCounterService = this.singletonCounterService.Count,
            CountFromDemoServiceUsingCounterService = this.serviceUsingSingletonCounterService.GetCount(),
            CounterServiceId = this.singletonCounterService.Id,
            DemoServiceId = this.serviceUsingSingletonCounterService.Id, 
            DemoServiceCounterServiceId = this.serviceUsingSingletonCounterService.CounterServiceId
        };
    }
}