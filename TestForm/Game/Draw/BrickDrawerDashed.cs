using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game.Draw
{
    public class BrickDrawerDashed : BrickDrawer
    {
        public BrickDrawerDashed(Sprite s) : base(s) { }

        public override void Draw()
        {
            Pen myPen = new Pen(Brushes.WhiteSmoke, 1);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            G.DrawEllipse(myPen, S.Location.X, S.Location.Y, S.Size.Width, S.Size.Height);

        }
    }
}
