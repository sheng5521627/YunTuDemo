using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Auditing;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Nebula.Demo
{
    public class PqmBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPriceDetailFilter _priceDetailFilter;
        private readonly IAmbientDataContext _ambientDataContext;
        private readonly IAmbientScopeProvider<IAuditLogScope> _ambientScopeProvider;

        public PqmBackgroundService(
            IServiceProvider serviceProvider,
            IPriceDetailFilter priceDetailFilter,
            IAmbientDataContext ambientDataContext,
            IAmbientScopeProvider<IAuditLogScope> ambientScopeProvider)
        {
            _serviceProvider = serviceProvider;
            _priceDetailFilter = priceDetailFilter;
            _ambientDataContext = ambientDataContext;
            _ambientScopeProvider = ambientScopeProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var auditLogScope = new AuditLogScope(new AuditLogInfo()
            {
                UserName = "test"
            });
            using (_ambientScopeProvider.BeginScope("Volo.Abp.Auditing.IAuditLogScope", auditLogScope))
            {
                _priceDetailFilter.Filter();
                _priceDetailFilter.MyFilter();
            }
            Console.WriteLine(auditLogScope.Log.ToString());

            ExecuteCore();
            await Task.CompletedTask;
        }

        private void ExecuteCore()
        {

        }
    }
}
