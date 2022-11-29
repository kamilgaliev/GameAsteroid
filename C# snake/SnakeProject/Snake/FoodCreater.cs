using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreater
    {
        int mapWidth;
        int mapHeight;
        char sym;

        Random random = new Random();

        public FoodCreater(int mapWidth, int mapHeight, char sym)
        {
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x,y,sym);
        }
    }
}
