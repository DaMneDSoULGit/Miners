using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.Helpers;
using MinerServer.CoreGameObjects;
using MinerServer.CoreItems;

namespace MinerServer.GameObjects
{
    public class Player : ChildBase<Team>, IParent<Unit>
    {
        public Player(GameContainer container, Team parent)
            : base(container, parent)
        {
            ChildList = Container.CreateContainer<Unit>();
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

        public IObjectContainer<Unit> ChildList { get; set; }
    }
}
