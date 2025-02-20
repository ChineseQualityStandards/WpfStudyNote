var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.WpfStudyNote_Aspire_ApiService>("apiservice");

builder.AddProject<Projects.WpfStudyNote_Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
