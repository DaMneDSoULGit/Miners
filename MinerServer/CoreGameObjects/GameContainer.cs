using System;
using MinerServer.CoreItems;
using MinerServer.GameObjects;
using MinerServer.MapObjects;

namespace MinerServer.CoreGameObjects
{
    public class GameContainer
    {
        private readonly DynamicList<GameObject> mainContainer = new DynamicList<GameObject>();

        public readonly GameMap Map = new GameMap();

        public int LastGameObjectIndex;

        private readonly WeakObjectContainer<Mine> mineContainer = new WeakObjectContainer<Mine>();

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
