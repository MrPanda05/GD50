using Godot;
using System;

namespace Commons.Components
{
    public partial class HealthComponent : Node2D
    {
        [Export] private float health;
        [Export] private float maxHealth;

        [Export] private bool wantsToFree;

        public Action OnDeath;
        private void Death()
        {
            if(wantsToFree)
            {
                GD.Print("Got queuefree");
                GetParent().QueueFree();
            }
            else
            {
                GD.Print("Got Disable");
                Node2D parent = (Node2D)GetParent();
                parent.Visible = false;
                parent.ProcessMode = ProcessModeEnum.Disabled;
            }
        }
        public void Damage(int amount = 1)
        {
            health -= amount;
            if (health <= 0)
            {
                GD.Print("Death");
                Death();
                OnDeath?.Invoke();
            }
        }
        
    }
}
