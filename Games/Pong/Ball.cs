using Godot;
using System;
using Commons.Components;


namespace Pong
{
    public partial class Ball : CharacterBody2D
    {
        [ExportGroup("Ball propreties")]
        [Export] private float ballSpeed { get; set; } = 500f;

        private Vector2 vel;

        private KinematicCollision2D collision;

        private SoundPool sound;
        public bool stop = false;

        public void Movement(float delta)
        {
            collision = MoveAndCollide(vel * delta);
            if (collision != null)
            {
                sound.PlayRandomSound();
                vel = vel.Bounce(collision.GetNormal());
                vel.X *= (float)GD.RandRange(1.05f, 1.1f);
                vel.Y *= (float)GD.RandRange(1.05f, 1.1f);
                vel = new Vector2(Mathf.Clamp(vel.X, -3000, 3000f), Mathf.Clamp(vel.Y, -3000, 3000f));
            }
        }

        public void ResetBall()
        {
            stop = false;
            Position = new Vector2(1920/2, 1080/2);
            vel = Velocity;
            vel = GD.Randf() > 0.5f ? new Vector2(ballSpeed, (float)GD.RandRange(-ballSpeed, ballSpeed)) : new Vector2(-ballSpeed, -(float)GD.RandRange(-ballSpeed, ballSpeed));
        }


        public override void _Ready()
        {
            vel = Velocity;
            sound = GetNode<SoundPool>("SoundPool");
            vel = GD.Randf() > 0.5f ? new Vector2(ballSpeed, (float)GD.RandRange(-ballSpeed, ballSpeed)) : new Vector2(-ballSpeed, -(float)GD.RandRange(-ballSpeed, ballSpeed));
            PongRestarter.OnRestart += ResetBall;
        }

        public override void _ExitTree()
        {
            PongRestarter.OnRestart -= ResetBall;
        }
        public override void _PhysicsProcess(double delta)
        {
            if(stop)
            {
                Position = new Vector2(1920 / 2, 1080 / 2);
                return;
            }
            Movement((float)delta);
            Velocity = vel;

        }
    }
}
