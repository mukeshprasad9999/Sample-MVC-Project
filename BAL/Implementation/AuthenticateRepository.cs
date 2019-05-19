using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Abstraction;
using DAL;
using System.Data.Entity;
using DomainModels.Models;

namespace BAL.Implementation
{
    public class AuthenticateRepository : Repository<User>, IAuthenticateRepository
    {
        private DatabaseContext context
        {
            get
            {
                return this.db as DatabaseContext;
            }
        }
        public AuthenticateRepository(DbContext _db)
        {
            this.db = _db;
        }

        public UserModel ValidateUser(string Email, string Password)
        {
            User data = context.Users.Include("Roles").Where(u => u.Email == Email && u.Password == Password).FirstOrDefault();
            if (data != null)
            {
                UserModel user = new UserModel();

                user.Email = data.Email;
                user.Name = data.Name;
                user.Roles = data.Roles.Select(r => r.Name).ToArray();
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
