using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestForm.Game.Draw;

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

        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Brick(float x, float y, float width, float height) : base(x, y, width, height) 
        {
            this.Drawer = new BrickDrawer(this);  
        }

        public Brick(float x, float y, float width, float height,int id)
            : base(x, y, width, height)
        {
            Id = id;
            this.Drawer = new BrickDrawer(this); 
        }

    }
}
