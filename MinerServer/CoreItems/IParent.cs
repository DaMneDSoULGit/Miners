namespace MinerServer.CoreItems
{
    public interface IParent
    {
    }

    public interface IParent<T> : IParent where T : class, IChild
    {
        IObjectContainer<T> ChildList { get; set; }
    }
}