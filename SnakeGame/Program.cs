using System;
using System.Threading;
namespace SnakeGame
{
    class Program
    {
        static Action? action = null;
        static ConsoleKeyInfo key;
        static Snake snake = new Snake();
        static void Main(string[] args)
        {
            Thread thread = new Thread(_start);
            thread.Start();
            snake.Show();
            do
            {
                Thread.Sleep(400);
                Console.Clear();
                action?.Invoke();
                snake.Show(); 
            }
            while (snake.Alive!=false);
            Console.Write("Нажмите любую кнопку, чтобы выйти...");
        }
        private static void _start(object?obj)
        {
            do
            {
                    key = Console.ReadKey(true);
                    Thread.Sleep(350);
                    Console.CursorVisible = false;
                    if (key.Key == ConsoleKey.UpArrow) action = snake.Up;
                    if (key.Key == ConsoleKey.DownArrow) action = snake.Down;
                    if (key.Key == ConsoleKey.LeftArrow) action = snake.Left;
                    if (key.Key == ConsoleKey.RightArrow) action = snake.Right;
            } while (snake.Alive != false);
        }
    }
}
