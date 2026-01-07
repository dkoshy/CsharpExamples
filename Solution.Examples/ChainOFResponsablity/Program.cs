using ChainOFResponsablity.Business;
using ChainOFResponsablity.Business.UserRegistartion.Models;
using System.Globalization;


var user = new User("Deepak Koshy",
        "",
        new RegionInfo("SE"),
        new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));


    Console.WriteLine(user.Age);
    var processor = new UserProcessor();

    var ressult = processor.Register(user);

    Console.WriteLine(ressult);