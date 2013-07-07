using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using App.Domain.Model;

namespace App.Service.WebAPI.Controllers
{
    public abstract class ControllerBase : ApiController
    {
        protected Logic logic;
        protected ControllerBase(Logic logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException("Logic");
            }
            this.logic = logic;
        }
    }
}