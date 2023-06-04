using Domain.Repositories;
using LibrarayManagement.API.Errors;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Infrastructure.Services;
using Infrastructure.UnitOfWorks;
using Infrastructure.UnitOfWorks;
using Infrastructure.DbContexts;

namespace Ecommerce.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IApplicationDbContext,ApplicationDbContext>();
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var errors = actioncontext.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage);

                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
