namespace Timewaster.Core.Entities
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
        public virtual string PartitionKey { get; set; }
    }
}
