using CarBook.BusinessLayer.Container;
using CarBook.DataAccessLayer.Concrete;
using FluentValidation.AspNetCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation();
// builder.Cars.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>();
builder.Services.ContainerDependencies();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CarBookCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors("CarBookCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
