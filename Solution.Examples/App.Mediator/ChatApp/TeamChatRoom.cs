namespace App.Mediator.ChatApp;

public class TeamChatRoom : ChatRoom
{
    private List<TeamMember> TeamMembers = new List<TeamMember>();
    public override void Register(TeamMember teamMemeber)
    {
        teamMemeber.SetChatRoom(this);
        TeamMembers.Add(teamMemeber);
    }
    public override void Send(string from, string message)
    {
        TeamMembers.Where(x => x.Name != from).ToList()
            .ForEach(x => x.Receive(from, message));
    }
}
