using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SecurityMVC.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string Email)
        {
            this.Identity = new GenericIdentity(Email);
        }

        //authenticity
        public IIdentity Identity
        {
            private set;
            get;
        }

        //authorization
        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; set; }
    }
}