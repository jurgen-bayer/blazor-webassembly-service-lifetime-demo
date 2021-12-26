using BlazorWebAssemblyServiceLifetimeDemo.Client.Model;

namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Shared;

public partial class ComponentUsingTransientServices
{
    public DemoResult? TransientServicesResult { get; set; }
    
    protected override void OnInitialized()
    {
        this.TransientServicesResult = this.GetDemoResultFromTransientService();
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
    
}