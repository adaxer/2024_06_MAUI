using Microsoft.AspNetCore.Mvc;
using RooME.Contracts;

namespace RooME.Api;

public static class EndpointExtensions
{
    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        app.MapGet("/hello", (HttpContext httpContext) =>
        {
            return "Hello world";
        })
        .RequireAuthorization()
        .WithOpenApi();

        app.MapGet("/init", ([FromServices] AppDbContext db) =>
        {
            db.Database.EnsureCreated();
        });

        app.MapGet("/rooms", async () =>
        {
            var rooms = await DummyRoomService.GetRoomsAsync();
            return Results.Ok(rooms);
        })
        .RequireAuthorization()
        .WithOpenApi();

        return app;
    }
}
