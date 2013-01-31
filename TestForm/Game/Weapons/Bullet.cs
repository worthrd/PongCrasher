using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestForm.Game.Draw;

namespace TestForm.Game.Weapons
{
    public class Bullet : Ammo
    {

        public Bullet(Sprite owner) : base(owner)
        {
            this.Location.X = Owner.Location.X + Owner.Size.Width;
            this.Size.Width = this.Size.Height =  GameSettings.GetInstance().BulletWidthHeight;
            this.Location.Y = Owner.Location.Y - (Owner.Size.Height - this.Size.Height) / 2 ;
            this.DamagePower = 10;
            this.Drawer = new BulletDrawer(this);
        }

     
        public override void Update(double gameTime, double elapsedTime)
        {
            base.Update(gameTime, elapsedTime);
            if (!IsDraw)
            {
                this.Location.Y = Owner.Location.Y - (Owner.Size.Height - this.Size.Height) / 2;
            }

        }
    }
}
