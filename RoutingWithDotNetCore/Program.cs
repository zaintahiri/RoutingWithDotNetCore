var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// this is used to enable routing in dotnet core
app.UseRouting();
// when you are getting endpoint you must use it After app.UseRouting, otherwise it will return null
app.Use(async (context,next) =>
{
    Endpoint endpoint =  context.GetEndpoint();
    if (endpoint != null)
    {
        await context.Response.WriteAsync("\nEndpoint name : " + endpoint.DisplayName);

    }
    await next(context);
});
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/Home",async (context) =>
    {
        await context.Response.WriteAsync("\nHi, you are in HOME page");
    });

    endpoints.MapGet("/Product", async (context) =>
    {
        await context.Response.WriteAsync("\nHi, you are in PRODUCT page");
    });

    endpoints.MapPost("/Product", async (context) =>
    {
        await context.Response.WriteAsync("\nHi, you have added PRODUCT");
    });

   


    // define endpoints here 
});

app.Run(async(HttpContext contex) => {
    await contex.Response.WriteAsync("\nError code 404, Page not found");
});
app.Run();
