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
    .WithName("GetItems");

#endregion

#region POST

app.MapPost("/items", (ItemDto item) =>
{
    return Results.Created($"/items/{item.Id}", item);
})
.WithName("CreateItem");

#endregion

#region PUT

app.MapPut("/items/{id}", (int id, ItemDto item) =>
{
    item.Id = id;
    return Results.Ok(item);
})
.WithName("UpdateItem");


#endregion

app.Run();
