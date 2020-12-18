using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Boxes
{
    class BigHealthBox : HealthBox
    {
        public BigHealthBox(Point location) : base(location)
        {
            Size = new Size(50, 50);
        }

        public override Point Location { get => base.Location; set => base.Location = value; }



        public override void Draw(Graphics graphics)
        {
            //graphics.FillRectangle(new SolidBrush(Color.Red), Rectangle);
            int thic = 10;
            graphics.FillRectangle(new SolidBrush(Color.Red), Location.X + Size.Width / 2 - thic / 2, Location.Y, thic, Size.Height);
            graphics.FillRectangle(new SolidBrush(Color.Red), Location.X, Location.Y + Size.Height / 2 - thic / 2, Size.Width, thic);
        }






        public override void Use(Ship ship)
        {
            ship.Health = ship.MaxHP;
        }
    }
}
