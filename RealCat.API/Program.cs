using Microsoft.EntityFrameworkCore;
using RealCat.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatDbContext>(options =>
{
    options.UseInMemoryDatabase("CatDb");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
