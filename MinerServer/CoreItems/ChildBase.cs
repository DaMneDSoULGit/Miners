#region

using MinerServer.CoreGameObjects;

#endregion

namespace MinerServer.CoreItems
{
    public interface IChild
    {
    }

    public abstract class ChildBase<TParent> : GameObject, IChild where TParent : class, IParent
    {
        private readonly WeakObject<GameContainer> containerObject;
        private readonly WeakObject<TParent> parentObject;

        protected ChildBase(GameContainer container, TParent parent) : base(container)
        {
            containerObject = new WeakObject<GameContainer>(container);
            parentObject = new WeakObject<TParent>(parent);
        }

        public TParent Parent
        {
            get { return parentObject.Value; }
        }

        public GameContainer GameContainer
        {
            get { return containerObject.Value; }
        }
    }
}