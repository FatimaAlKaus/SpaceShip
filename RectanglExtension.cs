using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class RectanglExtension
    {
        public static bool IsCrossed(this Rectangle rectangleA, Rectangle rectangleB)
        {
            //return (rectangleA.Y < rectangleB.Y + rectangleB.Height
            //    || rectangleA.Y + rectangleA.Height > rectangleB.Y
            //    || rectangleA.X + rectangleA.Width < rectangleB.X 
            //    || rectangleA.X > rectangleB.X + rectangleB.Width);
            var ax = rectangleA.X;
            var ax1 = rectangleA.X+rectangleA.Width;
            var ay = rectangleA.Y;
            var ay1 = rectangleA.Y+rectangleA.Height;

            var bx =  rectangleB.X;
            var bx1 = rectangleB.X + rectangleA.Width;
            var by =  rectangleB.Y;
            var by1 = rectangleB.Y + rectangleA.Height;
            return (
   (
     (
       (ax >= bx && ax <= bx1) || (ax1 >= bx && ax1 <= bx1)
     ) && (
       (ay >= by && ay <= by1) || (ay1 >= by && ay1 <= by1)
     )
   ) || (
     (
       (bx >= ax && bx <= ax1) || (bx1 >= ax && bx1 <= ax1)
     ) && (
       (by >= ay && by <= ay1) || (by1 >= ay && by1 <= ay1)
     )
   )
 ) || (
   (
     (
       (ax >= bx && ax <= bx1) || (ax1 >= bx && ax1 <= bx1)
     ) &&(
       (by >= ay && by <= ay1) || (by1 >= ay && by1 <= ay1)
     )
   ) || (
     (
       (bx >= ax && bx <= ax1) || (bx1 >= ax && bx1 <= ax1)
     ) &&(
       (ay >= by && ay <= by1) || (ay1 >= by && ay1 <= by1)
     )
   )
 );
        }
    }
}


