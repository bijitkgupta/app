using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Service
{
    public interface IService<TContract, TImplementation>
        where TContract : IServiceContract
        where TImplementation : TContract
    {
        IInstanceProvider<TImplementation> InstanceProvider { get; set; }
        IServiceHost<TContract, TImplementation> Host { get; set; }
    }

    public interface IServiceContract { }
}
