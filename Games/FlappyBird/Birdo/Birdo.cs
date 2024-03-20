using Godot;
using System;
using Commons.FiniteStateMachine;

namespace FlappyBird.Birdo
{
    public partial class Birdo : CharacterBody2D
    {
        [ExportGroup("Birdo stats")]
        [Export] private float jumpForce = 800f;
        [Export] private float gravity = 2500f;

        private FSM myFSM, gameFSM;

        private Vector2 vel;

        public override void _Ready()
        {
            gameFSM = GetNode<FSM>("../../GameFSM");
            myFSM = GetNode<FSM>("BirdoFSM");
            vel = Velocity;
        }
        public void Jump()
        {
            GD.Print("jump");
            vel.Y = -jumpForce;
            Velocity = vel;
            MoveAndSlide();
        }
        public void AddGravity(float delta)
        {

            if (IsOnFloor()) return;
            vel.Y += Mathf.Clamp(gravity * delta, -1200, 1200);
            Velocity = vel;
            MoveAndSlide();
        }
    }
}
