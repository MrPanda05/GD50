using Commons.Components;
using Godot;
using System;


namespace Pong
{
    public partial class PongStats : Node2D
    {
        public int player1Points { get; private set; } = 0;
        public int player2Points { get; private set; } = 0;


        private Timer timer;

        [ExportGroup("vars")]
        [Export] public int maxPoints = 10;
        [Export] public bool isInf;
        [ExportGroup("Objects")]
        [Export] private Label player1ScoreLabel, player2ScoreLabel, restartLabel;
        [Export] private Ball ball;

        private AudioStreamPlayer sound1, sound2;

        public void OnScoreUpdate()
        {
            player1ScoreLabel.Text = player1Points.ToString();
            player2ScoreLabel.Text = player2Points.ToString();
        }
        public void OnTimerTimeout()
        {
            RestartGame();
        }
        public void RestartGame()
        {
            ball.ResetBall();
        }
        public void RestartScore()
        {
            player1Points = 0;
            player2Points = 0;
            player1ScoreLabel.Text = "0";
            player2ScoreLabel.Text = "0";
        }

        public void OnPlayer2ScoreAreaAreaEntered(Area2D area)
        {
            if (area.GetParent().GetNode<CharacterBody2D>(".").Velocity.X < 0)
            {
                GD.Print("Player 2 score");
                player2Points++;
                sound1.Play();
            }
            else
            {
                GD.Print("Player 1 score");
                sound2.Play();
                player1Points++;
            }
            OnScoreUpdate();
            if(!isInf)
            {
                if(player2Points >= maxPoints)
                {
                    GD.Print("Player 2 wins");
                    restartLabel.Text = "Player 2 wins! \n Press 'R' to restart";
                    restartLabel.Visible = true;
                    ball.stop = true;
                    return;
                }
                if (player1Points >= maxPoints)
                {
                    GD.Print("Player 1 wins");
                    restartLabel.Text = "Player 1 wins! \n Press 'R' to restart";
                    restartLabel.Visible = true;
                    ball.stop = true;
                    return;
                }
            }
            timer.Start();
        }
        public override void _Ready()
        {
            timer = GetNode<Timer>("Timer");
            sound1 = GetNode<AudioStreamPlayer>("AudioStreamPlayer1");
            sound2 = GetNode<AudioStreamPlayer>("AudioStreamPlayer2");
            PongRestarter.OnRestart += RestartScore;
        }
    }
}
