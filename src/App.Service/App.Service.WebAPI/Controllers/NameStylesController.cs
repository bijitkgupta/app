using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using System.Web.Http;
using System.Net.Http;

namespace App.Service.WebAPI.Controllers
{
    public class NameStylesController : ControllerBase
    {
        public NameStylesController(Logic logic) : base(logic) { }
        public IEnumerable<KeyValuePair<NameStyleENUM, string>> GET()
        {
            return logic.NameStyles;
        }
    }
}
