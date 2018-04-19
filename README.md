# Skeddly SDK for .NET

The **Skeddly SDK for .NET** enables .NET developers to easily work with [Skeddly][skeddly] and automate their
[Amazon Web Services][aws] resources.

[![NuGet](http://img.shields.io/nuget/v/SkeddlySDK.svg?style=flat-square)](https://www.nuget.org/packages/SkeddlySDK/)

[![Build status](https://ci.appveyor.com/api/projects/status/xjs9qu527qii036l?svg=true)](https://ci.appveyor.com/project/eleven41/skeddly-sdk-net)

* [Documentation][skeddly-docs]

## Supported Frameworks

The Skeddly SDK for .NET is compatible with the following frameworks:

* .NET Framework 4.6.1 (and later)
* .NET Core 2.0 (and later)
* .NET Standard 2.0 (and later)

## Installation

Install the Skeddly SDK for .NET from Nuget:

    Install-Package SkeddlySDK

### Nuget Packages

* SkeddlySDK
  * This package is the core SDK.
* SkeddlySDK.Extensions.NETCore.Setup
  * This package includes extension methods to help configuration of .NET Core applications.

## Configuration

### Any Environment

The `SkeddlyClient` object has a constructor that can take your Skeddly API key as a parameter:

```csharp
var client = new SkeddlyClient("sk_12345678901234567890");
```

### .NET Framework 4.6.1

The Skeddly SDK has built-in configuration using Web.config and App.config. 
Add the following to your configuration file:

```xml
<appSettings>
  <add key="SkeddlyAccessKeyId" value="your access key" />
</appSettings>
```

Once configured, you can use the default constructor to create the client:

```csharp
var client = new SkeddlyClient();
```

### .NET Core

.NET Core application uses a different mechanism for configuration. 
Instead of using `ConfigurationManager`, .NET Core applications use a configuration
provider based on `IConfiguration`.

To make configuration easy, install a second package from Nuget:

    Install-Package SkeddlySDK.Extensions.NETCore.Setup

Common practice is to use an `appsettings.json` file to store your application settings.
Include a `Skeddly` object like the following.

```json
{
  "Skeddly": {
    "AccessKeyId": "your access key"
  }
}
```

#### Basic Configuration Loading

To load this configuration in your application, use the `GetSkeddlyOptions` extension 
method to get a `SkeddlyOptions` object. Using that, call `CreateClient` to create the client.

```csharp
using Skeddly;
...
var options = Configuration.GetSkeddlyOptions();
var client = options.CreateClient();
```

#### ASP.NET Core Dependency Injection

You can also use the .NET Core dependency injection system to create your Skeddly client.

In `Startup.cs`, (hopefully) you'll find a `ConfigureServices` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add framework services.
    services.AddMvc();
}
```

The `SkeddlySDK.Extensions.NETCore.Setup` assembly adds extension methods to `IServiceCollection`
that you can use to add the Skeddly client to the dependency injection.

```csharp
using Skeddly;

...

public void ConfigureServices(IServiceCollection services)
{
    // Add framework services.
    services.AddMvc();

    // Add the Skeddly configuration and client into the dependency injection pipeline
    services.AddDefaultSkeddlyOptions(Configuration.GetSkeddlyOptions());
    services.AddSkeddlyClient();
}
```

Then, in your MVC controllers, add an `ISkeddlyClient` parameter to the constructor.

```csharp
using Skeddly;

...

public class HomeController : Controller
{
    ISkeddlyClient _skeddlyClient;

    public HomeController(ISkeddlyClient skeddlyClient)
    {
       _skeddlyClient = skeddlyClient;
    }
 
   ...
}
```

## Usage

[aws]: https://aws.amazon.com/
[skeddly]: https://www.skeddly.com/
[skeddly-docs]: https://docs.skeddly.com/

