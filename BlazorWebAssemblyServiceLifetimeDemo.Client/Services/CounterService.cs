namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public class CounterService: ITransientCounterService, IScopedCounterService, ISingletonCounterService
{
    // Unique ID to identify the service instance
    public Guid Id { get; } = Guid.NewGuid();

    // The current count
    public int Count { get; private set;  }

    // Method to be called to increase the count.
    public void Increase(int number)
    {
        this.Count += number;
        this.OnChanged?.Invoke();
    }

    // Event fired when the count was changed
    public event Action? OnChanged;
}