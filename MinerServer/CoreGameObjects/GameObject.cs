using MinerServer.CoreItems;
using MinerServer.MapObjects;

namespace MinerServer.CoreGameObjects
{
    public enum GameObjectType
    {
        TriggerObject,
        Rocket,
        Dinamite,
        AIUnit,
        Miner,
        Mine,
    }

    public abstract class GameObject
    {
        private int tick;
        private readonly WeakObject<GameContainer> container;
        public Point PrevPosition { get; private set; }

        public Point Position { get; set; }

        public virtual void OnGameTick()
        {
            tick++;
            if (tick >= EveryTickNumber) return;
            tick = 0;
            OnGameObjectTick();
        }

        public int Index { get; private set; }

        public abstract int EveryTickNumber { get; }

        public abstract void OnGameObjectTick();

        private GameObject() { }

        protected GameObject(GameContainer container)
        {
            Index = container.LastGameObjectIndex++;
            this.container = new WeakObject<GameContainer>(container);
            this.container.Value.RegisterObject(this);
            Position = Point.EmptyPoint;
            PrevPosition = Point.EmptyPoint;
        }

        public void SynhPosition()
        {
            container.Value.Map.SetPosition(this, PrevPosition, Position);
            PrevPosition = Position;
        }

        public bool IsPositionChanged
        {
            get { return Position.Equals(PrevPosition); }
        }

        protected void Delete()
        {
            container.Value.UnregisterObject(this);
        }

        abstract public GameObjectType GetObjectType { get; }
    }
}
