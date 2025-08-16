
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OwlyNest.Core.Helpers;
using OwlyNest.Core.Interfaces.Helpers;
using OwlyNest.Core.Models;

namespace OwlyNest.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string _mCors = "mCorsConfiguration";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<DBSettings>(options =>
            {
                options.OwlyConnectionString = builder.Configuration.GetConnectionString("OwlyConnectionString");
            });


            builder.Services.AddSingleton<IDBSettings>(sp =>
                sp.GetRequiredService<IOptions<DBSettings>>().Value);


            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddDbContext<OwlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OwlyConnectionString")), ServiceLifetime.Scoped);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: _mCors, builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
