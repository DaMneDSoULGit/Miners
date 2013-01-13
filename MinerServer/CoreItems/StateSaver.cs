namespace MinerServer.CoreItems
{
    internal struct StateSaver<T> where T : struct
    {
        private T value;

        public StateSaver(T value)
            : this()
        {
            this.value = value;
        }

        public bool HasChanges { get; private set; }

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                HasChanges = true;
            }
        }

        public void ResetItem()
        {
            HasChanges = false;
        }
    }
}