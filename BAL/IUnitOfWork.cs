using BAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepo { get; }
        IAgentRepository AgentRepo { get; }
        int SaveChanges();
    }
}
