namespace Generic.App.Entities
{
    public class Organisation : EntityBase<int>
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id : {Id} , FirstNaem : {Name}";
        }

        public override void ItemMessage()
        {
            Console.WriteLine($"Added , organisation with Id => {Id}");
        }
    }
}
