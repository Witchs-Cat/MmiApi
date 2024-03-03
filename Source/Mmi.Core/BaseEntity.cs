using System.ComponentModel.DataAnnotations;

namespace Mmi.Core
{
    public class BaseEntity
    {
        public required uint Id { get; init; }
    }
}
