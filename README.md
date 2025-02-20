# TelexAPM SDK for c#(dotnet)

## Overview

🌟 Telex APM – Global Error Tracking & Performance Monitoring for .NET. Lightweight APM SDK for .NET applications (ASP.NET Core & standalone C#). Tracks errors & performance automatically. 🚀

## Features

- 📚 Global Error Tracker/Reporting to Telex Channel
- ✅ Performance Tracker/Reporting to Telex Channel
- 🧪 Unit test coverage
- 📝 SDK documentation
- 🌎 ASP.NET Core Extensions and Middleware (Supports Dependency Injection)

## Project Structure

```
telexapm-for-dotnet/
├── TelexAPM/
│   ├── Extensions/                           #ASP.NET Core Extensions
│   │   ├── AddTelex.cs                       #Service Registration for containers - DI injections
│   │   ├── AspNetCoreExtensions.cs           #Configure to UseTelex middleware
│   │   └──TelexMiddleware.cs
│   │
│   ├── Models/                               #Models for Data to be sent
│   │   ├── ErrorReport.cs
│   │   ├── PerformanceReport.cs
│   │   ├── SuccessReport.cs
│   │   └── WebhookPayload.cs
│   │
│   ├── Services/                             #MTelex APM Core Services
│   │   ├── BaseTracker.cs                    #Internal - Clients should  not access this directly
│   │   ├── ErrorTracker.cs                   #Internal - Clients should  not access this directly
│   │   ├── PerformanceTracker.cs             #Internal - Clients should  not access this directly
│   │   └── TelexClient.cs                    #Public API - Accessible to Clients
|   |
|   ├── TelexAPM.ConsoleTest/                 #Models for Data to be sent
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   └── TelexApm.ConsoleTest.csproj
│   ├── TelexAPM.csproj
│
├── TelexAPM.Tests/
│   ├── TelexMiddlewareTest.cs               # API endpoint tests
│   └── TelexAPM.Test.csproj
├── telexAPM-for-dotnet.sln                  # telexAPM-for-dotnet.sln
└── README.md
```

## Technologies Used

- C#
- ASP.NET Core
- XUnit

## Installation

### Step 1: Add TelexAPM Reference to Your Project

Since Telex is currently in build mode - this SDK is not yet published to NuGet, you'll need to reference it directly from GitHub in your project file.

```bash
git clone https://github.com/telexintegrations/telexAPM-for-dotnet.git
cd telexAPM-for-dotnet
```

### Step 2: Reference TelexAPM in Your Project

-Add a reference to TelexAPM in your project file:
Project Reference (preferred during development)
In your .csproj file, add:

```xml
<ItemGroup>
  <ProjectReference Include="path/to/cloned/TelexAPM/src/TelexAPM.csproj" />
</ItemGroup>
```

    You can check the csproj file in the TelexAPM.ConsoleTest Directory

### Step 3: Configure TelexAPM

Configuration in appsettings.json
Add the following section to your appsettings.json file:

```json
{
  "Telex": {
    "BaseUrl": "ping.telex.im/v1/webhooks", #this must be telex base-url for channels
    "ChannelHookId": "YOUR_CHANNEL_HOOK_ID"
  }
}
```

- Usage
  - Console Applications

```cs
using TelexAPM;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        // Config builder - setting appsettings as config file
        var Config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        TelexConfiguration telexConfig = GetTelexConfig(Config);
        await Test(telexConfig);
    }

    public static async Task Test(TelexConfiguration telexConfig)
    {
        TelexClient telex = new(telexConfig);
        var x = new Exception("Console Test Telex Error");
        await telex.TrackErrorAsync(x);
        Console.WriteLine("test done");
    }

    public static TelexConfiguration GetTelexConfig(IConfigurationRoot config)
    {
        TelexConfiguration telexConfig = new()
        {
            BaseUrl = config["Telex:BaseUrl"],
            ChannelHookId = config["Telex:ChannelHookId"],
        };
        return telexConfig;
    }
}
```

- Usage
  - ASP.NET cORE applications:
    Step 1: Register TelexAPM Services
    In your Program.cs or Startup.cs, add TelexAPM services:

```cs
    using TelexApm.Extensions;

// ...
services.AddTelex(Configuration); // Dependency Container
```

    Step 2: Use TelexAPM Middleware
    Add the TelexAPM middleware to your application pipeline:

```cs
using TelexAPM.Extensions;

// ...

app.UseMiddleware<TelexMiddleWare>();
```

## API Reference

### TelexClient

The main client for interacting with TelexAPM.

```cs
    // Create a new TelexClient
TelexClient telex = new(telexConfig);

// Track an error
await telex.TrackErrorAsync(exception);

// Track performance
await telex.TrackPerformanceAsync("Operation Name", timeSpan);
```

### TelexConfiguration

| Property        | Description                              |
| --------------- | ---------------------------------------- |
| `BaseUrl`       | The base URL of the Telex service        |
| `ChannelHookId` | The channel hook ID for your application |

## Telex Integration/Channel Configuration

TelexAPM includes extensions for easy integration with ASP.NET Core applications and Standalone applications

The APM automatically tracks request performance and catches unhandled exceptions and report/sends to your Telex Channel

## 🚀 Telex Dotnet APM Integration Guide

Follow these steps to configure your Telex channel to use the Dotnet APM:
This assumes you have an organisation and channel created!

---

### 🛠️ Step 1: Install the Dotnet APM Application

- Go to your **Telex dashboard**.
- Install the **Dotnet APM** application.

---

### ⚙️ Step 2: Update the Webhook URL

- After installation, update the `webhookUrl` in the application settings to your **output webhook** (where you want Telex to send your messages).

---

### 🔧 Step 3: Activate/Configure Your Channel

- Activate and configure your channel to use the **Dotnet APM**.

---

### 🎉 Step 4: You're Done!

- **Voila!** 🚀 Your Telex APM setup is now complete.

## Additional Resources

- 📚 [TelexAPM Documentation](https://docs.telex.im/docs)
- 📖 [.NET Configuration Documentation](https://dotnet.microsoft.com/en-us/apps/aspnet)

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For support, please open an issue in the GitHub repository.
