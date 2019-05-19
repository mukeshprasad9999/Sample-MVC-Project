using BAL.Abstraction;
using DAL;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace BAL.Implementation
{
    public class AgentRepository : Repository<Agent>, IAgentRepository
    {
        private DatabaseContext context
        {
            get
            {
                return this.db as DatabaseContext;
            }
        }
        public AgentRepository(DbContext _db)
        {
            this.db = _db;
        }

        public List<Agent> GetAgents(string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            var v = context.Agents.Select(x => x);
            totalRecord = v.Count();
            v = v.OrderBy(sort + " " + sortdir);
            if (pageSize > 0)
            {
                v = v.Skip(skip).Take(pageSize);
            }
            return v.ToList();

        }
       
    }
}
