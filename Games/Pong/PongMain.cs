using Commons.Singletons;
using Godot;
using System;


namespace Pong
{
    public partial class PongMain : Node2D
    {
        public override void _Ready()
        {
            MusicManager.Instance.PlayMusic(0);
        }
    }
}
