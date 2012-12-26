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
        private readonly GameContainer gameContainer;
        public Point PrevPosition { get; private set; }

        public Point Position { get; set; }

        public virtual void OnGameTick()
        {
            tick++;
            if (tick >= EveryTickNumber) return;
            tick = 0;
            OnGameObjectTick();
        }

        public abstract int EveryTickNumber { get; }

        public abstract void OnGameObjectTick();

        private GameObject() { }

        protected GameObject(GameContainer container)
        {
            gameContainer = container;
            gameContainer.RegisterObject(this);
            Position = Point.EmptyPoint;
            PrevPosition = Point.EmptyPoint;
        }

        public void SynhPosition()
        {
            gameContainer.Map.SetPosition(this, PrevPosition, Position);
            PrevPosition = Position;
        }

        public bool IsPositionChanged
        {
            get { return Position.Equals(PrevPosition); }
        }

        protected void Delete()
        {
            gameContainer.UnregisterObject(this);
        }

        abstract public GameObjectType GetObjectType { get; }
    }
}
