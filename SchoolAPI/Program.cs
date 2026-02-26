using DbModels;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Infrastructure;
using SchoolAPI.Model;
using SchoolAPI.WithDI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStudentService, StudentService>();
//builder.Services.AddSingleton<IStudentRepository, StudentInMemoryRepository>();
builder.Services.AddSingleton<IStudentRepository, StudentEntityFrameworkRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/students", (IStudentService studentService) =>
{
    return studentService.GetAll();
});

app.MapGet("/students/{id:int}", (IStudentService studentService, int id) =>
{
    var student = studentService.GetById(id);
    return student is null ? Results.NotFound() : Results.Ok(student);
});

app.MapPost("/students", (IStudentService studentService, StudentCreateDto dto) =>
{
    var created = studentService.Create(dto.Name, dto.Age);
    return Results.Created($"/students/{created.Id}", created);
});

app.Run();


/*
   using SchoolAPI.Model;
   using SchoolAPI.WithouthDI;
   
   var builder = WebApplication.CreateBuilder(args);
   var app = builder.Build();
   
   app.UseHttpsRedirection();
   
   var studentService = new StudentService();
   
   app.MapGet("/students", () =>
   {
       return studentService.GetAll();
   });
   
   app.MapGet("/students/{id:int}", (int id) =>
   {
       var student = studentService.GetById(id);
       return student is null ? Results.NotFound() : Results.Ok(student);
   });
   
   app.MapPost("/students", (StudentCreateDto dto) =>
   {
       var created = studentService.Create(dto.Name, dto.Age);
       return Results.Created($"/students/{created.Id}", created);
   });
   
   app.Run();   
 */