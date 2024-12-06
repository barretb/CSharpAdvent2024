using CSharpAdvent2024.AppHost;
using Microsoft.Extensions.DependencyInjection;

var builder = DistributedApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

var apiService = builder.AddProject<Projects.CSharpAdvent2024_ApiService>("apiservice")
    .WithHttpsCommand("/addnaughtylist", "Add to Naughty List", iconName: "ErrorCircle")
    .WithHttpsCommand("/addnicelist", "Add to Nice List", iconName: "CheckmarkCircle");

builder.AddProject<Projects.CSharpAdvent2024_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
