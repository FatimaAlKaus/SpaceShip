using Game.Boxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    class Bullet : GameObject, IDrawable, IFlyable
    {
        bool fill;
        public Bullet(Rectangle rectangle, Size size, bool fill = false, int speed = 10)
        {
            Size = size;
            this.fill = fill;
            Speed = speed;
            Location = new Point(rectangle.X + rectangle.Width / 2 - Size.Width / 2, rectangle.Y - Size.Height);
        }
        public override Size Size { get; set; } = new Size(10, 10);

        public virtual int Speed { get; set; }
        public void Draw(Graphics graphics)
        {
            if (fill)
                graphics.FillRectangle(new SolidBrush(Color.Black), Rectangle);
            else
                graphics.DrawEllipse(new Pen(Color.Blue, 1), Rectangle);
        }


        public void Fly(int width = 0)
        {
            if (fill)
                Location = new Point(this.Location.X, this.Location.Y + Speed);
            else
                Location = new Point(this.Location.X, this.Location.Y - Speed);
        }
    }
}
