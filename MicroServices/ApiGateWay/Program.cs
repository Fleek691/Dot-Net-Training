using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

/* 🔹 ADD THIS: Load ocelot.json */
builder.Configuration
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

/* 🔹 Register Ocelot */
builder.Services.AddOcelot(builder.Configuration);

/* 🔹 Other services */
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* 🔹 Development settings */
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

/* 🔹 IMPORTANT: Ocelot middleware MUST be last */
await app.UseOcelot();

app.Run();
