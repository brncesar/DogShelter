using DogShelter.Domain.Entities.BreedEntity;
using DogShelter.Domain.Entities.DogEntity;
using DogShelter.Infrastructure.Data.DbCtx;
using DogShelter.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBreedRepository, BreedRepository>();
        services.AddScoped<IDogRepository  , DogRepository  >();

        services.AddDbContext<DogShelterDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DogShelterConnection")));

        return services;
    }
}



/*** Content automatically added via Code Generator ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DogShelter.Infrastructure.Data.DbCtx;
using DogShelter.Infrastructure.Data.Repository;
// ðŸ‘‡ Other pre-defined use cases (it`'s just an example)
using DogShelter.Domain.Entities.AnotherEntity;
using DogShelter.Domain.Entities.SecondAnotherEntity;
// ðŸ‘‡ your new entity
using DogShelter.Domain.Entities.DogEntity;


namespace DogShelter.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DogShelterDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DogShelterConnection")));

            services.AddScoped<IAnotherEntityRepository      , AnotherEntityRepository      >();
            services.AddScoped<ISecondAnotherEntityRepository, SecondAnotherEntityRepository>();
            // ðŸ‘† Already existing repositories map
            // ðŸ‘‡ Your new repository
            services.AddScoped<IDogRepository, DogRepository>();

            return services;
        }
    }
}

***********************************************************************************************************************/
