using System;
using System.Collections.Generic;

public class StateMachine
{
    private Dictionary<Type, State> _states = new Dictionary<Type, State>();
    protected State CorrectState;

    public void Update()
    {
        CorrectState?.Update();
    }

    public void Add(State state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : State
    {
        var type = typeof(T);

        if (CorrectState.GetType() == type)
        {
            return;
        }

        if (_states.TryGetValue(type, out var newState))
        {
            CorrectState?.Exit();
            CorrectState = newState;
            newState?.Enter();
        }
    }
}