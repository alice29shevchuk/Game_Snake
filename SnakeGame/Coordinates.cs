using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char ch { get; set; }
        public Coordinates()
        {
            X = 0;
            Y = 0;        
        }
        public Coordinates(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
