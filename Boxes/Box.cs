using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Boxes
{
    abstract class Box : GameObject, IFlyable, IDrawable
    {
        public Box(Point location)
        {
            Location = location;
            Size = new Size(30, 30);
        }
        public static int Value = 10;
        public virtual int Speed { get; set; } = 2;

        public abstract void Use(Ship ship);

        //ship.MaxHP += Value;

        virtual public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Brown), Rectangle);
        }


        public void Fly(int width = 0)
        {
            Location = new Point(Location.X, Location.Y + Speed);
        }
    }
}
