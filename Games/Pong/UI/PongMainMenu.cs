using Godot;
using System;

namespace Pong
{
    public partial class PongMainMenu : Control
    {
        [ExportGroup("Scenes")]
        [Export] private Control settings;
        [Export] private Node2D PongScene;

        private int itemSelected = 0;
        private bool endless = false;

        private SetPong setPong;

        public void OnOptionButtonItemSelected(int index)
        {
            itemSelected = index;
        }
        public void OnCheckButtonToggled(bool value)
        {
            endless = value;
        }
        public void OnPlayButtonDown()
        {
            Visible = false;
            PongScene.Visible = true;
            PongScene.ProcessMode = ProcessModeEnum.Inherit;
            setPong.SetGameMode(itemSelected, endless);
        }

        public override void _Ready()
        {
            setPong = GetNode<SetPong>("../PongScene/SetPong");
        }
    }
}
