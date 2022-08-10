using CIP.Web.Helpers;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace CIP.Web.Filters
{
    public class RolAuthFilter :AuthorizeAttribute
    {
        private string[] _rol;

        public RolAuthFilter(params string[] rol)
        {
            _rol = rol;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (_rol.Length == 0 ||
                filterContext.HttpContext.Session["IdUsuario"] == null)
            {
                filterContext.Result = GetRedirectToRoute();
            }

            if (!_rol.Any(x => filterContext.HttpContext.Session.HasRol(x)))
            {
                filterContext.Result = GetRedirectToRoute();
            }
        }

        private RedirectToRouteResult GetRedirectToRoute()
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Index" }));
        }

    }
}