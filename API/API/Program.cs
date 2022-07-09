using API;
using API.MapperProfiles;
using API.Services;
using API.Stores;
using AutoMapper;
using Common.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IMessageStore, MessageStore>();
builder.Services.AddTransient<IDbConnectionHolder, DbConnectionHolder>();

builder.Services.AddSingleton(new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MessageMapper());
}).CreateMapper());

builder.Services.Migrate(new MySqlConnection(ConfigurationExtensions.GetConnectionString(builder.Configuration, "MSN")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



