// See https://aka.ms/new-console-template for more information
using Actors101.Actors;

Console.WriteLine("Hello, World!");
try
{
    ActorSystem Sys = ActorSystem.Create("Actors101");
    var firstRef = Sys.ActorOf<TestActor>("first-actor");
    Console.WriteLine($"first-actor - {firstRef}");
    firstRef.Tell("hello", ActorRefs.NoSender);
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
