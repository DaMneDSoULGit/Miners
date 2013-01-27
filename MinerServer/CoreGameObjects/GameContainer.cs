#region

using MinerServer.CoreItems;
using MinerServer.GameObjects;
using MinerServer.MapObjects;

#endregion

namespace MinerServer.CoreGameObjects
{
    public class GameContainer : IParent<Team>
    {
        GameContainer()
        {
            ChildList = Container.CreateContainer<Team>();
        }

        public readonly GameMap Map = new GameMap();

        public int LastGameObjectIndex;
        public IObjectContainer<Team> ChildList { get; set; }
    }
}