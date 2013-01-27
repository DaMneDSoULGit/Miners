using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.CoreGameObjects;
using MinerServer.CoreItems;

namespace MinerServer.GameObjects
{
    public abstract class Unit : ChildBase<Player>
    {

        protected Unit(GameContainer container, Player parent)
            : base(container, parent)
        {
        }

        public virtual void Die()
        {

        }

        public virtual void Damage(double amount)
        {

        }

    }

}
