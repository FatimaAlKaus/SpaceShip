using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class GameObject
    {
        virtual public Point Location { get; set; }
        virtual public Size Size { get; set; }
        virtual public Rectangle Rectangle { get => new Rectangle(Location, Size); }
    }
}
