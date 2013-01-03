using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForm.Game.Draw
{
    public class WallDrawer : Drawer
    {
        Wall w;
        public WallDrawer(Sprite s) : base(s) 
        {
            w = this.S as Wall;
        }

        public override void Draw()
        {
            base.Draw();
            int id = 0;
            

            w.Bricks = new List<Brick>();
            for (int i = 0; i < w.NumberOfLines; i++)
            {
                for (int j = 0; j < w.BricksOnALine; j++)
                {

                    float _x = w.Location.X + i * Brick.Width;
                    float _y = w.Location.Y + j * Brick.Height;

                    if (w.IsBrickDrawn(id))
                    {

                        Brick b = new Brick(_x, _y, Brick.Width, Brick.Height, id);
                        b.Draw();
                        //b.Draw(g, p);

                        //Test Lines
                        //PointF pBall = new PointF(Ball.Location.X + Ball.Radius / 2, Ball.Location.Y + Ball.Radius / 2);
                        //PointF pBrick = new PointF(b.Location.X + Brick.Width / 2, b.Location.Y + Brick.Width / 2);
                        //g.DrawLine(pLine, pBall, pBrick);
                        w.Bricks.Add(b);

                    }
                    else
                    {
                        Brick b = new Brick(_x, _y, Brick.Width, Brick.Height, id);
                        b.Drawer = new BrickDrawerDashed(b);
                        b.Draw();
                        //b.DrawDashed(g);

                    }
                    id += 1;
                }
            }
        }
    }
}
