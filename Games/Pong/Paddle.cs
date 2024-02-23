using Godot;
using System;
using Commons.Components;


namespace Pong
{ 
    public partial class Paddle : CharacterBody2D
    {
        [ExportGroup("Paddle propreties")]
        [Export] private float paddleSpeed { get; set; }
        [Export] private bool isBot;

        [ExportGroup("Player inputs")]
        [Export] private string up, down;

        private Vector2 vel;
        private PaddleInputHandler PaddleInputHandler;

        public void Movement(Vector2 input)
        {
            vel.X = 0;
            vel.Y = input.Y * paddleSpeed;
            MoveAndSlide();
            Velocity = vel;
        }
        public void MovementAI()
        {

        }

        public override void _Ready()
        {
            vel = Velocity;
            if(!isBot) PaddleInputHandler = GetNode<PaddleInputHandler>("PaddleInputHandler");
        }

        public override void _PhysicsProcess(double delta)
        {
            if(!isBot) Movement(PaddleInputHandler.GetInput(up, down));
            else MovementAI();
        }
    }
}

