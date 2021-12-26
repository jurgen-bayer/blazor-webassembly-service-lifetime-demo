﻿namespace BlazorWebAssemblyServiceLifetimeDemo.Client.Model;

public class DemoResult
{
    public int CountDirectlyFromCounterService { get; set; }
    
    public int CountFromDemoServiceUsingCounterService { get; set; }

    public Guid CounterServiceId { get; set; }
    
    public Guid DemoServiceId { get; set; }
    
    public Guid DemoServiceCounterServiceId { get; set; }
}