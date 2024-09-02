// this code from https://github.com/shamim-akhtar/fsm-generic
// site https://faramira.com/generic-finite-state-machine-using-csharp/
// under MIT license

namespace Patterns
{
    public static class FiniteStateMachine<T>
    {
        // A Finite State Machine
        //    - consists of a set of states,
        //    - and at any given time, an FSM can exist in only one 
        //      State out of these possible set of states.

        // A dictionary to represent the a set of states.
        public static Dictionary<T, State<T>> mStates = new Dictionary<T, State<T>>();

        // The current state.
        public static State<T>? mCurrentState;


        public static void Add(State<T> state)
        {
            mStates.Add(state.ID, state);
        }

        public static void Add(T stateID, State<T> state)
        {
            mStates.Add(stateID, state);
        }

        public static State<T>? GetState(T stateID)
        {
            if (mStates.ContainsKey(stateID))
                return mStates[stateID];
            return null;
        }

        public static void SetCurrentState(T stateID)
        {
            State<T> state = mStates[stateID];
            SetCurrentState(state);
        }

        public static State<T>? GetCurrentState()
        {
            return mCurrentState;
        }

        public static void SetCurrentState(State<T> state)
        {
            if (mCurrentState == state)
            {
                return;
            }

            if (mCurrentState != null)
            {
                mCurrentState.Exit();
            }

            mCurrentState = state;

            if (mCurrentState != null)
            {
                mCurrentState.Enter();
            }
        }

        public static void Update()
        {
            if (mCurrentState != null)
            {
                mCurrentState.Update();
            }
        }
    }
}