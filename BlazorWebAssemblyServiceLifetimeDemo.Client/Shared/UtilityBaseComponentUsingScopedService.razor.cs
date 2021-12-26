using BlazorWebAssemblyServiceLifetimeDemo.Client.Model;
using BlazorWebAssemblyServiceLifetimeDemo.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Shared;

public  partial class UtilityBaseComponentUsingScopedService: OwningComponentBase
{ 
    private IScopedCounterService? scopedCounterService;
    private IServiceUsingScopedCounterService? serviceUsingScopedCounterService;
    public DemoResult? ScopedServicesResult { get; set; }

    protected override void OnInitialized()
    {
        this.scopedCounterService = this.ScopedServices.GetRequiredService<IScopedCounterService>();
        this.serviceUsingScopedCounterService = this.ScopedServices.GetRequiredService<IServiceUsingScopedCounterService>();
        this.ScopedServicesResult = this.GetDemoResultFromScopedService();
    }
    
    public void IncreaseScopedServiceCount()
    {
        if (this.scopedCounterService != null && this.serviceUsingScopedCounterService != null)
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
        else
        {
            throw new InvalidOperationException("The services are not obtained yet");
        }
    }
    
    private DemoResult GetDemoResultFromScopedService()
    {
        if (this.scopedCounterService != null && this.serviceUsingScopedCounterService != null)
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

        throw new InvalidOperationException("The services are not obtained yet");
    }
}