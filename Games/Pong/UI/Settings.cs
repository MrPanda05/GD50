using Commons.Components;
using Commons.Singletons;
using Godot;
using System;


namespace Pong
{
	public partial class Settings : Control
	{
		[Export] private Control node;

		private Slider masterSlider, soundSlider, musicSlider;

		private AudioStreamPlayer sound;
		public void OnReturnButtonDown()
		{
			Visible = false;
			if(node != null)
			{
				node.Visible = true;
			}
            sound.Play();
        }

        public override void _Ready()
        {
			masterSlider = GetNode<Slider>("VolumeSlider/Master");
            soundSlider = GetNode<Slider>("VolumeSlider/SoundFX");
            musicSlider = GetNode<Slider>("VolumeSlider/Music");
            sound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			SaveSystem.Add("masterVolume", 25);
            SaveSystem.Add("musicVolume", 25);
            SaveSystem.Add("soundFXVolume", 25);
			masterSlider.Value = (double)SaveSystem.GetValue("masterVolume");
            soundSlider.Value = (double)SaveSystem.GetValue("soundFXVolume");
            musicSlider.Value = (double)SaveSystem.GetValue("musicVolume");


        }
        public float ScaleDecibels(float value)
        {
            float scale = 20.0f;
            float divisor = 50.0f;
            return scale * (float)Math.Log10(value / divisor);
        }
		public void OnMasterValueChanged(float value)
		{
			SaveSystem.Update("masterVolume", Mathf.RoundToInt(value));
			AudioServer.SetBusVolumeDb(0, ScaleDecibels(value));
		}
        public void OnSoundFxValueChanged(float value)
        {
            SaveSystem.Update("soundFXVolume", Mathf.RoundToInt(value));
            AudioServer.SetBusVolumeDb(1, ScaleDecibels(value));
        }
        public void OnMusicValueChanged(float value)
        {
            SaveSystem.Update("musicVolume", Mathf.RoundToInt(value));
            AudioServer.SetBusVolumeDb(2, ScaleDecibels(value));
        }
    }
}
