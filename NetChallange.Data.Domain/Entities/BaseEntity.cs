using System;

namespace NetChallange.Data.Domain.Entities
{
    public interface TEntity<T>
    {
        T Id { get; set; }
    }
    public class BaseEntity<T> : TEntity<T>
    {
        public T Id { get; set; }
    }
    public class BaseGuidEntity : BaseEntity<Guid>
    {

    }
}
