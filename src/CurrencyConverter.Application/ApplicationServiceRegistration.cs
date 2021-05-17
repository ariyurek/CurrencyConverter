using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CurrencyConverter.Application.Behaviours;
using System.Reflection;
using CurrencyConverter.Application.Persistence;
using CurrencyConverter.Application.Repositories;

namespace CurrencyConverter.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); 
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IQuotesRepository), typeof(QuotesRepository));

            return services;
        }
    }
}
