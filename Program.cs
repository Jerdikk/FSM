using Patterns;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Diagnostics;
using static ConsoleApp1.Program;
namespace ConsoleApp1
{
    public class TurnstileLocked : State<TurnstileStates>
    {

        public TurnstileLocked()
            : base(TurnstileStates.LOCKED)
        {

        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Turnstile LOCKED. Press C key to insert a coin");
        }

        public override void Update()
        {
            base.Update();

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();

            if (consoleKeyInfo.Key == ConsoleKey.C)
            {
                Console.WriteLine("Turnstile unlocking");
                FiniteStateMachine<TurnstileStates>.SetCurrentState(TurnstileStates.UNLOCKED);
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Q)
            {
                FiniteStateMachine<TurnstileStates>.SetCurrentState(TurnstileStates.EXIT);
            }
            else
            {
                Console.WriteLine("Incorrect coin");
            }

        }
    }

    public class TurnstileExit : State<TurnstileStates>
    {

        public TurnstileExit()
            : base(TurnstileStates.EXIT)
        {

        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Turnstile Exiting");
        }

        public override void Update()
        {
            base.Update();         

        }
    }


    public class TurnstileUnlocked : State<TurnstileStates>
    {

        public TurnstileUnlocked()
            : base(TurnstileStates.UNLOCKED)
        {
        }

        public override void Enter()
        {
            Console.WriteLine("Turnstile UNLOCKED now. Press L key to lock turnstyle");
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();

            if (consoleKeyInfo.Key == ConsoleKey.L)
            {
                Console.WriteLine("Turnstile locking");
                FiniteStateMachine<TurnstileStates>.SetCurrentState(TurnstileStates.LOCKED);
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Q)
            {
                FiniteStateMachine<TurnstileStates>.SetCurrentState(TurnstileStates.EXIT);
            }

            else
            {
                Console.WriteLine("Turnstile already UNLOCKED. Press L key to lock turnstyle");
            }
        }
    }
    public enum TurnstileStates
    {
        LOCKED,
        UNLOCKED,
        EXIT,
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hello, FinitStateMachine!");

            TurnstileExit exitState = new ();

            FiniteStateMachine<TurnstileStates>.Add(new TurnstileLocked());
            FiniteStateMachine<TurnstileStates>.Add(new TurnstileUnlocked());
            FiniteStateMachine<TurnstileStates>.Add(exitState);
            FiniteStateMachine<TurnstileStates>.SetCurrentState(TurnstileStates.LOCKED);


            while (true)
            {
                FiniteStateMachine<TurnstileStates>.Update();
                if (FiniteStateMachine<TurnstileStates>.GetCurrentState()==exitState)
                {
                    break;
                }
            }
            Console.WriteLine("Press enter TO EXIT PROGRAM ...");
            Console.ReadLine();

        }
    }
}