using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestForm.Game.Draw;

namespace TestForm.Game
{
    public class Ball : Sprite
    {

        private static float radius;

        public static float Radius
        {
            get { return Ball.radius; }
            set { Ball.radius = value; }
        }


        private static double initialSpeed;

        public static double InitialSpeed
        {
            get { return Ball.initialSpeed; }
            set { Ball.initialSpeed = value; }
        }

        private static Color _color = Color.White;

        private Random _random = new Random();
        private float _maxY;
        private float _minY;
        private float _maxX;
        private float _minX;
        private Wall _player1;
        private Wall _player2;
        private GameState _gameState;

        public Ball(float minX, float maxX, float minY, float maxY, GameState gameState,ref Wall player1, ref Wall player2)
        {
            //Keep a reference to the gamestate around for updating the scores
            _gameState = gameState;

            //Limits for the ball to bounce
            _minX = minX;
            _maxX = maxX;
            _minY = minY;
            _maxY = maxY;

            reset(); //Must be called after the limits are set since it uses them!

            //The bats to check for collisions with
            _player1 = player1;
            _player2 = player2;

            //Look & feel
            //control.BackColor = _color;
            //control.Width = _radius;
            //control.Height = _radius;
            setHeightWidth();

            //Preload the sound file
            //_beep.Load();

            this.Drawer = new BallDrawer(this);
        }


        /// <summary>
        /// Reset the ball - used at the start of the game and after a score
        /// </summary>
        private void reset()
        {
            //Start position, velocity and acceleration of a ball
            Location = new PointF((_maxX - _minX) / 2, (_maxY - _minY) / 2 + _random.Next(300) - 150);
            //The velocity is random. The random function (_random.Next(2) * 2) - 1) returns either +1 or -1
            Velocity = new PointF((float)Ball.InitialSpeed * ((_random.Next(2) * 2) - 1), (float)Ball.InitialSpeed *((_random.Next(2) * 2) - 1));
        }

        /*
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            base.Draw(g, p);
            Rectangle rect = new Rectangle((int)Location.X, (int)Location.Y, (int)Size.Width, (int)Size.Height);
            //g.FillRectangle(p.Brush, rect);
            g.DrawEllipse(p, rect);

            //Font myFont = new Font("Arial", 8, FontStyle.Regular);
            //g.DrawString(string.Format("X:{0} Y:{1}", ((int)Location.X).ToString(), ((int)Location.Y).ToString()), myFont, p.Brush, this.Location);
             
        }
        */

        /// <summary>
        /// Moves the ball handling bouncing off walls, bats and scoring when you miss
        /// </summary>
        /// <param name="gameTime">current time since start of game</param>
        /// <param name="elapsedTime">elapsed time since last frame</param>
        public override void Update(double gameTime, double elapsedTime)
        {
            //Bounce off the top and bottom limits
            if ((Location.Y < _minY && Velocity.Y < 0) ||
                (Location.Y > _maxY - Ball.Radius && Velocity.Y > 0))
            {
                Velocity.Y = -Velocity.Y;
            }

            //Bounce off the bats
            if ((Velocity.X < 0 && collision(_player1))
                || (Velocity.X > 0 && collision(_player2)))
            {
                Velocity.X = -Velocity.X;
            }

            //Check for the left and right limits and handle scoring and resetting the ball
            if (Location.X > _maxX - Ball.Radius)
            {
                //Score +1 for player 1
                _gameState.Player1Score++;
                reset();
            }

            if (Location.X < _minX)
            {
                //Score +1 for player 2
                _gameState.Player2Score++;
                reset();
            }

            //Do the ball animation
            base.Update(gameTime, elapsedTime);
        }


        /// <summary>
        /// Does a rectangle to rectangle test between this sprites rectangle and the passed in bat's rectangle
        /// See http://www.tekpool.com/?p=23 for an explanation of this algorithm
        /// </summary>
        /// <param name="bat">The bat to test for intersection with</param>
        /// <returns></returns>
        private bool collision(Wall bat)
        {
            return (bat.IsHit(this.Location.X,this.Location.Y));
        }


        /// <summary>
        /// Sets the sprite height and width from the control
        /// </summary>
        protected void setHeightWidth()
        {
            //Need to set the sprite height and width for collisions to work
            //Note that if the control height or width is changed AFTER the sprite is created this will break
            //in that case you would need to hook the Resize event on the control to keep these up to date
            Size.Height = Ball.Radius;
            Size.Width = Ball.Radius;
        }
    }
}
