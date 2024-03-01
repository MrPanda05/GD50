using Godot;
using System;

namespace Commons.FiniteStateMachine
{
    public partial class State : Node
    {
        public FSM Fsm;
        public virtual void Readys() { }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update(float delta) { }
        public virtual void FixUpdate(float delta) { }
        public virtual void HandleInput(InputEvent @event) { }

    }
}