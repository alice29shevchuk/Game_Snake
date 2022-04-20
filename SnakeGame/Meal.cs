using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Meal:Coordinates
    {
        Random rand = new Random();
        public Meal()
        {
            X = rand.Next(1, 118);
            Y = rand.Next(1, 29);
        }
    }
}
