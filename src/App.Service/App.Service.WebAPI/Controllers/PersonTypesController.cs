using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using System.Web.Http;

namespace App.Service.WebAPI.Controllers
{
    public class PersonTypesController : ControllerBase
    {
        public PersonTypesController(Logic logic) : base(logic) { }
        public IEnumerable<KeyValuePair<PersonTypeENUM, string>> GET()
        {
            return logic.PersonTypes;
        }
    }
}
