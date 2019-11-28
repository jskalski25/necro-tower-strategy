using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project5.GridElementsRepo.BuildingTypes;

namespace Project5
{
    internal static class MapTemplates
    {
        ///<summary>
        ///Pusta mapa
        ///</summary>
        public static List<Tile> GetSample1(int size, Terrain terrain)
        {
            var tiles = new List<Tile>();
            for (int y = 0; y < size; ++y)
            {
                for (int x = 0; x < size; ++x)
                {
                    Tile tile = new Tile(x, y, terrain);
                    tiles.Add(tile);
                }
            }

            return tiles;
        }

        ///<summary>
        ///Mapa z zamkami
        ///</summary>
        public static List<Tile> GetSample2(int size, Terrain terrain)
        {
            var tiles = new List<Tile>();
            for (int y = 0; y < size; ++y)
            {
                for (int x = 0; x < size; ++x)
                {
                    Tile tile = new Tile(x, y, terrain);

                    //Generowanie zamku pierwszego gracza
                    if (x == 0 && y == 0)
                    {
                        tile.Items.Add(new Castle());
                    }

                    //Generowanie zamku drugiego gracza
                    if (x == size - 1 && y == size - 1)
                    {
                        tile.Items.Add(new Castle());
                    }

                    tiles.Add(tile);
                }
            }

            return tiles;
        }
    }
}
