using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestForm.Game.Draw;
using System.Windows.Forms;

namespace TestForm.Game
{
    public abstract class Sprite
    {
        public PointF Location;
        public PointF Velocity;
        public SizeF Size;
        
        Drawer drawer;

        public Drawer Drawer
        {
            get { return drawer; }
            set { drawer = value; }
        }


        public Sprite()
        {
        }
        public Sprite(float x, float y, float width, float height,Drawer drawer) :this(x, y, width, height)
        {
            this.Drawer = drawer;
        }
        public Sprite(float x, float y, float width, float height) 
        {
            Location.X = x;
            Location.Y = y;
            Size.Width = width;
            Size.Height = height;
        }

        public virtual void Update(double gameTime, double elapsedTime) 
        {
            //Move the sprite based on the velocity
            Location.X += Velocity.X * (float)elapsedTime;
            Location.Y += Velocity.Y * (float)elapsedTime;
        }

        public virtual void Draw() 
        {
            Drawer.Draw();
        }

        public virtual void KeyPress(Char keyChar) 
        {
        
        }

    }
}
