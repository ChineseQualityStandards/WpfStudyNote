var builder = DistributedApplication.CreateBuilder(args);

// ���Redis �˴��뽫ҵ����������Ϊ�������� Redis ����ʵ����
var redis = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.WpfStudyNote_Aspire_ApiService>("apiservice");


builder.AddProject<Projects.WpfStudyNote_Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(redis)
    .WaitFor(apiService);


builder.Build().Run();
