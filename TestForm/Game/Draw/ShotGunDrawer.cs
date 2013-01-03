using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestForm.Game.Weapons;
using System.Drawing;

namespace TestForm.Game.Draw
{
    public class ShotGunDrawer : Drawer
    {
        ShotGun g;
        public ShotGunDrawer(Sprite s) : base(s) 
        {
            g = s as ShotGun;
        }

        public override void Draw()
        {
            base.Draw();

            //Draw paralel two line for shotgun
            //First line
            G.DrawLine(P,
                new Point((int)g.Location.X,
                (int)(g.Owner.Location.Y + g.Owner.Size.Height / 2 - Brick.Height / 2)),
                new Point((int)g.Location.X + (int)g.Size.Width,
                    (int)(g.Owner.Location.Y + g.Owner.Size.Height / 2 - Brick.Height / 2)));
            //Second line paralel the first line
            G.DrawLine(P,
                new Point((int)g.Location.X,
                (int)(g.Owner.Location.Y + g.Owner.Size.Height / 2 + Brick.Height / 2)),
                new Point((int)g.Location.X + (int)g.Size.Width,
                 (int)(g.Owner.Location.Y + g.Owner.Size.Height / 2 + Brick.Height / 2)));
        }
    }
}
