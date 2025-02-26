using WpfStudyNote.Aspire.Web;
using WpfStudyNote.Aspire.Web.Components;

var builder = WebApplication.CreateBuilder(args);

/* ��� Redis caching
 * �˴���:
 * �� ASP.NET ���������������Ϊʹ�þ���ָ���������Ƶ� Redis ʵ����
 * �Զ�������Ӧ������״����顢��־��¼��ң��
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
        // �� URL ʹ�� "https+http://" ��ʾ HTTPS ������ HTTP��
        // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
        // �˽��йط����ַ��������ĸ�����Ϣ������� https://aka.ms/dotnet/sdschemes��
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
    // Ĭ�ϵ� HSTS ֵ�� 30 �졣����������������������Ҫ���Ĵ�ֵ������� https://aka.ms/aspnetcore-hsts��
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
