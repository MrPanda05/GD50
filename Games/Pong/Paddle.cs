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
        [Export] private float paddleMaxY, paddleMinY, paddleMinX, paddleMaxX;
        private Sprite2D paddleSprite;

        [ExportGroup("Player inputs")]
        [Export] private string up, down;

        private Vector2 vel, startPos;
        private PaddleInputHandler PaddleInputHandler;
        private CharacterBody2D ball;

        public void Movement(Vector2 input)
        {
            vel.X = 0;
            vel.Y = input.Y * paddleSpeed;
            MoveAndSlide();
            Velocity = vel;
        }

        public void Restart()
        {
            Position = startPos;
        }
        public void SetIsBot(bool value)
        {
            isBot = value;
        }
        public void MovementAI(float delta)
        {
            if (Name == "Player1" && (ball.Velocity.X > 0 || ball.Position.X < 0)) return;
            if (Name == "Player2" && (ball.Velocity.X < 0 || ball.Position.X > 1920)) return;

            float dist = ball.Position.Y - Position.Y;
            GD.Print(dist);
            if(Mathf.Abs(dist) > 75)
            {
                if (ball.Position.Y > Position.Y)
                {
                    vel = Vector2.Down * paddleSpeed;
                }
                else
                {
                    vel = Vector2.Up * paddleSpeed;
                }
            }
            else
            {
                vel.Y = dist * (paddleSpeed* 1.8f) * delta;
            }
            MoveAndSlide();
            Velocity = vel;
        }

        public override void _Ready()
        {
            vel = Velocity;
            paddleSprite = GetNode<Sprite2D>("Sprite2D");
            ball = GetNode<CharacterBody2D>("../Ball");
            startPos = Position;
            if (!isBot) PaddleInputHandler = GetNode<PaddleInputHandler>("PaddleInputHandler");
            PongRestarter.OnRestart += Restart;
        }

        public override void _PhysicsProcess(double delta)
        {
            if(!isBot) Movement(PaddleInputHandler.GetInput(up, down));
            else MovementAI((float) delta);
            Position = new Vector2(Mathf.Clamp(Position.X, paddleMinX, paddleMaxX), Mathf.Clamp(Position.Y, paddleMaxY, paddleMinY));
        }
    }
}

