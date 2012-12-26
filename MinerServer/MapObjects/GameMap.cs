using System;
using System.Collections.Generic;
using System.Linq;
using MinerServer.CoreGameObjects;

namespace MinerServer.MapObjects
{
    public class GameMap
    {
        public const double CellSize = 100;

        private MapCell[,] map;

        private int xSize;
        private int ySize;

        public void Initialize(int xSizeInt, int ySizeInt)
        {
            xSize = xSizeInt;
            ySize = ySizeInt;
            map = new MapCell[xSizeInt, ySizeInt];
            for (int i = 0; i < xSizeInt; i++)
            {
                for (int j = 0; j < ySizeInt; j++)
                {
                    map[i, j] = new MapCell(1, i, j);
                }
            }
        }

        private MapCell GetCellByPoint(Point point)
        {
            int x = (int)(point.X / CellSize);
            int y = (int)(point.Y / CellSize);
            return map[x, y];
        }


        public void SetPosition(GameObject gameObject, Point oldValue, Point value)
        {
            if (oldValue.IsEmpty)
            {
                GetCellByPoint(value).ObjectsInCell.Add(gameObject);
            }
            else
            {
                MapCell oldContainer = GetCellByPoint(oldValue);
                MapCell newContainer = GetCellByPoint(value);
                if (!oldContainer.Equals(newContainer))
                {
                    oldContainer.ObjectsInCell.Remove(gameObject);
                    newContainer.ObjectsInCell.Add(gameObject);
                }
            }
        }

        public IEnumerable<MapCell> CellsInRange(Point point, double range)
        {
            int px = (int)(point.X / CellSize);
            int py = (int)(point.Y / CellSize);
            int step = ((int)(range / CellSize)) + 1;

            int startx = Math.Max(0, px - step);
            int endx = Math.Min(xSize, px + step);
            int starty = Math.Max(0, py - step);
            int endy = Math.Min(ySize, py + step);

            for (int x = startx; x < endx; x++)
            {
                for (int y = starty; y < endy; y++)
                {
                    yield return map[x, y];
                }
            }
        }

        public void RemoveFromMap(GameObject obj)
        {
            GetCellByPoint(obj.Position).ObjectsInCell.Remove(obj);
        }

        public IEnumerable<GameObject> ObjectsInRange(Point point, double range)
        {
            IEnumerable<MapCell> cells = CellsInRange(point, range);
            return cells.SelectMany(x => x.ObjectsInCell).Where(x => Point.IsInRange(x.Position, point, range));
        }

    }
}
