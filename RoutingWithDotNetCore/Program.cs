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

    // here is how to define parameters for get request, with two parameters
    endpoints.MapGet("/Books/{autherName}/{bookId}", async(context) =>
    {
        var authername = Convert.ToString(context.Request.RouteValues["autherName"]);
        var bookId = Convert.ToInt32(context.Request.RouteValues["bookId"]);
        await context.Response.WriteAsync($"\n\nBook is written by {authername} and book ID is {bookId}");

    });

    // here is how to define parameters for get request, with one parameter
    endpoints.MapGet("/Books/{bookId}", async (context) =>
    {
        var bookId = Convert.ToInt32(context.Request.RouteValues["bookId"]);
        await context.Response.WriteAsync($"\n\nPurchased book has Book ID {bookId}");

    });

    // here we are setting default value for parameter
    endpoints.MapGet("/Companies/{companyId=102}", async (context) =>
    {
        var companyId = Convert.ToInt32(context.Request.RouteValues["companyId"]);
        await context.Response.WriteAsync($"\n\nCompanyId is {companyId}");

    });

    // here we are setting default value for parameter
    endpoints.MapGet("/Companies/{companyName=zainulabdin}/{id}", async (context) =>
    {
        var companyId = Convert.ToInt32(context.Request.RouteValues["id"]);
        var companyName = Convert.ToString(context.Request.RouteValues["companyName"]);
        await context.Response.WriteAsync($"\n\nCompany Name is {companyName} and Company Id is {companyId}");

    });

    // how to make parameter as optional
    endpoints.MapGet("/Vendors/{vendor?}", async (context) =>
    {
        var vendor = Convert.ToString(context.Request.RouteValues["vendor"]);
        if (vendor != null) 
        {
            await context.Response.WriteAsync($"\n\nVendor is {vendor}");
        }
    });




    // define endpoints here 
});

app.Run(async(HttpContext contex) => {
    await contex.Response.WriteAsync("\nError code 404, Page not found");
});
app.Run();
