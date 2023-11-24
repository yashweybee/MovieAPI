using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieAPI;
using System.Configuration;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IRepository, InMemoryRepository>();

//builder.Services.AddResponseCaching();

//builder.Services.AddAuthentication(JwtBearerDefaults);

//builder.Services.AddTransient<MyActionFilter>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddTransient<Microsoft.Extensions.Hosting.IHostedService, WriteToFileHostedService>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = false,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"])),
//        ClockSkew = TimeSpan.Zero
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.


//app.Map("/abcd", (app) =>
//{

//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("I'm Short-ciruting pipeline");
//    });
//});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseResponseCaching();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
