using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Service
{
    public interface IInstanceProvider<TImplementatiom>
    {
        TImplementatiom Instance { get; }
    }
}
