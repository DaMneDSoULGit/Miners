using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.CoreGameObjects;

namespace MinerServer.GameObjects
{
    abstract class HealthUnit : Unit
    {
        protected HealthUnit(GameContainer container, Player parent)
            : base(container, parent)
        {
        }

        public double CurrentHp { get; set; }
        public double MaxHp { get; set; }
        public double MaxMp { get; set; }
        public double CurrentMp { get; set; }

        public override void Damage(double amount)
        {
            base.Damage(amount);
            CurrentHp -= amount;
            if (CurrentHp < 0)
            {
                Die();
            }
        }
    }
}
