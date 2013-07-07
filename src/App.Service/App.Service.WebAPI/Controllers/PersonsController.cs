using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class PersonsController : ControllerBase
    {
        public PersonsController(Logic logic) : base(logic) { }
        public CollectionResource<Person> GET()
        {
            var cr = new CollectionResource<Person>()
            {
                Content = logic.Repository.Read<Person>()
            };
            return cr;
        }
    }
}
