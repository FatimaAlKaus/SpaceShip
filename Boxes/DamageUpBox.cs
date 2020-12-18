using Game.Boxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Boxes
{
    class DamageUpBox : Box
    {
        public DamageUpBox(Point location) : base(location)
        {

        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Red), Rectangle);
            graphics.DrawLine(new Pen(Color.White, 3), Location.X, Location.Y + Size.Height / 2, Location.X + Size.Width / 2, Location.Y + 2);
            graphics.DrawLine(new Pen(Color.White, 3), Location.X + Size.Width / 2, Location.Y + 2, Location.X + Size.Width, Location.Y + Size.Height / 2);
            graphics.DrawLine(new Pen(Color.White, 3), Location.X, Location.Y + Size.Height / 2 + 10, Location.X + Size.Width / 2, Location.Y + 2 + 10);
            graphics.DrawLine(new Pen(Color.White, 3), Location.X + Size.Width / 2, Location.Y + 2 + 10, Location.X + Size.Width, Location.Y + Size.Height / 2 + 10);


        }
        public override void Use(Ship ship)
        {
            ship.Damage += Value;
        }
    }
}
