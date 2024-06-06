using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Snake
{
    class Apple
    {
        public Vector2i index;
        public RectangleShape shape;
        public Apple(List<Vector2i> snake)
        {
            shape = new RectangleShape()
            {
                FillColor = Color.Red,
                Size = new Vector2f(Program.proportion, Program.proportion),
            };

            Eat(snake);
        }

        public void Eat(List<Vector2i> snake)
        {
            index = new Vector2i(new Random().Next(0, (int)(Program.window.Size.X / Program.proportion)), new Random().Next(0, (int)(Program.window.Size.Y / Program.proportion)));
            for(int i = 0; i < snake.Count; i++)
            {
                if (snake[i].X == index.X && snake[i].Y == index.Y)
                {
                    Eat(snake);
                    break;
                }
            }
            shape.Position = new Vector2f(index.X * Program.proportion, index.Y * Program.proportion);
        }

        public bool isEaten(List<Vector2i> snake)
        {
            if(index.X == snake[0].X && index.Y == snake[0].Y)
            {
                Eat(snake);
                return true;

            }

            return false;
        }

        public void Draw()
        {
            Program.window.Draw(shape);
        }
    }
}
