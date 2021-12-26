using BlazorWebAssemblyServiceLifetimeDemo.Client.Model;

namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Shared;

public partial class ComponentUsingScopedServices
{
    public DemoResult? ScopedServicesResult { get; set; }

    protected override void OnInitialized()
    {
        this.ScopedServicesResult = this.GetDemoResultFromScopedService();
    }
    
    public void IncreaseScopedServiceCount()
    {
        this.scopedCounterService.Increase(1);
        this.ScopedServicesResult = new DemoResult
        {
            CountDirectlyFromCounterService = this.scopedCounterService.Count,
            CountFromDemoServiceUsingCounterService = this.serviceUsingScopedCounterService.GetCount(),
            CounterServiceId = this.scopedCounterService.Id,
            DemoServiceId = this.serviceUsingScopedCounterService.Id,
            DemoServiceCounterServiceId = this.serviceUsingScopedCounterService.CounterServiceId
        };
        this.StateHasChanged();
    }
    
    private DemoResult GetDemoResultFromScopedService()
    {
        return new DemoResult
        {
            CountDirectlyFromCounterService = this.scopedCounterService.Count,
            CountFromDemoServiceUsingCounterService = this.serviceUsingScopedCounterService.GetCount(),
            CounterServiceId = this.scopedCounterService.Id,
            DemoServiceId = this.serviceUsingScopedCounterService.Id, 
            DemoServiceCounterServiceId = this.serviceUsingScopedCounterService.CounterServiceId
        };
    }

}