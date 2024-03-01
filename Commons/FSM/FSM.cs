using Godot;
using System;
using System.Collections.Generic;


namespace Commons.FiniteStateMachine
{
    public partial class FSM : Node
    {
        [Export] public NodePath InitialState;

        private Dictionary<string, State> states;
        private State currentState;
        public Action<string> OnStateChange;

        public override void _Ready()
        {
            states = new Dictionary<string, State>();
            foreach (Node node in GetChildren())
            {
                if (node is State s)
                {
                    states[node.Name] = s;
                    s.Fsm = this;
                    s.Readys();
                    s.Exit();
                }
            }

            currentState = GetNode<State>(InitialState);
            currentState?.Enter();
        }

        public override void _Process(double delta)
        {
            currentState?.Update((float)delta);
        }
        public override void _PhysicsProcess(double delta)
        {
            currentState?.FixUpdate((float)delta);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            currentState?.HandleInput(@event);
        }

        public void TransitioToState(string key)
        {
            if(!states.ContainsKey(key) || currentState == states[key]) return;
            OnStateChange?.Invoke(key);
            currentState.Exit();
            currentState = states[key];
            currentState.Enter();

        }
        public void ForceNull()
        {
            currentState.Exit();
            currentState = null;
            OnStateChange?.Invoke("null");
        }
    }
}