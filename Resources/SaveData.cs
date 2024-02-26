using Godot;
using System;


namespace Resources
{
    public partial class SaveData : Resource
    {
        [ExportGroup("Volume Slider values")]
        [Export] public float masterVolume, soundFXVolume, musicVolume;
    }
}
