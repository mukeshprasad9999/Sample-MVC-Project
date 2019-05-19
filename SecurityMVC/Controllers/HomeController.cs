using BAL;
using SecurityMVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel.Entities;

namespace SecurityMVC.Controllers
{
    [CustomAuthenticationFilter]
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork _uof): base(_uof)
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [CustomAuthorizeFilter(Roles = "Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Hello Admin";

            return View();
        }

        public ActionResult WebGridCustomPaging(int page = 1, string sort = "Name", string sortdir = "asc")
        {
            int pageSize = 2;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = uof.AgentRepo.GetAgents(sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            return View(data);
        }
    }
}