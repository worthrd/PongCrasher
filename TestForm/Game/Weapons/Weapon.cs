﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestForm.Game.Weapons;

namespace TestForm.Game
{
    public class Weapon : Sprite
    {
        List<Ammo> arsenal = new List<Ammo>();

        public List<Ammo> Arsenal
        {
            get { return arsenal; }
            set { arsenal = value; }
        }

        Int32 damagePower;

        public Int32 DamagePower
        {
            get { return damagePower; }
            set { damagePower = value; }
        }

        Int64 avaliableShot;

        public Int64 AvaliableShot
        {
            get { return avaliableShot; }
            set { avaliableShot = value; }
        }

        UsageType usageType;

        public UsageType UsageType
        {
            get { return usageType; }
            set { usageType = value; }
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

        public virtual void Use() 
        {
        
        }
    }

    public enum UsageType 
    {
       Duration,
       Usage
    }
}
