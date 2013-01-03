using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestForm.Game.Draw;

namespace TestForm.Game.Weapons
{
    public class Bullet : Ammo
    {

        public Bullet(Sprite owner) 
        {
            this.owner = owner;
            this.Location.X = Owner.Location.X + Owner.Size.Width;
            //this.Location.Y = Owner.Location.Y + Owner.Size.Height / 2;
            this.Location.Y = 100;
            this.Size.Width = this.Size.Height =  GameSettings.GetInstance().BulletWidthHeight;
            this.DamagePower = 10;
            this.Drawer = new BulletDrawer(this);
        }

        Sprite owner;

        public Sprite Owner
        {
            get { return owner; }
            set { owner = value; }
        }
    }
}
