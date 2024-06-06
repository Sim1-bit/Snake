using System;
using System.Collections.Generic;
using System.IO;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using static System.Formats.Asn1.AsnWriter;


namespace Snake
{
    class Program
    {
        public static RenderWindow window;
        public const int proportion = 50;

        public static Snake snake;
        public static Apple apple;
        static void Main(string[] args)
        {
            window = new RenderWindow(new VideoMode(15 * proportion, 15 * proportion), "Snake");
            window.SetVerticalSyncEnabled(true);
            window.Closed += (sender, args) => Close();

            window.KeyPressed += KeyPressed;

            snake = new Snake();
            apple = new Apple(snake.body);

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                
                snake.Draw();
                apple.Draw();

                window.Display();
            }
        }

        public static void KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Up:
                    if(snake.direction != Snake.Direction.Down)
                        snake.direction = Snake.Direction.Up;
                    break;
                case Keyboard.Key.Down:
                    if (snake.direction != Snake.Direction.Up)
                        snake.direction = Snake.Direction.Down;
                    break;
                case Keyboard.Key.Left:
                    if (snake.direction != Snake.Direction.Right)
                        snake.direction = Snake.Direction.Left;
                    break;
                case Keyboard.Key.Right:
                    if (snake.direction != Snake.Direction.Left)
                        snake.direction = Snake.Direction.Right;
                    break;
            }
            Console.WriteLine("Key:");
            Console.WriteLine(snake.direction);
            Console.WriteLine(snake.Head);
        }

        public static void Close()
        {
            window.Close();
        }
    }
}
