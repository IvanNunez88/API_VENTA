using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API_VENTAS.Context;
using BLL.PROVEEDOR.Validator;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MiReglaCors = "ReglaCors";

builder.Services.AddCors(option =>
option.AddPolicy(name: MiReglaCors,
builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

var secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var KeyBytes = Encoding.UTF8.GetBytes(secretkey);

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(KeyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbContext>();
builder.Services.AddSingleton<ValidacionAltaProveedor>();

var app = builder.Build();

//IMPORTACI�N DEL ARCHIVO JSON DE CONFIGURACIONES
builder.Configuration.AddJsonFile("appsettings.json");

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