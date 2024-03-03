using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mmi.Core.Domain
{
    public class InsuranceContract : BaseEntity
    {
        public required uint PersonId { get; init; }
        
        public InsuredPerson? Person { get; init; }
        
        public IEnumerable<InsuranceСase> InsuranceСases { get; init; } =
            Array.Empty<InsuranceСase>();

    }
}