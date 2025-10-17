using Constants;

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
    }
}
