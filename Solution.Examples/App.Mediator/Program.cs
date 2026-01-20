using App.Mediator.BasicFormat;
using App.Mediator.ChatApp;

//ChatAppDemo();
BasicMediator();
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

static void BasicMediator()
{
    //var c1 = new CollegeueOne();
    //var c2 = new CollegueTwo();
    var mediator = new ConcreateMediator();

    //mediator.Register(c1);
    //mediator.Register(c2);
    var c1 = mediator.CreateCollegue<CollegeueOne>();
    var c2 = mediator.CreateCollegue<CollegueTwo>();

    c1.Send("Hello How are you");
    c2.Send("Yes I am fine");
}