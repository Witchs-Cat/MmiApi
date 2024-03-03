using Mmi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmi.Core.Repositories
{
    public interface IInsuredPersonRepository
    {
        Task<InsuredPerson?> FindByIdAsync(uint personId);

        Task<InsuredPerson?> FinByAuthorizationDataAsync(string email, string password);

        Task<InsuredPerson> CreatePersonAsync(InsuredPerson person);
    }
}