using Godot;
using System;

namespace Commons.Components
{
    public partial class HitboxComponent : Area2D
    {
        [Export] private HealthComponent healthComponent;

        public void Damage(int amount = 1)
        {
            healthComponent?.Damage(amount);
        }
    }
}
