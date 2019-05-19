using BAL;
using SecurityMVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityMVC.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork uof;
        public BaseController(IUnitOfWork _uof)
        {
            uof = _uof;
        }

        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }
    }
}