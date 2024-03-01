using Commons.FiniteStateMachine;
using Godot;
using System;


namespace FlappyBird.Birdo.States
{
	public partial class BirdoPlayState : State
	{
        private Birdo birdo;
        public override void Readys()
        {
            birdo = GetNode<Birdo>("../../");
        }
        public override void FixUpdate(float delta)
        {
            birdo.AddGravity(delta);
            if(Input.IsActionJustPressed("Up"))
            {
                birdo.Jump();
            }
        }
    }
}
