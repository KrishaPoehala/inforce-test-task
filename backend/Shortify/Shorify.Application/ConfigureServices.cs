using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Shorify.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection self)
    {
        self.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        self.AddAutoMapper(Assembly.GetExecutingAssembly());
        return self;
    }
}
