#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Project.Core
{
    public abstract class BaseEntity<TId>
    {
        [Key]
        public virtual TId Id { get; set; }
    }
}
