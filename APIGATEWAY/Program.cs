using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("ocelot.json",optional:false,reloadOnChange:true);

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseRouting();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.UseHttpsRedirection();


await app.UseOcelot();

app.Run();