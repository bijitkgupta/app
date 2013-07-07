using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Service.WebAPI.Resources
{
    public class CollectionResource<T>
    {
        public List<Link> Links { get; set; }
        public IEnumerable<T> Content { get; set; }
    }

    public class Resource<T>
    {
        public List<Link> Links { get; set; }
        public T Content { get; set; }
    }
}
