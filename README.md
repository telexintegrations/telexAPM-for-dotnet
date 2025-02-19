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
│   │
├── ├── TelexAPM.csproj
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
