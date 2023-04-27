using DogShelter.Infrastructure.FakeInMemory;
using Microsoft.Extensions.DependencyInjection;

namespace DogShelter.Domain.Test;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDomain();
        services.AddInfrastructureFakeInMemory();
    }
}