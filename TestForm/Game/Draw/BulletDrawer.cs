﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game.Draw
{
    public class BulletDrawer : Drawer
    {
        public BulletDrawer(Sprite s) : base(s) 
        {
        
        }
        public override void Draw()
        {
            base.Draw();
            if (GameSettings.GetInstance().BallMaxX>S.Location.X && GameSettings.GetInstance().BallMaxY > S.Location.Y)
            {
                G.DrawEllipse(P, S.Location.X, S.Location.Y, S.Size.Width, S.Size.Height);
            }
            
        }
    }
}
