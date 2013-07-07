using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class DomainBase : ICreatable
    {
        public int ID { get; set; }
    }
}