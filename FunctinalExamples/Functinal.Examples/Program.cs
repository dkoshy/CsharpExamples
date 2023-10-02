// See https://aka.ms/new-console-template for more information


using Functinal.Examples.util;


Console.WriteLine("Hello, World!");

var time =
    HelperMethods
    .Using(() => new System.Net.WebClient(),
      client => client.DownloadString("https://worldtimeapi.org/api/ip"));
Console.WriteLine(time);


