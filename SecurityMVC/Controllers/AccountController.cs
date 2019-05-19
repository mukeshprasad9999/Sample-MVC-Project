using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModels.Models;
using BAL;
using System.Web.Security;
using Newtonsoft.Json;

namespace SecurityMVC.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public AccountController(IUnitOfWork _uof):base(_uof)
        {

        }
        public ActionResult Login()
        {
            if (CurrentUser != null)
            {
               return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                UserModel user = uof.AuthenticateRepo.ValidateUser(model.Email, model.Password);
                if (user != null)
                {
                    string data = JsonConvert.SerializeObject(user);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(60), false, data);
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket) { Expires = ticket.Expiration };
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult UnAuthorize()
        {
            return View();
        }
    }
}