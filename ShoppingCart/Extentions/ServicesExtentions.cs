using Constants;
using Contracts;
using Polly;
using Services;
namespace Extentions
{
    public static class ServicesExtentions
    {
        public static void ScanDiServices(this IServiceCollection services)
        {
            services.Scan(selector =>
            selector
                .FromAssemblyOf<Program>()
                .AddClasses(c=> c.InNamespaces(Namespaces.Services))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        public static void PollyServices(this IServiceCollection services)
        {
            services.AddHttpClient<IProductCatalogClient, ProductCatalogClient>()
                .AddTransientHttpErrorPolicy(p =>
                p.WaitAndRetryAsync(
                3,
                attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt))));
        }
    }
}
