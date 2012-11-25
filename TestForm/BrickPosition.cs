using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForm
{
    public class BrickPosition
    {
        int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        int player;

        public int Player
        {
            get { return player; }
            set { player = value; }
        }
    }
}
