using FinnHubStock;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllersWithViews();

//ADD DI
builder.Services.AddHttpClient<IFinnService, FinnService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error");

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.Run();
