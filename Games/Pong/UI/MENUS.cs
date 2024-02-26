using Godot;
using System;
using System.ComponentModel;


namespace Pong
{
    public partial class MENUS : Node2D, IDisposable
    {
        [Export] private Control Settings, Pause;


        public void SetVisibility()
        {
            if(Settings.Visible)
            {
                Settings.Visible = false;
                Pause.Visible = false;
                return;
            }
            Pause.Visible = !Pause.Visible;
        }
        public override void _Ready()
        {
            PongRestarter.OnMenuButtonDown += SetVisibility;
        }
        public override void _ExitTree()
        {
            PongRestarter.OnMenuButtonDown -= SetVisibility;
        }

        
    }
}
