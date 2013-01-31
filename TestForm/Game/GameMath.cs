using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game
{
    public class GameMath
    {
        public static bool Collision(PointF pointA, PointF pointB, float spriteAWidth, float spriteBWidth)
        {
            float y2_y1 = pointA.Y - pointB.Y;
            float x2_x1 = pointA.X - pointB.X;
            float distance = (float)Math.Sqrt((Math.Pow(x2_x1, 2) + Math.Pow(y2_y1, 2)));

            if (distance <= spriteAWidth / 2 + spriteBWidth / 2)
            {
                return true;
            }
            return false;
        }
    }
}
