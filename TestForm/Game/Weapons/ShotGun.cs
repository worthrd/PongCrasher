using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestForm.Game.Draw;

namespace TestForm.Game.Weapons
{
    public class ShotGun : Weapon
    {
        public ShotGun(Sprite owner, Sprite oppenent,Sprite ball)
        {
            this.Name = "ShotGun";
            Owner = owner;
            Oppenent = oppenent;
            Ball = ball;
            Size.Width = 4 * Brick.Width;
            Location.X = Owner.Location.X + Owner.Size.Width + Brick.Width;
            Location.Y = Owner.Location.Y + Owner.Size.Height / 2;
            Size.Height = Brick.Height;
            for (int i = 0; i < GameSettings.GetInstance().DefaultAmmo; i++)
            {
                Arsenal.Add(new Bullet(this));
            }
            this.Drawer = new ShotGunDrawer(this);
        }

        
        public override void Update(double gameTime, double elapsedTime)
        {
            base.Update(gameTime, elapsedTime);
            Location.X = Owner.Location.X + Owner.Size.Width + Brick.Width;
            Location.Y = Owner.Location.Y + Owner.Size.Height / 2;
        }
        /*
        public override void Use()
        {

        }
        */
    }
}
