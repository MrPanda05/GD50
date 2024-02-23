using Godot;
using System;


namespace Pong
{
    public partial class PongRestarter : Node2D
    {
        [ExportGroup("Objects")]
        [Export] private CharacterBody2D player1, player2, ball;
        [Export] private Label startLabel;

        public void RestartGame()
        {
            GetTree().ReloadCurrentScene();
        }
        public void PauseGame()
        {
            GetTree().Paused = !GetTree().Paused;
        }

        public override void _Process(double delta)
        {
            if(Input.IsActionJustPressed("Start"))
            {
                ball.ProcessMode = ProcessModeEnum.Inherit;
                player1.ProcessMode = ProcessModeEnum.Inherit;
                player2.ProcessMode = ProcessModeEnum.Inherit;
                startLabel.Visible = false;
                return;

            }
            if (Input.IsActionJustPressed("Restart"))
            {
                RestartGame();
                return;
            }
            if (Input.IsActionJustPressed("Pause"))
            {
                PauseGame();
                return;
            }
            if (Input.IsActionJustPressed("Menu"))
            {
                //Add later
                return;
            }
        }
    }
}
