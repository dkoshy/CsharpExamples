using App.Mediator.ChatApp;

ChatAppDemo();
static void ChatAppDemo()
{
    var chatRoom = new TeamChatRoom();

    var smith = new Developer("Smith");
    var john = new Developer("John");
    var koshy = new Developer("koshy");
    var arun = new Tester("Arun");
    var bini = new Tester("Bini");

    chatRoom.Register(smith);
    chatRoom.Register(john);
    chatRoom.Register(koshy);
    chatRoom.Register(arun);
    chatRoom.Register(bini);

    smith.Send("Hi all , we are going to deploy at 2pm today");
    arun.Send("ok thank you , noted. ");

}