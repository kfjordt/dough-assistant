using BudgetBffBackend.Contexts;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddDbContext<AppDbContext>(); // Add your DbContext here

services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        builder => builder
            .WithOrigins("http://localhost:5173", "http://localhost:5174")
            .AllowAnyHeader()
            .AllowAnyMethod()
       );
});


var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.UseCors("AllowVueApp");

app.MapControllers();

app.Run();
