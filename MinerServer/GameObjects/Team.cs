using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.CoreGameObjects;
using MinerServer.CoreItems;
using MinerServer.Helpers;

namespace MinerServer.GameObjects
{
    public class Team : ChildBase<GameContainer>, IParent<Player>
    {
        public Team(GameContainer container, GameContainer parent)
            : base(container, parent)
        {
            ChildList = Container.CreateContainer<Player>();
        }

        public override int EveryTickNumber
        {
            get { return 1; }
        }

        public override void OnGameObjectTick()
        {
            throw new NotImplementedException();
        }

        public override void OnGameTick()
        {
            base.OnGameTick();
            ChildList.Invoke(x => x.OnGameTick());
        }

        public IObjectContainer<Player> ChildList { get; set; }
    }
}
