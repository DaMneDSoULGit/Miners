#region

using MinerServer.MapObjects;

#endregion

namespace MinerServer.CoreGameObjects
{
    public class GameContainer
    {
        public readonly GameMap Map = new GameMap();

        public int LastGameObjectIndex;
    }
}