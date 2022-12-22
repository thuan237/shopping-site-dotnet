using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System;
using BasicCourse.Data;
using Microsoft.EntityFrameworkCore;
using BasicCourse.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Unicode;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Writers;
using Microsoft.IdentityModel.Tokens;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // service class declaration
        var services = builder.Services;

        // service product declaration
        services.AddScoped<IProductRepository, ProductRepository>();

        //Config dbcontext
        builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"))
        );

        // jwt
        var secretKey = builder.Configuration["AppSettings :SecretKey"];
        var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    // tự cấp token 
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    // ký vào token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
           });



        // Add services to the container.

        builder.Services.AddControllers();
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

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}