using Game.Boxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Boxes
{
    class MaxHPBox:Box
    {
        public MaxHPBox(Point location) : base(location)
        {

        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Red), Rectangle);
            graphics.FillRectangle(new SolidBrush(Color.Black), Location.X + 10, Location.Y + 5, 10, 20);
            graphics.FillRectangle(new SolidBrush(Color.Black), Location.X + 5, Location.Y + 10, 20, 10);
        }
        public override void Use(Ship ship)
        {
            ship.MaxHP += Value;
        }
    }
}
