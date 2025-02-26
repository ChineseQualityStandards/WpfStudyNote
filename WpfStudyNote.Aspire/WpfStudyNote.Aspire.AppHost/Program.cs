var builder = DistributedApplication.CreateBuilder(args);

// 添加Redis 此代码将业务流程配置为创建本地 Redis 容器实例。
var redis = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.WpfStudyNote_Aspire_ApiService>("apiservice");


builder.AddProject<Projects.WpfStudyNote_Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(redis)
    .WaitFor(apiService);


builder.Build().Run();
