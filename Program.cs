global using DotnetMyCrud.Domain.DBContexts;
global using DotnetMyCrud.Shared.Dto;
global using DotnetMyCrud.Dto;
global using DotnetMyCrud.Shared.Extension;
global using Dotnet_CRUD.Domain.Repository.Interfaces;
global using Microsoft.AspNetCore.Mvc;
global using AutoMapper;
global using Dapper;
global using System.Data.Common;
using DotnetMyCrud.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: db
#region [Declare DBContext]
builder.Services.AddDbContext<contact_DBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DB_Connection")));
#endregion

// TODO: service
#region [Declare Service]
builder.Services.Contact();
builder.Services.Response();
builder.Services.UnilOfWork();
#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
