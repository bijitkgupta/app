using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using System.Web;
using System.Net.Http;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class EmailsController : ControllerBase
    {
        public EmailsController(Logic logic) : base(logic) { }
        public CollectionResource<string> GET()
        {
            var query = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            var cr = new CollectionResource<string>()
            {
                Content = logic.GetEmails(query["personId"])
            };
            return cr;
        }
    }
}
