// this code from https://github.com/shamim-akhtar/fsm-generic
// site https://faramira.com/generic-finite-state-machine-using-csharp/
// under MIT license

namespace Patterns
{
    public class State<T>
    {
        // The name for the state.
        public string? Name { get; set; }

        // The ID of the state.
        public T ID { get; private set; }

        public State(T id)
        {
            ID = id;
        }
        public State(T id, string name) : this(id)
        {
            Name = name;
        }

        public delegate void DelegateNoArg();

        public DelegateNoArg? OnEnter;
        public DelegateNoArg? OnExit;
        public DelegateNoArg? OnUpdate;        

        public State(T id,
            DelegateNoArg onEnter,
            DelegateNoArg onExit = null,
            DelegateNoArg onUpdate = null) : this(id)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;            
        }
        public State(T id,
            string name,
            DelegateNoArg onEnter,
            DelegateNoArg onExit = null,
            DelegateNoArg onUpdate = null) : this(id, name)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;            
        }

        virtual public void Enter()
        {
            OnEnter?.Invoke();
        }

        virtual public void Exit()
        {
            OnExit?.Invoke();
        }
        virtual public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}