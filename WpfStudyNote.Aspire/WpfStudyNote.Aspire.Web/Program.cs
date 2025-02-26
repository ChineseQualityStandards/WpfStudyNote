using WpfStudyNote.Aspire.Web;
using WpfStudyNote.Aspire.Web.Components;

var builder = WebApplication.CreateBuilder(args);

/* 添加 Redis caching
 * 此代码:
 * 将 ASP.NET 核心输出缓存配置为使用具有指定连接名称的 Redis 实例。
 * 自动启用相应的运行状况检查、日志记录和遥测
 */
builder.AddRedisOutputCache("cache");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

builder.Services.AddHttpClient<WeatherApiClient>(client =>
    {
        // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
        // 此 URL 使用 "https+http://" 表示 HTTPS 优先于 HTTP。
        // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
        // 了解有关服务发现方案解析的更多信息，请访问 https://aka.ms/dotnet/sdschemes。
        client.BaseAddress = new("https+http://apiservice");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
    }
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // 默认的 HSTS 值是 30 天。对于生产环境，您可能需要更改此值，请参阅 https://aka.ms/aspnetcore-hsts。
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
