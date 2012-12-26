using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.CoreGameObjects;
using MinerServer.CoreItems;

namespace MinerServer.MapObjects
{
    public class MapCell
    {
        private byte type;
        private byte height;
        private readonly int x;
        private readonly int y;

        private readonly WeakGameList<GameObject> objectInCell;

        public MapCell(byte type, int x, int y)
        {
            this.type = type;
            this.x = x;
            this.y = y;
            objectInCell = new WeakGameList<GameObject>();
            height = 0;
        }

        public WeakGameList<GameObject> ObjectsInCell
        {
            get { return objectInCell; }
        }

        public bool Equals(MapCell mapCell)
        {
            return x == mapCell.x && y == mapCell.y;
        }
    }
}
