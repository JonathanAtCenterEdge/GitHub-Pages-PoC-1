using Microsoft.OpenApi;
using RestfulService.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Restful Proof-of-Concept",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "RestfulService v1");
    options.RoutePrefix = string.Empty;
});

#region Items

app.MapGet("/items/{id:int}", (int id) =>
{
    var item = new ItemDto { Id = id, Name = "Sample Item", Description = "A sample description." };
    return Results.Ok(item);
})
.WithTags("Items")
.WithName("GetItem");

app.MapGet("/items", () =>
{
    var item = new ItemDto
    {
        Id = 1,
        Name = "Sample Item",
        Description = "A sample description."
    };

    return Results.Ok(new List<ItemDto> { item });
})
.WithTags("Items")
.WithName("GetItems");

app.MapPost("/items/new", (ItemDto item) =>
{
    return Results.Created($"/items/{item.Id}", item);
})
.WithTags("Items")
.WithName("CreateItem");

app.MapPut("/items/{id}", (int id, ItemDto item) =>
{
    item.Id = id;
    return Results.Ok(item);
})
.WithTags("Items")
.WithName("UpdateItem");

#endregion

app.Run();
