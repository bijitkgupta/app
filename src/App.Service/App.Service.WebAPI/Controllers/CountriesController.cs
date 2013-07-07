using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class CountriesController : ControllerBase
    {
        public CountriesController(Logic logic) : base(logic) { }
        public CollectionResource<CountryRegion> GET()
        {
            var cr = new CollectionResource<CountryRegion>()
            {
                Content = logic.Repository.Read<CountryRegion>()
            };
            return cr;
        }
    }
}
