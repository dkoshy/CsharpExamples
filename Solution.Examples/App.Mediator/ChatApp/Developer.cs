namespace App.Mediator.ChatApp;

public class Developer : TeamMember
{
    public Developer(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{this.Name} {nameof(Developer)} has recived message ");
        base.Receive(from, message);
    }
}
