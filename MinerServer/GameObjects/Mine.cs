using MinerServer.CoreGameObjects;

namespace MinerServer.GameObjects
{
    class Mine : GameObject
    {
        public Mine(GameContainer container)
            : base(container)
        {

        }

        public override int EveryTickNumber
        {
            get { return 2; }
        }
        
        public override void OnGameObjectTick()
        {

        }



        public override GameObjectType GetObjectType
        {
            get { return GameObjectType.Mine; }
        }
    }

}
