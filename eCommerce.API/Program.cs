using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;


namespace eCommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add infrastructure services
            builder.Services.AddInfrastructure();

            //add core services 
            builder.Services.AddCore();

            //add controllers to the service collection
            builder.Services.AddControllers().AddJsonOptions
                (options => {
                    options.JsonSerializerOptions.Converters.Add
                    (new JsonStringEnumConverter());
               });

            builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            }); 

            var app = builder.Build();

            app.UseExceptionHandlingMiddleware();

            // Routing
            app.UseRouting();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            //Cors
            app.UseCors();

            // Auth
            app.UseAuthentication();
            app.UseAuthorization();

            // Controller routes
            app.MapControllers();

            app.Run();
        }
    }
}
