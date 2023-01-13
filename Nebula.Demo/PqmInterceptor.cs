using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.DynamicProxy;

namespace Nebula.Demo
{
    public class PqmInterceptor : AbpInterceptor, ITransientDependency
    {
        public override async Task InterceptAsync(IAbpMethodInvocation invocation)
        {
            Console.WriteLine("method begin ...");
            await invocation.ProceedAsync();
            Console.WriteLine("method end ...");
        }
    }
}
