namespace App.Mediator.BasicFormat;

public class CollegueTwo : Colleuge
{
    
    public override void HandleMessage(string message)
    {
        Console.WriteLine($"{nameof(CollegueTwo)} received message : {message}. ");

    }
}
