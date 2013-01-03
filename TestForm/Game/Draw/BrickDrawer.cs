using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game.Draw
{
    public class BrickDrawer : Drawer
    {
        public BrickDrawer(Sprite s) : base(s) { }

        public override void Draw()
        {
            base.Draw();
            G.DrawEllipse(P, S.Location.X, S.Location.Y, S.Size.Width, S.Size.Height);
        }
    }
}
