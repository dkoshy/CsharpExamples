namespace App.Mediator.BasicFormat;

public class CollegeueOne : Colleuge
{
    public override void HandleMessage(string message)
    {
        Console.WriteLine($"{nameof(CollegeueOne) } received message : {message}. ");
    }
}
