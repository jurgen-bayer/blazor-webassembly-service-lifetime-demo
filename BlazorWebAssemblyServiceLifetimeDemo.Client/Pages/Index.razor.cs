using BlazorWebAssemblyServiceLifetimeDemo.Client.Model;

namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Pages;

public partial class Index
{
    public DemoResult? TransientServicesResult { get; set; }
    public DemoResult? ScopedServicesResult { get; set; }
    public DemoResult? SingletonServicesResult { get; set; }

    protected override void OnInitialized()
    {
        this.TransientServicesResult = this.GetDemoResultFromTransientService();
        this.ScopedServicesResult = this.GetDemoResultFromScopedService();
        this.SingletonServicesResult = this.GetDemoResultFromSingletonService();
    }

    public void IncreaseTransientServiceCount()
    {
        this.transientCounterService.Increase(1);
        this.TransientServicesResult = new DemoResult
        {
            CountDirectlyFromCounterService = this.transientCounterService.Count,
            CountFromDemoServiceUsingCounterService = this.serviceUsingTransientCounterService.GetCount(),
            CounterServiceId = this.transientCounterService.Id,
            DemoServiceId = this.serviceUsingTransientCounterService.Id, 
            DemoServiceCounterServiceId = this.serviceUsingTransientCounterService.CounterServiceId
        };
        this.StateHasChanged();
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
    
    private DemoResult GetDemoResultFromTransientService()
    {
        return new DemoResult
        {
            CountDirectlyFromCounterService = this.transientCounterService.Count,
            CountFromDemoServiceUsingCounterService = this.serviceUsingTransientCounterService.GetCount(),
            CounterServiceId = this.transientCounterService.Id,
            DemoServiceId = this.serviceUsingTransientCounterService.Id, 
            DemoServiceCounterServiceId = this.serviceUsingTransientCounterService.CounterServiceId
        };
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