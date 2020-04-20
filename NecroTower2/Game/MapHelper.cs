using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NecroTower2.Game
{
    static internal class MapHelper
    {
        public static void MapToScreen(Point mapCoords, PointF size, out PointF screenCoords)
        {
            screenCoords = new PointF
            {
                X = (mapCoords.X - mapCoords.Y) / 2.0f * size.X,
                Y = (mapCoords.X + mapCoords.Y) / 2.0f * size.Y
            };
        }

        public static void ScreenToMap(PointF screenCoords, PointF size, out Point mapCoords)
        {
            mapCoords = new Point
            {
                X = (int)Math.Floor((screenCoords.X + screenCoords.Y) / size.X),
                Y = (int)Math.Floor((screenCoords.Y - screenCoords.X) / size.Y)
            };
        }
    }
}
