
using intern.DataAccess.Data;
using Intern.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

namespace Intern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddDbContext<BankDatabaseContext>(op =>
                {
                    op.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
                });

            builder.Logging.AddNLog("nlog.config");

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app
                .UseEndpointValidationMiddleware()
                .UseHttpsRedirection()
                .UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}