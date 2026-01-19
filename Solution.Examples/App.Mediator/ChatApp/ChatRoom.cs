namespace App.Mediator.ChatApp;

public abstract class ChatRoom
{
    public abstract void Register(TeamMember teamMemeber);
    public abstract void Send(string from , string message);
}
