using DanceDataAccessLayer.Concrete;
using DanceBusinessLayer.Conteiner;
using DanceWebApi.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Builder;
using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Program.cs
builder.Services.AddDbContext<DanceContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<DanceContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com",
            ValidAudience = "yourdomain.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey123!"))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()  // Tüm origin'lere izin verir
               .AllowAnyMethod()  // Tüm HTTP yöntemlerine izin verir (GET, POST, PUT, DELETE vb.)
               .AllowAnyHeader()); // Tüm header'lara izin verir
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.ConteinerDependencies();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
app.UseStaticFiles(); // bu satır var mı, kontrol et

// wwwroot içindeki dosyaları erişilebilir yapmak için
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
    ),
    RequestPath = ""
});
app.UseCors("AllowAll");
app.UseAuthentication(); // ⬅ BU SATIRI EKLE

app.UseAuthorization();

app.MapControllers();

app.Run();
