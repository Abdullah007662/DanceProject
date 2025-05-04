using DanceDataAccessLayer.Concrete;
using DanceBusinessLayer.Conteiner;
using DanceWebApi.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Program.cs
builder.Services.AddDbContext<DanceContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));
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
app.UseStaticFiles(); // bu satýr var mý, kontrol et

// wwwroot içindeki dosyalarý eriþilebilir yapmak için
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
    ),
    RequestPath = ""
});
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
