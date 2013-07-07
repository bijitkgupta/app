using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class ContactTypesController : ControllerBase
    {
        public ContactTypesController(Logic logic) : base(logic) { }
        public CollectionResource<ContactType> GET()
        {
            var cr = new CollectionResource<ContactType>()
            {
                Content = logic.Repository.Read<ContactType>()
            };
            return cr;
        }
    }
}
