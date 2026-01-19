
using System.Runtime.InteropServices;

namespace App.Mediator.ChatApp
{
    public class TeamMember
    {
        private ChatRoom _chatRoom;

        public string Name { get; }

        public TeamMember(string name)
        {
            this.Name = name;
        }

        public void SetChatRoom(ChatRoom teamChatRoom)
        {
            _chatRoom = teamChatRoom;
        }
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"from  {from} : {message}");
        }

        public  void Send(string message)
        {
           _chatRoom.Send(this.Name, message);
        }
    }
}