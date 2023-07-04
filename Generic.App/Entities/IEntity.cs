namespace Generic.App.Entities
{

    public interface IEntity
    {
         DateTime CreatedDte { get; set; }
         DateTime ModifiedDate { get; set; }

        void ItemMessage();

    }

    public interface IEntity<T> : IEntity

    {
         T Id { get; set; }
    }

    public class EntityBase : IEntity
    {
        public DateTime CreatedDte { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual void ItemMessage()
        {
            Console.WriteLine($"Added, an Item ");
        }
    }

    public class EntityBase<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDte { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual void ItemMessage()
        {
            Console.WriteLine($"Added, Item with Id => {Id}");
        }
    }

}
