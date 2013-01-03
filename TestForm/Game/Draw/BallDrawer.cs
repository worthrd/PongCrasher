using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game.Draw
{
    public class BallDrawer : Drawer
    {
        public BallDrawer(Sprite s) : base(s) 
        {
        
        }

        public override void Draw()
        {
            base.Draw();
            Rectangle rect = new Rectangle((int)S.Location.X, (int)S.Location.Y, (int)S.Size.Width, (int)S.Size.Height);
            G.DrawEllipse(P, rect);
        }
    }
}
