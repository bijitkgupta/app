using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using System.Web;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class PhoneNumbersController : ControllerBase
    {
        public PhoneNumbersController(Logic logic) : base(logic) { }
        public CollectionResource<string> GET()
        {
            var query = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            var cr = new CollectionResource<string>()
            {
                Content = logic.GetPhoneNumbers(query["type"], query["personId"])
            };
            return cr;
        }
    }
}
