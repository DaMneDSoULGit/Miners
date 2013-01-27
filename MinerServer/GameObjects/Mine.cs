using MinerServer.CoreGameObjects;

namespace MinerServer.GameObjects
{
    public abstract class Mine : Unit
    {
        protected Mine(GameContainer container, Player parent)
            : base(container, parent)
        {
        }
    }
}