using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;

namespace Nebula.Demo
{
    public class PqmAuditingStore : IAuditingStore, ITransientDependency
    {
        public Task SaveAsync(AuditLogInfo auditInfo)
        {
            Console.WriteLine("####################");
            Console.WriteLine(auditInfo.ToString());
            Console.WriteLine("####################");

            return Task.CompletedTask;
        }
    }
}
