using Microsoft.IdentityModel.Tokens;
using System.Text;
// Comments
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options=>
{

  //  "Authendication": {
  //      "SecretForKey": "Thesecretketshouldbeattheminumumof32bytesize",
  //  "Issuer": "https://localhost:7110/",
  //  "Audience": "WebApiTokenBasedAuthendication"
  //}
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Authendication:Audience"],
        ValidIssuer = builder.Configuration["Authendication:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authendication:SecretForKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
