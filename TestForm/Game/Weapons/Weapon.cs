using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestForm.Game.Weapons;
using System.Windows.Forms;

namespace TestForm.Game
{
    public class Weapon : Sprite
    {
        string name = "Weapon";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        List<Ammo> arsenal = new List<Ammo>();

        public List<Ammo> Arsenal
        {
            get { return arsenal; }
            set { arsenal = value; }
        }

        Int64 avaliableShot;

        public Int64 AvaliableShot
        {
            get { return avaliableShot; }
            set { avaliableShot = value; }
        }

        Sprite owner;

        public Sprite Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        Sprite oppenent;

        public Sprite Oppenent
        {
            get { return oppenent; }
            set { oppenent = value; }
        }


        Sprite ball;

        public Sprite Ball
        {
            get { return ball; }
            set { ball = value; }
        }

        Char usageKey = 'a';

        public Char UsageKey
        {
            get { return usageKey; }
            set { usageKey = value; }
        }


        public override void Draw()
        {
            base.Draw();
            foreach (Ammo item in Arsenal)
            {
                item.Draw();
            }
        }


        public override void Update(double gameTime, double elapsedTime)
        {
            base.Update(gameTime, elapsedTime);
            foreach (Ammo item in Arsenal)
            {
                item.Update(gameTime, elapsedTime);
            }

        }

        public virtual void Use() 
        {
            Ammo ammo = Arsenal.FirstOrDefault(a=>a.IsDraw==false);
            if (ammo != null)
            {
                ammo.IsDraw = true;
                ammo.Velocity.X = GameSettings.GetInstance().AmmoSpeed;
            }
        }

        public override void KeyPress(Char key)
        {
            base.KeyPress(key);
            if (key==UsageKey)
            {
                Use();
            }
        }
 
    }
}
