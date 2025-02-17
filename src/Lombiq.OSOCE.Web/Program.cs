using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Logging;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLogHost();

var configuration = builder.Configuration;

// Here we're adding the configuration to builder services. It will be used to configuring the UI Testing Toolbox
// (https://github.com/Lombiq/UI-Testing-Toolbox) so UI tests can be executed on the app. For a tutorial on how to create
// UI tests check out the project.
builder.Services.AddSingleton(configuration);

builder.Services.AddOrchardCms();

var app = builder.Build();

app.UseStaticFiles();
app.UseOrchardCore();
app.Run();

[SuppressMessage(
    "Design",
    "CA1050: Declare types in namespaces",
    Justification = "As described here(https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0).")]
public partial class Program
{
    protected Program()
    {
        // Nothing to do here.
    }
}
