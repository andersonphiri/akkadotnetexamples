
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors101.Actors
{
    public class TestActor : UntypedActor
    {
        protected override void PreStart()
        {
            base.PreStart();
            Console.WriteLine($"Pre-start from {GetType().FullName}");
        }
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "hello":
                    IActorRef secondRef = Context.ActorOf(Props.Empty, "second-actors");
                    Console.WriteLine($"Second actor - {secondRef}");
                    break;
                case "stop":

                default:
                    break;
            }
        }
    }
    public class StartStopActor1  : UntypedActor
    {
        protected override void PreStart()
        {
            Console.WriteLine($"{GetType().FullName} has pre-started...");
            Context.ActorOf(Props.Create<StartStopActor2>(), "second");
        }
        protected override void PostStop() => Console.WriteLine($"{GetType().FullName} has post-stopped...");
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "stop":
                    Context.Stop(Self);
                    break;
                case "show children":
                    PrintChildrenNames();


                    break;
                default:
                    break;
            }
        }
        private void PrintChildrenNames()
        {
            foreach (var child in Context.GetChildren())
            {
                Console.WriteLine($"Child Path Name: "+child.Path.Name);
            }
        }
    }
    public class StartStopActor2 : UntypedActor
    {
        protected override void PreStart() => Console.WriteLine($"{GetType().FullName} has pre-started...");
        protected override void PostStop() => Console.WriteLine($"{GetType().FullName} has post-stopped...");
        protected override void OnReceive(object message)
        {
            //throw new NotImplementedException();
        }
    }
}
