using CIP.Models.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIP.Web.Controllers
{
    public class BaseController : Controller
    {
        protected CIPEntities Contexto;

        public BaseController()
        {
            Contexto = new CIPEntities();
        }
    }
}
