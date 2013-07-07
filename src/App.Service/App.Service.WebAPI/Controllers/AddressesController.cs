using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using System.Web;
using App.Service.WebAPI.Resources;

namespace App.Service.WebAPI.Controllers
{
    public class AddressesController : ControllerBase
    {
        public AddressesController(Logic logic) : base(logic) { }
        public IEnumerable<Address> GET()
        {
            var query = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            var cr = new CollectionResource<Address>()
            {
                Content = logic.GetAddresses(query["type"], query["domainId"])
            };
            return logic.GetAddresses(query["type"], query["domainId"]);
        }
    }
}
