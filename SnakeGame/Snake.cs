using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    class Snake
    {
        public List<Coordinates> coordinates { get; set; }
        public bool Alive { get; private set; }
        public string _Snake { get; set; }
        Meal food;
        public Snake(int x,int y)
        {
            coordinates = new List<Coordinates>();
            coordinates.Add(new Coordinates(x, y));
        }
        public Snake()
        {
            Alive = true;
            _Snake = "*";
            coordinates = new List<Coordinates>();
            coordinates.Add(new Coordinates(1, 1));
            food= new Meal();
        }
        public bool Crashed()
        {
            for (int i = coordinates.Count-2; i > 0; i--)
            {
                if(coordinates[coordinates.Count - 1].X == coordinates[i].X && coordinates[coordinates.Count - 1].Y == coordinates[i].Y) return true;
            }
            return false;
        }
        public void Border()
        {
            int height = 29;
            int width = 119;
            for (int i = 0; i < width; i++)
            {
                Console.Write("#");
                if (i == width - 1)
                {
                    for (int l = 0; l < height; l++)
                    {
                        Console.Write("\n#");
                        if (l == height - 1)
                        {
                            for (int m = 0; m < width - 1; m++)
                            {
                                Console.Write("#");
                            }
                        }
                        else
                        {
                            for (int d = 0; d < width - 2; d++)
                            {
                                Console.Write(" ");
                            }
                            Console.Write("#");
                        }
                    }
                }
            }
        }
        public void Show()
        {
            Border();
            for (int i = 0; i < coordinates.Count; i++)
            {
                if(coordinates[i].X == 0 || coordinates[i].Y == 0 || coordinates[i].X == 118 || coordinates[i].Y == 29 || Crashed())
                {
                    Alive = false;
                    Console.Clear();
                    Console.WriteLine("Game over:(");
                    return;
                }
                Console.SetCursorPosition(coordinates[i].X, coordinates[i].Y);
                Console.Write("*");
                Console.SetCursorPosition(food.X, food.Y);
                Console.Write("@");
            }
        }
        public void Up()
        {
            if(coordinates[coordinates.Count-1].X == food.X && coordinates[coordinates.Count - 1].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count-1].X, coordinates[coordinates.Count - 1].Y-1));
                food = new Meal();
            }
            for (int i = coordinates.Count - 1; i > 0; i--)
            {
                coordinates[i].X = coordinates[i-1].X;
                coordinates[i].Y = coordinates[i-1].Y;
            }
            coordinates[0].Y--;
        }
        public void Down()
        {
            if (coordinates[coordinates.Count - 1].X == food.X && coordinates[coordinates.Count - 1].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count - 1].X, coordinates[coordinates.Count - 1].Y+1));
                food = new Meal();
            }
            for (int i = coordinates.Count - 1; i > 0; i--)
            {
                coordinates[i].X = coordinates[i-1].X;
                coordinates[i].Y = coordinates[i-1].Y;
            }
            coordinates[0].Y++;
        }
        public void Left()
        {
            if (coordinates[coordinates.Count - 1].X == food.X && coordinates[coordinates.Count - 1].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count - 1].X-1, coordinates[coordinates.Count - 1].Y));
                food = new Meal();
            }
            for (int i = coordinates.Count - 1; i > 0; i--)
            {
                coordinates[i].X = coordinates[i-1].X;
                coordinates[i].Y = coordinates[i-1].Y;
            }
            coordinates[0].X--;
        }
        public void Right()
        {
            if (coordinates[coordinates.Count - 1].X == food.X && coordinates[coordinates.Count - 1].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count - 1].X+1, coordinates[coordinates.Count - 1].Y));
                food = new Meal();
            }
            for (int i = coordinates.Count - 1; i > 0; i--)
            {
                coordinates[i].X = coordinates[i-1].X;
                coordinates[i].Y = coordinates[i-1].Y;
            }
            coordinates[0].X++;
        }
    }
}
