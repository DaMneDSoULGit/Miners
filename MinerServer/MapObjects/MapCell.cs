#region

using MinerServer.CoreItems;

#endregion

namespace MinerServer.MapObjects
{
    public class MapCell
    {
        private readonly WeakGameObjectList objectInCell;
        private readonly int x;
        private readonly int y;
        private byte height;
        private byte type;

        public MapCell(byte type, int x, int y)
        {
            this.type = type;
            this.x = x;
            this.y = y;
            objectInCell = new WeakGameObjectList();
            height = 0;
        }

        public WeakGameObjectList ObjectsInCell
        {
            get { return objectInCell; }
        }

        public bool Equals(MapCell mapCell)
        {
            return x == mapCell.x && y == mapCell.y;
        }
    }
}