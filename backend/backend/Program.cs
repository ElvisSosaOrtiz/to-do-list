using DbContext;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<TodoListDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnection"), b => b.MigrationsAssembly("backend"));
    });
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors(o => o.AddPolicy("policy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("policy");
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
