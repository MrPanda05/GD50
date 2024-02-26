using Godot;
using System;
using Commons.Components;


namespace Pong
{
    public partial class PongRestarter : Node2D
    {
        [ExportGroup("Objects")]
        [Export] private CharacterBody2D player1, player2, ball;
        [Export] private Label startLabel;
        private Control PauseMenu;
        private AudioStreamPlayer sound;

        public static Action OnRestart, OnMenuButtonDown;
        
        public void PauseGame()
        {
            GetTree().Paused = !GetTree().Paused;
        }
        public void RestartGame()
        {
            OnRestart?.Invoke();
            ball.ProcessMode = ProcessModeEnum.Disabled;
            player1.ProcessMode = ProcessModeEnum.Disabled;
            player2.ProcessMode = ProcessModeEnum.Disabled;
            startLabel.Visible = true;
        }
        public void StartGame()
        {
            if(!startLabel.Visible) return;
            ball.ProcessMode = ProcessModeEnum.Inherit;
            player1.ProcessMode = ProcessModeEnum.Inherit;
            player2.ProcessMode = ProcessModeEnum.Inherit;
            startLabel.Visible = false;
            sound.Play();
        }

        public override void _Process(double delta)
        {
            if(Input.IsActionJustPressed("Start"))
            {
                StartGame();
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
            if (Input.IsActionJustPressed("Menu") && GetNode<Node2D>("../../").Visible)
            {
                PauseGame();
                OnMenuButtonDown?.Invoke();
                return;
            }
        }
        public override void _Ready()
        {
            PauseMenu = GetNode<Control>("../../MENUS/PongPause");
            sound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        }
    }
}
