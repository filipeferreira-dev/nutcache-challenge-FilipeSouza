using NutcacheChallenge.ApplicationService.Employees.Services;
using NutcacheChallenge.ApplicationService.Employees.Services.Contract;
using NutcacheChallenge.Domain.Repositories;
using NutcacheChallenge.Infra.Data.Repositories;

namespace NutcacheChallenge.Presentation.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
