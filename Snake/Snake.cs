using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{
    class Snake
    {
        public enum Direction
        {
            Up,
            Down, 
            Left, 
            Right
        }

        public Direction direction;
        public List<Vector2i> body = new List<Vector2i>();

        private RectangleShape shape;

        private bool isDeath;

        private Thread move;

        public Vector2i Head
        {
            get => body[0];

            set
            {
                if(body[0].X < 0 || body[0].X > Program.window.Size.X / Program.proportion - 1 || body[0].Y < 0 || body[0].Y > Program.window.Size.Y / Program.proportion - 1)
                    Program.Close();
                else
                    body[0] = value;
            }
        }
        public Snake()
        {
            shape = new RectangleShape()
            {
                Size = new Vector2f(Program.proportion, Program.proportion),
            };
            body.Add(new Vector2i(7, 7));
            body.Add(new Vector2i(6, 7));
            body.Add(new Vector2i(5, 7));

            isDeath = false;

            direction = Direction.Right;

            /*move = new Thread(() => Move());
            move.Start();*/
        }

        public bool IsTouchingHimSelf()
        {
            for(int i = 1; i < body.Count; i++)
            {
                if (Head.X == body[i].X && Head.Y == body[i].Y)
                    return true;
            }
            return false;
        }

        public void Move()
        {                

            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i] = new Vector2i(body[i - 1].X, body[i - 1].Y);
            }
            switch (direction)
            {
                case Direction.Left:
                    Head = new Vector2i(body[0].X - 1, body[0].Y);
                    break;
                case Direction.Right:
                    Head = new Vector2i(body[0].X + 1, body[0].Y);
                    break;
                case Direction.Up:
                    Head = new Vector2i(body[0].X, body[0].Y - 1);
                    break;
                case Direction.Down:
                    Head = new Vector2i(body[0].X, body[0].Y + 1);
                    break;
            }
            if(IsTouchingHimSelf())
                Program.Close();
            Thread.Sleep(250);
            if (Program.apple.isEaten(body))
                body.Add(new Vector2i(body[body.Count - 1].X, body[body.Count - 1].Y));
            Console.WriteLine("Move:");
            Console.WriteLine(direction);
            Console.WriteLine(Head);
        }

        public void Draw()
        {
            Move();
            for(int i = 0; i < body.Count; i++)
            {
                if(i == 0)
                    shape.FillColor = Color.White;
                else if(i == 1)
                    shape.FillColor = Color.Green;

                shape.Position = new Vector2f(body[i].X * Program.proportion, body[i].Y * Program.proportion);
                Program.window.Draw(shape);
            }
        }

        public bool Death()
        {
            return true;
        }
    }
}
