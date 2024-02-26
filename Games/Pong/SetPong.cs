using Godot;


namespace Pong
{
    public partial class SetPong : Node2D
    {
        [ExportGroup("Needs")]
        [Export] private Paddle player1, player2;
        [Export] private PongStats stats;

        public void SetGameMode(int mode, bool endless)
        {
            stats.isInf = endless;
            switch (mode)
            {
                case 0:
                    player1.SetIsBot(false);
                    player2.SetIsBot(false);
                    break;
                case 1:
                    player1.SetIsBot(false);
                    player2.SetIsBot(true);
                    break;
                case 2:
                    player1.SetIsBot(true);
                    player2.SetIsBot(true);
                    break;
            }

        }
    }
}
