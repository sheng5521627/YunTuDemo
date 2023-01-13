using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;

namespace Nebula.Demo
{
    public interface IPriceDetailFilter
    {
        void Filter();

        void MyFilter();
    }

    [Audited]
    public class PriceDetailFilter : IPriceDetailFilter, ITransientDependency
    {
        public void Filter()
        {
            Console.WriteLine("PriceDetailFilter.Filter()...");
        }

        public virtual void MyFilter()
        {
            Console.WriteLine("PriceDetailFilter.MyFilter()...");
        }
    }
}
