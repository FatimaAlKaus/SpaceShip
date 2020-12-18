using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Boxes
{
    class BoxUp : Box
    {
        public BoxUp(Point location) : base(location)
        {

        }
        public override void Draw(Graphics graphics)
        {

            graphics.FillRectangle(new SolidBrush(Color.Green), Location.X + 15, Location.Y + 5, 10, 30);
            graphics.FillRectangle(new SolidBrush(Color.Green), Location.X + 5, Location.Y + 15, 30, 10);
        }
        public override void Use(Ship ship)
        {
            Box.Value++;
        }
    }
}
