namespace MinerServer.CoreGameObjects
{
    public abstract class GameObject
    {
        private int tick;

        protected GameObject(GameContainer container)
        {
            Index = container.LastGameObjectIndex++;
        }

        public int Index { get; private set; }

        public abstract int EveryTickNumber { get; }

        public virtual void OnGameTick()
        {
            tick++;
            if (tick < EveryTickNumber) return;
            tick = 0;
            OnGameObjectTick();
        }

        public abstract void OnGameObjectTick();
    }
}