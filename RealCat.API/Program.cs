using Microsoft.EntityFrameworkCore;
using RealCat.API.Helpers;
using RealCat.API.Repository;
using RealCat.API.Services;
using RealCat.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CatDbContext>(options =>
{
    options.UseInMemoryDatabase("CatDb");
});

builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICatService, CatService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
{
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseMiddleware<JwtMiddleware>();
    app.MapControllers();
}
DbInitializer.Seed(app);
app.Run();
