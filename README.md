<div align="center">
  <h1>BeyondNet.Bootstrapper</h1>
  <p><strong>A lightweight, extensible library for orchestrating .NET application startup</strong></p>

  <p>
    <a href="README.en.md"> English</a> | <a href="README.es.md"> Español</a>
  </p>

  <p>
    <a href="https://www.nuget.org/profiles/BeyondNetCode">
      <img src="https://img.shields.io/badge/NuGet-BeyondNetCode-blue" alt="NuGet" />
    </a>
    <a href="https://github.com/beyondnetcode/Shell.Bootstrapper/actions">
      <img src="https://github.com/beyondnetcode/Shell.Bootstrapper/workflows/CI%20/%20CD/badge.svg" alt="Build" />
    </a>
  </p>
</div>

---

Welcome to **BeyondNet.Bootstrapper**! A lightweight, extensible library for orchestrating the startup sequence of any .NET application or library. Based on the **Composite** pattern, it lets you encapsulate each initialization step as an independent, testable unit.

Built on **.NET 10** with full support for `async/await`, `Nullable Reference Types`, and a Cloud Native observability stack.

## Installation

### NuGet Packages

```bash
# Core (always required)
dotnet add package BeyondNetCode.Shell.Bootstrapper

# Official adapters (add as needed)
dotnet add package BeyondNetCode.Shell.Bootstrapper.DependencyInjection
dotnet add package BeyondNetCode.Shell.Bootstrapper.AutoMapper
dotnet add package BeyondNetCode.Shell.Bootstrapper.Observability
```

### Packages Overview

| Package | Description | NuGet |
|---------|-------------|-------|
| `BeyondNetCode.Shell.Bootstrapper` | Core bootstrapper with Composite pattern | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Bootstrapper) |
| `BeyondNetCode.Shell.Bootstrapper.DependencyInjection` | DI extension adapter | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Bootstrapper.DependencyInjection) |
| `BeyondNetCode.Shell.Bootstrapper.AutoMapper` | AutoMapper configuration adapter | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Bootstrapper.AutoMapper) |
| `BeyondNetCode.Shell.Bootstrapper.Observability` | OpenTelemetry + Serilog adapter | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Bootstrapper.Observability) |

## Why BeyondNet.Bootstrapper?

Without a standard, startup code tends to become a monolithic block in `Program.cs` that is hard to test and maintain. This library solves that by enforcing a single rule:

> **Each initialization concern lives in its own class. The Composite runs them in order.**

Benefits:
- Each bootstrapper is independently unit-testable
- The startup sequence is explicit and readable
- Adding or removing a step never changes surrounding code
- Async I/O at startup cannot deadlock the application

## Quick Start

### Synchronous Bootstrapper

```csharp
public class MyBootstrapper : IBootstrapper
{
    public void Run()
    {
        // Initialize your service
        Console.WriteLine("Bootstrap complete!");
    }
}

// Use
new CompositeBootstrapper()
    .Add(new MyBootstrapper())
    .Run();
```

### Asynchronous Bootstrapper

```csharp
public class MyAsyncBootstrapper : IBootstrapperAsync
{
    public async Task RunAsync()
    {
        await Task.Delay(100);
        Console.WriteLine("Async bootstrap complete!");
    }
}

// Use
await new CompositeBootstrapperAsync()
    .Add(new MyAsyncBootstrapper())
    .RunAsync();
```

### Combining with Adapters

```csharp
var composite = new CompositeBootstrapperAsync()
    .Add(new DependencyInjectionBootstrapper(services =>
    {
        services.AddSingleton<IMyService, MyService>();
    }))
    .Add(new AutoMapperBootstrapper(cfg =>
    {
        cfg.CreateMap<Source, Dest>();
    }))
    .Add(new ObservabilityBootstrapper(services, config))
    .Add(new MyCustomBootstrapper());

await composite.RunAsync();
```

## Documentation

For detailed documentation, see the language-specific README files:
- [English](README.en.md)
- [Español](README.es.md)

## Migration from Ums.Shell.Bootstrapper

If you were using `Ums.Shell.Bootstrapper`, update your NuGet references:

```bash
# Before (Ums.Shell.Bootstrapper)
dotnet add package Ums.Shell.Bootstrapper

# After (BeyondNetCode.Shell.Bootstrapper)
dotnet add package BeyondNetCode.Shell.Bootstrapper
```

Update namespaces in your code:
```csharp
// Before
using Ums.Shell.Bootstrapper;

// After
using BeyondNetCode.Shell.Bootstrapper;
```

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for GitFlow workflow, commit conventions, and coding standards.

## Versioning

See [VERSIONING.md](VERSIONING.md) for SemVer strategy and release process.

## License

Licensed under the Apache 2.0 License. See [LICENSE](LICENSE) for details.

## Acknowledgments

See [DISCLAIMER.md](DISCLAIMER.md) for original code authorship attribution.
