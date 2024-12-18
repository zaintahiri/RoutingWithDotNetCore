var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// this is used to enable routing in dotnet core
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/Home",async (context) =>
    {
        await context.Response.WriteAsync("Hi, you are in HOME page");
    });

    endpoints.MapGet("/Product", async (context) =>
    {
        await context.Response.WriteAsync("Hi, you are in PRODUCT page");
    });

    endpoints.MapPost("/Product", async (context) =>
    {
        await context.Response.WriteAsync("Hi, you have added PRODUCT");
    });

   


    // define endpoints here 
});

app.Run(async(HttpContext contex) => {
    await contex.Response.WriteAsync("Error code 404, Page not found");
});
app.Run();
