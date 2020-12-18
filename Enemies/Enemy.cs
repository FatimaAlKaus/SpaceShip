using Game.Boxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : GameObject, IDrawable,IFlyable
    {
        public virtual int Speed { get; set; } = 3;
        public int Health { get; set; } = 100;
        public int Damage { get; set; } = 5;
        public override Size Size { get; set; } = new Size(50, 50);
        public virtual void Draw(Graphics graphics)
        {

            graphics.DrawRectangle(new Pen(Color.Black, 1), Rectangle);
            graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(Location.X - Health / 2 + Size.Width / 2, Location.Y - 10), new Size(Health, 10)));
        }

        public virtual void Fly(int width = 0)
        {
            Location = new Point(this.Location.X, this.Location.Y + Speed);
        }

        public Enemy(Point point,int speed,int health)
        {
            Health = health;
            Speed = speed;
            Location = point;
        }
      
    }
}
