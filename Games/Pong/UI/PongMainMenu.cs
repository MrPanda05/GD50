using Godot;
using System;

namespace Pong
{
    public partial class PongMainMenu : Control
    {
        [ExportGroup("Scenes")]
        [Export] private Control settings;
        [Export] private Node2D PongScene;
        private Control Menu;

        private int itemSelected = 0;
        private bool endless = false;

        private SetPong setPong;
        private AudioStreamPlayer sound;

        public void OnOptionButtonItemSelected(int index)
        {
            itemSelected = index;
            sound.Play();
        }
        public void OnCheckButtonToggled(bool value)
        {
            endless = value;
            sound.Play();
        }
        public void OnPlayButtonDown()
        {
            Visible = false;
            PongScene.Visible = true;
            PongScene.ProcessMode = ProcessModeEnum.Inherit;
            setPong.SetGameMode(itemSelected, endless);
            sound.Play();
        }
        public void OnSettingsButtonDown()
        {
            settings.Visible = true;
            Menu.Visible = false;
            sound.Play();

        }
        public void OnQuitButtonDown()
        {
            GetTree().Quit();
        }

        public override void _Ready()
        {
            setPong = GetNode<SetPong>("../PongSceneGame/GAMEPLAY/SetPong");
            Menu = GetNode<Control>("Menu");
            sound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        }
    }
}
