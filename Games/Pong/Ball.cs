using Godot;
using System;


namespace Pong
{
    public partial class Ball : CharacterBody2D
    {
        [ExportGroup("Ball propreties")]
        [Export] private float ballSpeed { get; set; } = 500f;

        private Vector2 vel;

        private KinematicCollision2D collision;

        public void Movement(float delta)
        {
            collision = MoveAndCollide(vel * delta);
            if (collision != null)
            {
                vel = vel.Bounce(collision.GetNormal());
                vel.X *= (float)GD.RandRange(1.05f, 1.1f);
                vel.Y *= (float)GD.RandRange(1.05f, 1.1f);
                vel = new Vector2(Mathf.Clamp(vel.X, -3000, 3000f), Mathf.Clamp(vel.Y, -3000, 3000f));
            }
        }

        public void ResetBall()
        {
            Position = new Vector2(1920/2, 1080/2);
            vel = Velocity;
            vel = GD.Randf() > 0.5f ? new Vector2(ballSpeed, (float)GD.RandRange(-ballSpeed, ballSpeed)) : new Vector2(-ballSpeed, -(float)GD.RandRange(-ballSpeed, ballSpeed));
        }


        public override void _Ready()
        {
            vel = Velocity;
            vel = GD.Randf() > 0.5f ? new Vector2(ballSpeed, (float)GD.RandRange(-ballSpeed, ballSpeed)) : new Vector2(-ballSpeed, -(float)GD.RandRange(-ballSpeed, ballSpeed));
            PongRestarter.OnRestart += ResetBall;
        }

        public override void _PhysicsProcess(double delta)
        {
            Movement((float)delta);
            Velocity = vel;

        }
    }
}
