using AuthAPI.Interfaces;
using AuthAPI.Models;
using AuthAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region[DI Services]
builder.Services.AddScoped<IAuthJWTService, AuthJWTService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

builder.Services.AddCors();

builder.Services.Configure<TokenManagement>(builder.Configuration.GetSection("tokenManagement"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region[Cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
