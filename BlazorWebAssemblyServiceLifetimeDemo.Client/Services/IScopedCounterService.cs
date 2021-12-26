namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Services;

public interface IScopedCounterService
{ 
    // Unique ID to identify the service instance
    int Id { get; }

    // The current count
    int Count { get; }

    // Method to be called to increase the count.
    void Increase(int number);

    // Event fired when the count was changed
    event Action? OnChanged;
}