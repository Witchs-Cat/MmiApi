using Mmi.Core;
using System.ComponentModel.DataAnnotations;

namespace Mmi.Core.Domain
{
    public class InsuranceСase : BaseEntity
    {
        public required decimal Payment { get; init; }

        public required bool IsPaid { get; init; }
        
        [DataType(DataType.DateTime)]
        public required DateTimeOffset PaymentDate { get; init; }
        
        [DataType(DataType.DateTime)]
        public required DateTimeOffset IncidentDate { get; init; }

        public required uint ContractId { get; init; }
        
        public InsuranceContract? Contract { get; init; }
    }
}
