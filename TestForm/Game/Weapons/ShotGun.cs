using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForm.Game.Weapons
{
    public class ShotGun : Weapon
    {
        public ShotGun(Sprite owner, Sprite oppenent,Sprite ball)
        {
            Owner = owner;
            Oppenent = oppenent;
            Ball = ball;


            Location.X = owner.Location.X + owner.Size.Width + Brick.Width;


        }
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            base.Draw(g, p);
            //Draw weapon in front of player
        }
    }
}
