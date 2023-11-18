using Microsoft.EntityFrameworkCore;
using DoughAssistantBackend;
using DoughAssistantBackend.DataContexts;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Repository;
using System.Text.Json.Serialization;
using DoughAssistantBackend.Properties;
using DoughAssistantBackend.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Secrets
var backendSecrets = await JsonFileReader.ReadAsync<BackendSecrets>("./Properties/backendSecrets.json");

// Controllers
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        builder => builder
            .WithOrigins("http://localhost:5173", "http://localhost:5174")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
       );
});

// Custom services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(provider =>
{
    return new SessionService();
});
builder.Services.AddScoped(provider =>
{
    var mapper = provider.GetRequiredService<IMapper>();
    return new GoogleService(mapper);
});

// Database context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(backendSecrets.DefaultConnectionString);
});


// Swagger gen
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//app.UseMiddleware<SessionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseCors("AllowVueApp");
app.UseAuthorization();
app.MapControllers();

app.Run();