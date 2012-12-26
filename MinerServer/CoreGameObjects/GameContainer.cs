using System;
using MinerServer.CoreItems;
using MinerServer.GameObjects;
using MinerServer.MapObjects;

namespace MinerServer.CoreGameObjects
{
    public class GameContainer
    {
        private readonly GameList<GameObject> mainContainer = new GameList<GameObject>();

        public readonly GameMap Map = new GameMap();

        private readonly WeakGameList<Mine> mineContainer = new WeakGameList<Mine>();

        public void RegisterObject(GameObject gameObject)
        {
            mainContainer.Add(gameObject);
            switch (gameObject.GetObjectType)
            {
                case GameObjectType.TriggerObject:
                    break;
                case GameObjectType.Rocket:
                    break;
                case GameObjectType.Dinamite:
                    break;
                case GameObjectType.AIUnit:
                    break;
                case GameObjectType.Miner:
                    break;
                case GameObjectType.Mine:
                    mineContainer.Add((Mine)gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void UnregisterObject(GameObject gameObject)
        {
            mainContainer.Remove(gameObject);
            switch (gameObject.GetObjectType)
            {
                case GameObjectType.TriggerObject:
                    break;
                case GameObjectType.Rocket:
                    break;
                case GameObjectType.Dinamite:
                    break;
                case GameObjectType.AIUnit:
                    break;
                case GameObjectType.Miner:
                    break;
                case GameObjectType.Mine:
                    mineContainer.Remove((Mine)gameObject);
                    Map.RemoveFromMap(gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
