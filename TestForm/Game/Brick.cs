using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game
{
    public class Brick:Sprite
    {
        private static float width;

        public static float Width
        {
            get { return Brick.width; }
            set { Brick.width = value; }
        }

        private static float height;

        public static float Height
        {
            get { return Brick.height; }
            set { Brick.height = value; }
        }

        //bool isDrawn = true;

        //public bool IsDrawn
        //{
        //    get { return isDrawn; }
        //    set { isDrawn = value; }
        //}

        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Brick(float x, float y, float width, float height) : base(x, y, width, height) 
        {
           
        }

        public Brick(float x, float y, float width, float height,int id)
            : base(x, y, width, height)
        {
            Id = id;
        }

        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            base.Draw(g, p);
            g.DrawEllipse(p, Location.X, Location.Y, Size.Width, Size.Height);
            //g.DrawRectangle(p, Location.X, Location.Y, Size.Width, Size.Height);
            //Font myFont = new Font("Arial", 8, FontStyle.Regular);
            //g.DrawString(string.Format("X:{0} Y:{1}", ((int)Location.X).ToString(), ((int)Location.Y).ToString()), myFont, p.Brush, this.Location);
        }

        public void DrawDashed(System.Drawing.Graphics g) 
        {
            Pen myPen = new Pen(Brushes.WhiteSmoke, 1);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawEllipse(myPen, Location.X, Location.Y, Size.Width, Size.Height);
            
        }
    }
}
