using Microsoft.EntityFrameworkCore;
using StudentCourseEnrollment.Repositories;
using StudentCourseEnrollment.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentEnrollmentDB")));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddControllers();

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
app.MapControllers();
app.Run();

// cd C:\CIT
// .\.venv\Scripts\activate
// python -m pip install jupyterlab
// jupyter lab	


// *********************************************
// var builder = WebApplication.Create();
// var app = builder.Build();

// // A simple Fluent chain for a GET request
// app.MapGet("/books/{id}", (int id) => 
// {
//     return Results.Ok(new { Id = id, Title = "The Great Gatsby" });
// })
// .WithName("GetBookById")
// .WithSummary("Retrieves a single book by its unique ID");

// app.Run();



// ___________________________


// // A Fluent chain for a POST request
// app.MapPost("/books", (Book newBook) => 
// {
//     // Logic to save the book to a database would go here
//     return Results.Created($"/books/{newBook.Id}", newBook);
// })
// .WithName("CreateBook")
// .Accepts<Book>("application/json")
// .Produces<Book>(201);