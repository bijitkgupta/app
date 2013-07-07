using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class StatesController : ControllerBase
    {
        public StatesController(Logic logic) : base(logic) { }
        public CollectionResource<StateProvince> GET(string countryCode)
        {
            var cr = new CollectionResource<StateProvince>()
            {
                Content = logic.Repository.Read<StateProvince>(s => s.CountryRegion.CountryRegionCode == countryCode)
            };
            return cr;
        }
    }
}