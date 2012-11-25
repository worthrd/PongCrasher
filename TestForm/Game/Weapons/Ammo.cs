using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForm.Game.Weapons
{
    public class Ammo : Sprite
    {
        Int32 damagePower;

        public Int32 DamagePower
        {
            get { return damagePower; }
            set { damagePower = value; }
        }

    }
}
