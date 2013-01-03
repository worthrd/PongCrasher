using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForm.Game.Weapons
{
    public class Ammo : Sprite
    {
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

        public override void Draw()
        {
            if (IsDraw)
            {
                base.Draw();
            }
        }

    }
}
