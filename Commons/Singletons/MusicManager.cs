using Godot;
using System;


namespace Commons.Singletons
{
    public partial class MusicManager : Node
    {
        [ExportGroup("Musics")]
        [Export] private Godot.Collections.Array<AudioStreamWav> musics  = new Godot.Collections.Array<AudioStreamWav>();

        public AudioStreamPlayer musicPlayer;

        public static MusicManager Instance { get; private set;}

        public override void _Ready()
        {
            Instance = this;
            musicPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        }

        public void StopMusic()
        {
            musicPlayer.Stop();
        }
        public void PlayMusic(int id)
        {
            if(id > musics.Count -1) return;
            if(id < 0) return;
            if(musics[id] == null) return;
            if(musicPlayer.Stream != musics[id])
            {
                musicPlayer.Stream = musics[id];
            }
            musicPlayer.Play();
        }
    }
}
