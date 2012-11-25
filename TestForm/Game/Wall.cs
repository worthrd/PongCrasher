using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TestForm.Game
{
    public class Wall:Sprite
    {

        #region AI constants and variables
        private const float _lookDistance = 300f;   //How close is the ball to the bat before the AI kicks in
        private float _estimatedLocation = -1;      //A 'guess' at the Y position where the ball will hit the bat
        #endregion

        #region Look and feel of the bat
        //public const int Width = 20;
        //public const int Height = 100;

        static float width;

        public static float Width
        {
            get { return Wall.width; }
            set { Wall.width = value; }
        }

        static float height;

        public static float Height
        {
            get { return Wall.height; }
            set { Wall.height = value; }
        }

        private static Color _batColor = Color.White;
        private const double _speed = 500;
        #endregion

        #region Keyboard controls and keyboard state for those keys
        private Keys _upKey;
        private Keys _downKey;
        private bool _isUpKeyPressed;
        private bool _isDownKeyPressed;
        #endregion

        public float MaxPosition;
        public float MinPosition;
        public Ball Ball;
        private bool _isHuman;
        private static Random _random = new Random();

        List<Brick> bricks;
        List<int> hits;

        public List<int> Hits
        {
            get { return hits; }
            set { hits = value; }
        }

        public List<Brick> Bricks
        {
            get { return bricks; }
            set { bricks = value; }
        }

        int numberOfLines;

        public int NumberOfLines
        {
            get { return numberOfLines; }
            set { numberOfLines = value; }
        }

        int bricksOnALine;

        public int BricksOnALine
        {
            get { return bricksOnALine; }
            set { bricksOnALine = value; }
        }


        //Constructor for ai wall
        public Wall(float x, float minPosition, float maxPosition, float width, float height)
            : base(x, 0.0f, width, height)
        {

            initialize(x, minPosition, maxPosition);

            //Set wall bricks
            Bricks = new List<Brick>();
            Hits = new List<int>();

            NumberOfLines = Convert.ToInt16(Size.Width / Brick.Width);
            BricksOnALine = Convert.ToInt16(Size.Height / Brick.Height);
        }


        //Constructor for human wall
        public Wall(float x, Keys up, Keys down, float minPosition, float maxPosition, float width, float height)
            :base(x,0.0f,width,height)
        {

            initialize(x, minPosition, maxPosition);
            //Keys to control this sprite 
            _upKey = up;
            _downKey = down;

            //Set wall brick capacity
            Bricks = new List<Brick>();
            Hits = new List<int>();

            NumberOfLines = Convert.ToInt16(Size.Width / Brick.Width);
            BricksOnALine = Convert.ToInt16(Size.Height / Brick.Height);

            _isHuman = true;
        }

        //Shared construction code
        private void initialize(float x, float minPosition, float maxPosition)
        {
            //Limits for movement
            MinPosition = minPosition;
            MaxPosition = maxPosition;

            //The x position is constant for each bat
            Location.X = x;

            //The Y position should be in the center
            Location.Y = (MaxPosition - MinPosition - Height) / 2;
        }

        /// <summary>
        /// Moves the bat based on keyboard (for humans) or AI (for computer)
        /// </summary>
        /// <param name="gameTime">current time since start of game</param>
        /// <param name="elapsedTime">elapsed time since last frame</param>
        public override void Update(double gameTime, double elapsedTime)
        {
            if (_isHuman)
            {
                humanMove();
            }
            else
            {
                computerMove();
            }

            //Perform any animation
            base.Update(gameTime, elapsedTime);

            //Limit the animation to the screen
            if (Location.Y < MinPosition) Location.Y = MinPosition;
            if (Location.Y > MaxPosition - Height) Location.Y = MaxPosition - Height;
        }

        private void computerMove()
        {
            //Use this line to play perfectly. It moves the bat in sync with the ball
            //Location.Y = Ball.Location.Y - Size.Height / 2;

            //Use to AI to make the computer imperfect
            //Only care if the ball is moving towards us
            //NOTE: This AI assumes the computer is always the player on the right hand side of the screen
            if (Ball.Velocity.X > 0)
            {
                //Only care if the ball is close enough to use
                if (Location.X - Ball.Location.X < _lookDistance)
                {
                    //Are we already moving toward a guessed location?
                    if (_estimatedLocation > -1)
                    {
                        //Yes - Are we there yet
                        if ((Math.Sign(Velocity.Y) > 0 && Location.Y >= _estimatedLocation)
                            || (Math.Sign(Velocity.Y) < 0 && Location.Y <= _estimatedLocation))
                        {
                            //Stop moving and next time round we can find a new estimated location
                            Velocity.Y = 0;
                            _estimatedLocation = -1;
                        }
                        //else just keep on moving
                    }
                    else
                    {
                        //Don't allow correction when we are very close
                        if (Location.X - Ball.Location.X > 50)
                        {
                            //Create an estimated location to head for and set the velocity to move us in that direction
                            //Notice that this guess doesn't take into account bounces and has a random factor
                            _estimatedLocation = Ball.Location.Y + (Location.X - Ball.Location.X) * Math.Sign(Ball.Velocity.Y) + _random.Next(100) - 50;

                            if (_estimatedLocation > MaxPosition - Height) _estimatedLocation = MaxPosition - Height;
                            if (_estimatedLocation < MinPosition) _estimatedLocation = MinPosition;

                            if (_estimatedLocation > Location.Y)
                            {
                                Velocity.Y = (float)_speed;
                            }
                            else
                            {
                                Velocity.Y = -(float)_speed;
                            }
                        }
                    }
                }
                else
                {
                    //Else don't move
                    Velocity.Y = 0;
                    _estimatedLocation = -1;
                }

            }
            else
            {
                //Else don't move
                Velocity.Y = 0;
                _estimatedLocation = -1;
            }
        }

        private void humanMove()
        {
            double velocity = 0.0;
            //Set the velocity of the sprite based on which keys are pressed
            if (_isUpKeyPressed)
            {
                velocity += -_speed;
            }
            if (_isDownKeyPressed)
            {
                velocity += _speed;
            }
            Velocity.Y = (float)velocity;
        }

        public void KeyDown(Keys keys)
        {
            //If the key from the key down event matches the up or down key for this bat
            //then set the keyboard state to indicate that this key is currently being held down
            if (keys == _upKey)
            {
                _isUpKeyPressed = true;
            }

            if (keys == _downKey)
            {
                _isDownKeyPressed = true;
            }
        }

        public void KeyUp(Keys keys)
        {
            //If the key from the key down event matches the up or down key for this bat
            //then set the keyboard state to indicate that this key has been released
            if (keys == _upKey)
            {
                _isUpKeyPressed = false;
            }

            if (keys == _downKey)
            {
                _isDownKeyPressed = false;
            }
        }


        public bool IsBrickExists(int id) 
        {
            foreach (Brick b in Bricks)
            {
                if (b.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBrickDrawn(int id)
        {
            return !(Hits.IndexOf(id) >= 0);
        }

        public bool IsHit(float x, float y) 
        {
            bool hit = false;
            foreach (Brick b in Bricks)
            {
                if (Collision(new PointF(b.Location.X + Brick.Width / 2,b.Location.Y + Brick.Width / 2),new PointF(x+Ball.Radius/2,y+Ball.Radius/2)))
                {
                     Hits.Add(b.Id); hit =  true;
                } 
            }
            return hit;   
        }

        private bool Collision(PointF pointFBrick, PointF pointFBall)
        {

            float y2_y1 = pointFBrick.Y - pointFBall.Y;
            float x2_x1 = pointFBrick.X - pointFBall.X;
            float distance = (float)Math.Sqrt((Math.Pow(x2_x1, 2) + Math.Pow(y2_y1, 2)));

            if (distance<=Brick.Width/2 + Ball.Radius/2)
            {
                return true;
            }
            return false;
        }
       
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {

            base.Draw(g, p);

            //Test lines
            //Pen pLine = new Pen(Color.DarkBlue, 1);
            //pLine.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            int id = 0;
            Bricks = new List<Brick>();
            for (int i = 0; i < NumberOfLines; i++)
            {
                for (int j = 0; j < BricksOnALine; j++)
                {
                    
                    float _x = Location.X + i * Brick.Width;
                    float _y = Location.Y + j * Brick.Height;

                    if (IsBrickDrawn(id))
                    {

                        Brick b = new Brick(_x, _y, Brick.Width, Brick.Height, id);
                        b.Draw(g, p);
                        //Test Lines
                        //PointF pBall = new PointF(Ball.Location.X + Ball.Radius / 2, Ball.Location.Y + Ball.Radius / 2);
                        //PointF pBrick = new PointF(b.Location.X + Brick.Width / 2, b.Location.Y + Brick.Width / 2);
                        //g.DrawLine(pLine, pBall, pBrick);
                        Bricks.Add(b);
                       
                    }
                    else
                    {
                        Brick b = new Brick(_x, _y, Brick.Width, Brick.Height, id);
                        b.DrawDashed(g);
                    }
                    id += 1;
                }
            }
        }
    }
}
