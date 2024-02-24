using Godot;
using System;


namespace Pong
{
    public partial class PongRestarter : Node2D
    {
        [ExportGroup("Objects")]
        [Export] private CharacterBody2D player1, player2, ball;
        [Export] private Label startLabel;
        private Control PauseMenu;

        public static Action OnRestart;
        //public void RestartGame()
        //{
        //    GetTree().ReloadCurrentScene();
        //}
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
                OnRestart?.Invoke();
                ball.ProcessMode = ProcessModeEnum.Disabled;
                player1.ProcessMode = ProcessModeEnum.Disabled;
                player2.ProcessMode = ProcessModeEnum.Disabled;
                startLabel.Visible = true;
                return;
            }
            if (Input.IsActionJustPressed("Pause"))
            {
                PauseGame();
                return;
            }
            if (Input.IsActionJustPressed("Menu"))
            {
                PauseGame();
                PauseMenu.Visible = !PauseMenu.Visible;
                return;
            }
        }
        public override void _Ready()
        {
            PauseMenu = GetNode<Control>("../../PongPause");
        }
    }
}
