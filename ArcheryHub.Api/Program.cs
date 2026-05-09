using ArcheryHub.Api.Middlewares;
using ArcheryHub.Application.Interfaces;
using ArcheryHub.Application.Services;
using ArcheryHub.Core.Interfaces.Users;
using ArcheryHub.Core.Interfaces.Rounds;
using ArcheryHub.Infrastructure.Database;
using ArcheryHub.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFriendshipService, FriendshipService>();
builder.Services.AddScoped<IRoundService, RoundService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFriendshipRepository, FriendshipRepository>();
builder.Services.AddScoped<IRoundRepository, RoundRepository>();

builder.Services.AddSingleton<DapperContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ArcheryHub API v1");
        
        options.RoutePrefix = string.Empty; 
    });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();