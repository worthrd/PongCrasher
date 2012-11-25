using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForm.Game.Weapons
{
    public class Bullet : Ammo
    {
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            base.Draw(g, p);
            g.DrawEllipse(p, this.Location.X, this.Location.Y, this.Size.Width,this.Size.Height);
        }
    }
}
