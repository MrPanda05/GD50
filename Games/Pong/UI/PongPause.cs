using Commons.Components;
using Godot;
using Pong;
using System;


namespace Pong
{
    public partial class PongPause : Control
    {
		[Export] private Control settings;
		[Export] private PongRestarter restarter;
		private Node2D pongScene;
		private Control PongUIMain;
        private AudioStreamPlayer sound;
        public void OnSettingsButtonDown()
	    {
		    settings.Visible = true;
		    Visible = false;
            sound.Play();

        }
        public void OnQuitButtonDown()
		{
			GetTree().Quit();
		}
		public void OnRestartButtonDown()
		{
            restarter.RestartGame();
			restarter.PauseGame();
			Visible = false;
            sound.Play();


        }
        public void OnMenuButtonDown()
		{
			Visible = false;
            restarter.RestartGame();
            restarter.PauseGame();
            pongScene.Visible = false;
            PongUIMain.Visible = true;
            sound.Play();

        }
        public override void _Ready()
        {
			pongScene = GetNode<Node2D>("../../");
			PongUIMain = GetNode<Control>("../../../PongMainMenu");
            sound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        }
    }
}
