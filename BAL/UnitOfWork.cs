using BAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Implementation;
using System.Data.Entity;
using DAL;

namespace BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;
        public UnitOfWork()
        {
            db = new DatabaseContext();
        }

        private IAuthenticateRepository _AuthenticateRepo;
        private IAgentRepository _AgentRepo;
        public IAuthenticateRepository AuthenticateRepo
        {
            get
            {
                if (_AuthenticateRepo == null)
                    _AuthenticateRepo = new AuthenticateRepository(db);

                return _AuthenticateRepo;
            }
           
        }

        public IAgentRepository AgentRepo
        {
            get
            {
                if (_AgentRepo == null)
                    _AgentRepo = new AgentRepository(db);

                return _AgentRepo;
            }
        }
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
       
    }
}
