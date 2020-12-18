using Game.Boxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Boxes
{
    class BulletSizeBox : Box
    {
        public BulletSizeBox(Point location) : base(location)
        {

        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Brown), Rectangle);
            graphics.FillEllipse(new SolidBrush(Color.Black), Rectangle);
            graphics.FillEllipse(new SolidBrush(Color.White), new Rectangle(Location.X + 5, Location.Y + 5, 10, 10));

        }
        public override void Use(Ship ship)
        {
            ship.BulletSize = new Size(ship.BulletSize.Width + Value, ship.BulletSize.Height);
        }
    }
}
