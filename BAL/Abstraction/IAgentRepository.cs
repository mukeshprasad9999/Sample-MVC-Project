using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Abstraction
{
    public interface IAgentRepository : IRepository<Agent>
    {
        List<Agent> GetAgents(string sort, string sortdir, int skip, int pageSize, out int totalRecord);
    }
}
