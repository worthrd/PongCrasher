using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game.Draw
{
    public abstract class Drawer
    {

        public Drawer(Sprite s) 
        {
            S = s;
        }

        protected Graphics G
        {
            get { return GameSettings.GetInstance().Graphics; }
        }

        protected Pen P
        {
            get { return GameSettings.GetInstance().Pen; }
        }

        Sprite s;

        public Sprite S
        {
            get { return s; }
            set { s = value; }
        }
        public virtual void Draw() 
        {

        }
    }
}
