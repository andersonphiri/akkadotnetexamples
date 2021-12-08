
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors101.Actors
{
    public class TestActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "hello":
                    IActorRef secondRef = Context.ActorOf(Props.Empty, "second-actors");
                    Console.WriteLine($"Second actor - {secondRef}");
                    break;
                default:
                    break;
            }
        }
    }
}
