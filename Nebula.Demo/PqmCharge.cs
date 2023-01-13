using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Nebula.Demo
{
    public interface IPqmCharge
    {

    }

    public class PqmCharge : IPqmCharge, ITransientDependency
    {

    }

    public class CostCharge : IPqmCharge
    {

    }
}
