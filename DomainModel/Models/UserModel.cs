using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; set; }
    }
}
