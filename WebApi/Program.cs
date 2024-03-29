using WebApi.DBOperations;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();
builder.Services.AddScoped<IBookStoreDbContext,BookStoreDbContext>();

// Add services to the container.
builder.Services.AddDbContext<BookStoreDbContext>(options=>options.UseInMemoryDatabase(databaseName:"bookStoreDB"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope=app.Services.CreateScope()){
    var services=scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExceptionMiddleware();

app.MapControllers();

app.Run();
