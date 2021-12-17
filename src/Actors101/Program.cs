// See https://aka.ms/new-console-template for more information
using Actors101.Actors;

Console.WriteLine("Hello, World!");
try
{
    ActorSystem Sys = ActorSystem.Create("Actors101");
    var firstRef = Sys.ActorOf<TestActor>("first-actor");
    Console.WriteLine($"first-actor - {firstRef}");
    firstRef.Tell("hello", ActorRefs.NoSender);
    var firstStopDemoActor = Sys.ActorOf<StartStopActor1>("first");
    firstStopDemoActor.Tell("show children");
    firstStopDemoActor.Tell("stop");
    Console.ReadKey();
    // continue: https://getakka.net/articles/intro/tutorial-1.html
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
