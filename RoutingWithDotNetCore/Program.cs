var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// this is used to enable routing in dotnet core
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // define endpoints here 
});

app.Run();
