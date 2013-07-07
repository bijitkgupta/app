using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class AddressTypesController : ControllerBase
    {
        public AddressTypesController(Logic logic) : base(logic) { }
        public CollectionResource<AddressType> GET()
        {
            var cr = new CollectionResource<AddressType>()
            {
                Content = logic.Repository.Read<AddressType>()
            };
            return cr;
            //return new ResourceCollection<AddressType>() { Content = logic.Repository.Read<AddressType>() };
        }
    }
}
