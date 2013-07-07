using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class PhoneNumberTypesController : ControllerBase
    {
        public PhoneNumberTypesController(Logic logic) : base(logic) { }
        public CollectionResource<PhoneNumberType> GET()
        {
            var cr = new CollectionResource<PhoneNumberType>()
            {
                Content = logic.Repository.Read<PhoneNumberType>()
            };
            return cr;
        }
    }
}
