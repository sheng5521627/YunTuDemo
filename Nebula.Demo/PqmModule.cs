using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;

namespace Nebula.Demo
{
    [DependsOn(typeof(AbpAutofacModule), typeof(AbpAuditingModule))]
    public class PqmModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddObjectAccessor(new PriceInfo("pqm"));
            base.PreConfigureServices(context);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var priceInfo = context.Services.GetObject<PriceInfo>();

            context.Services.OnRegistred(registrationAction =>
            {
                if (typeof(IPriceDetailFilter).IsAssignableFrom(registrationAction.ImplementationType))
                {
                    registrationAction.Interceptors.Add<PqmInterceptor>();
                }
            });

            base.ConfigureServices(context);
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            base.PostConfigureServices(context);
        }

        public override Task OnPreApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            Console.WriteLine("OnPreApplicationInitializationAsync ...");
            return base.OnPreApplicationInitializationAsync(context);
        }

        public override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            Console.WriteLine("OnApplicationInitializationAsync ...");
            return base.OnApplicationInitializationAsync(context);
        }

        public override Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            Console.WriteLine("OnPostApplicationInitializationAsync ...");
            return base.OnPostApplicationInitializationAsync(context);
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            Console.WriteLine("OnApplicationShutdown ...");
            base.OnApplicationShutdown(context);
        }
    }
}