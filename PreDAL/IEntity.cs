#nullable disable

namespace Project.Core
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
