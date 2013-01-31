using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForm.Game.Weapons
{
    public class Ammo : Sprite
    {

        public Ammo(Sprite owner) 
        {
            this.Owner = owner;
        }

        Sprite owner;

        public Sprite Owner
        {
            get { return owner; }
            set { owner = value; }
        }


        bool isDraw = false;

        public bool IsDraw
        {
            get { return isDraw; }
            set { isDraw = value; }
        }

        Int32 damagePower;

        public Int32 DamagePower
        {
            get { return damagePower; }
            set { damagePower = value; }
        }

        public override void Update(double gameTime, double elapsedTime)
        {
            base.Update(gameTime, elapsedTime);
            if (IsDraw)
            {
                Weapon w = Owner as Weapon;
                if (w != null)
                {
                    Wall p2 = w.Oppenent as Wall;
                    if (p2 != null)
                    {
                        if (p2.IsHit(this.Location.X, this.Location.Y, this.Size.Width)) 
                        {
                            IsDraw = false;
                        }
                    }
                }
            }
        
        }

        public override void Draw()
        {
            if (IsDraw)
            {
                base.Draw();
            }
        }

    }
}
