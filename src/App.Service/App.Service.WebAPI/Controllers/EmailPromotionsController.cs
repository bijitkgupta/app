using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using System.Web.Http;

namespace App.Service.WebAPI.Controllers
{
    public class EmailPromotionsController : ControllerBase
    {
        public EmailPromotionsController(Logic logic) : base(logic) { }
        public IEnumerable<KeyValuePair<EmailPromotionENUM, string>> GET()
        {
            return logic.EmailPromotions;
        }
    }
}
