namespace Generic.App.Entities
{
    public  class Employee: EntityBase<int>
    {
        public string FirstName { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, FirstName : {FirstName}";
        }

        public override void ItemMessage()
        {
            Console.WriteLine($"Added , Emploee with Id => {Id}");
        }
    }

    public class Manager : Employee
    {
        public override string ToString()
        {
            return base.ToString() + " (Manager)";
        }

        public override void ItemMessage()
        {
            Console.WriteLine($"Added , Manager with Id => {Id}");
        }
    }

   
}
