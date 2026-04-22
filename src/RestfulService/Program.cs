using RestfulService.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "RestfulService v1");
    options.RoutePrefix = string.Empty;
});

#region GET

app.MapGet("/items/{id:int}", (int id) =>
{
    var item = new ItemDto { Id = id, Name = "Sample Item", Description = "A sample description." };
    return Results.Ok(item);
})
.WithName("GetItem")
.Produces<ItemDto>();

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
    .WithName("GetItems")
    .Produces<List<ItemDto>>();

#endregion

#region POST

app.MapPost("/items", (ItemDto item) =>
{
    return Results.Created($"/items/{item.Id}", item);
})
.WithName("CreateItem")
.Produces<ItemDto>(StatusCodes.Status201Created);

#endregion

#region PUT

app.MapPut("/items/{id:int}", (int id, ItemDto item) =>
{
    item.Id = id;
    return Results.Ok(item);
})
.WithName("UpdateItem")
.Produces<ItemDto>();

#endregion

#region DELETE

app.MapDelete("/items/{id:int}", (int id) => Results.NoContent())
    .WithName("DeleteItem")
    .Produces(StatusCodes.Status204NoContent);

#endregion

app.Run();
