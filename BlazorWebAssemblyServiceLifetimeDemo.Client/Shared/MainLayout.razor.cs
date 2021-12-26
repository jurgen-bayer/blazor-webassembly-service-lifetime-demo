namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Shared;

public partial class MainLayout: IDisposable
{
    protected override void OnInitialized()
    {
        this.transientCounterService.OnChanged += this.StateHasChanged;
        this.scopedCounterService.OnChanged += this.StateHasChanged;
        this.singletonCounterService.OnChanged += this.StateHasChanged;
    }

    public void Dispose()
    {
        this.transientCounterService.OnChanged -= this.StateHasChanged;
        this.scopedCounterService.OnChanged -= this.StateHasChanged;
        this.singletonCounterService.OnChanged -= this.StateHasChanged;
    }
}