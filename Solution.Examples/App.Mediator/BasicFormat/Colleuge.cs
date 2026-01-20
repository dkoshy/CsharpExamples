namespace App.Mediator.BasicFormat;

public abstract class Colleuge
{
    private Mediator mediator;
   
    public void SetMediator(Mediator concreateMediator)
    {
       mediator = concreateMediator;
    }

    public void Send(string message)
    {
        mediator.Send( this, message);
    }

    public abstract void HandleMessage(string message);   
}
