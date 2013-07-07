using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Service
{
    public interface IServiceHost<TContract, TImplementation>
        where TContract : IServiceContract
        where TImplementation : TContract
    {
        void Start();
        void Stop();
    }
}
