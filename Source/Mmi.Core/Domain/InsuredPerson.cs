using Mmi.Core;
using Mmi.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Mmi.Core.Domain
{
    public class InsuredPerson : BaseEntity
    {
        public required string Name { get; init; }

        public required string Surname { get; init; }
        
        public required string? MiddleName { get; init; }
        
        [DataType(DataType.DateTime)]
        public required DateTimeOffset Bithday { get; init; }
        
        public required PersonPemissions Pemissions { get; init; }
        
        public required string Email { get; init; }

        /// <summary>
        /// Криптографии нема
        /// </summary>
        public required string Password { get; init; }
        
        public IEnumerable<InsuranceContract> Contracts { get; init; } =
            Array.Empty<InsuranceContract>();
    }

}
