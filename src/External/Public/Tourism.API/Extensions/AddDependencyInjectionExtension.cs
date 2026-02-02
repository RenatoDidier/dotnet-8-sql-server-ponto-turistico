using Tourism.Application.Contracts.Tourism;
using Tourism.Application.Interfaces.Tourism;
using Tourism.Application.Services.Tourism;
using Tourism.Infrastructure.Repositories;

namespace Tourism.API.Extensions;

public static class AddDependencyInjectionExtension
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection service)
    {
        service.AddScoped<ITouristAttractionService, TouristAttractionService>();
        service.AddScoped<ITouristAttractionRepository, TouristAttractionRepository>();

        return service;
    }
}
