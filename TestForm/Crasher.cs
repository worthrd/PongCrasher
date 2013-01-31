using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using TestForm.Game;
using TestForm.Game.Weapons;

namespace TestForm
{
    public partial class Crasher : Form
    {

        private Stopwatch _timer = new Stopwatch();
        private double _lastTime;
        private long _frameCounter;

        private Wall _player1;
        private Wall _player2;
        private Ball _ball_1;
        private GameState gameState;
        private GameSettings settings;

        public Crasher()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            gameState = new GameState();

            settings = GameSettings.GetInstance();

            Brick.Height = settings.BrickHeight;
            Brick.Width = settings.BrickWidth;

            Wall.Width = settings.WallWidth;
            Wall.Height = settings.WallHeight;

            Ball.Radius = settings.BallRadius;
            Ball.InitialSpeed = settings.BallInitialSpeed;

            settings.BallMaxX = (float)ClientSize.Width;

            settings.BallMaxY = (float)ClientSize.Height;

            //Create the bat Sprites - they need the keyboard controls and the gameplay area limits
            _player1 = new Wall(settings.PlayerDefaultX,Keys.Up,Keys.Down ,settings.MinPosition, (float)ClientSize.Height, Wall.Width, Wall.Height);

            //use this line for a second human player
            //_player2 = new Bat(player2Bat, ClientSize.Width - 30 - Bat.Width, Keys.P, Keys.L, 0, ClientSize.Height);

            //use this line for a computer player
            _player2 = new Wall((float)ClientSize.Width - settings.PlayerDefaultX - Wall.Width, settings.MinPosition, (float)ClientSize.Height, Wall.Width, Wall.Height);


            _ball_1 = new Ball(settings.BallMinX, (float)ClientSize.Width, settings.BallMinY, (float)ClientSize.Height, gameState, ref _player1, ref _player2);

            _player1.Ball = _ball_1;

            //Connect the AI player with the ball
            _player2.Ball = _ball_1;

            //Initialise and start the timer
            _lastTime = 0.0;
            _timer.Start();

           
            Sprite shotGun = new ShotGun(_player1, _player2, _ball_1);
            Sprite shotGun2 = new ShotGun(_player1, _player2, _ball_1);
            _player1.Weapons.Add(shotGun);
            _player1.Weapons.Add(shotGun2);
            /*
           ((Weapon)shotGun).Use();
           */ 
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            settings.Graphics= e.Graphics;

            //Work out how long since we were last here in seconds
            double gameTime = _timer.ElapsedMilliseconds / 1000.0;
            double elapsedTime = gameTime - _lastTime;
            _lastTime = gameTime;
            _frameCounter++;

            //Perform any animation
            _player1.Update(gameTime, elapsedTime);
            _player2.Update(gameTime, elapsedTime);
            _ball_1.Update(gameTime, elapsedTime);


            DrawScoresAndBonus();

            //and the game objects
            _player1.Draw();
            _player2.Draw();
            _ball_1.Draw();

            //Force the next Paint()
            this.Invalidate();

         
        }

        private void DrawScoresAndBonus()
        {
            //Draw the scores
            Font myFont = new System.Drawing.Font("Arial", 12);
            PointF pfScore = new PointF(this.ClientSize.Width / 2 - 100, 10);
            settings.Graphics.DrawString(String.Format("Player1 : {0} / Player2: {1}", gameState.Player1Score.ToString(), gameState.Player2Score.ToString()), myFont, settings.Pen.Brush, pfScore);

            Pen p = new Pen(Brushes.Black, 2.00f);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            int nextX = 0;
            int slotX = (int)settings.BrickWidth;
            int slotY = (int)settings.BrickWidth;
            int weaponSlotWidth = (int)settings.BrickWidth * 2;
            int weaponSlotHeight = (int)settings.BrickWidth * 2;


            foreach (Weapon w in this._player1.Weapons)
            {
                settings.Graphics.DrawEllipse(p, new Rectangle(slotX + nextX, slotY, weaponSlotWidth, weaponSlotHeight));
                nextX += (int)settings.BrickWidth + weaponSlotWidth;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Pass the key presses to the bats
            _player1.KeyDown(e.KeyCode);
            _player2.KeyDown(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Pass the key presses to the bats
            _player1.KeyUp(e.KeyCode);
            _player2.KeyUp(e.KeyCode);
        }

        private void Crasher_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Pass the key presses to the bats
            _player1.KeyPress(e.KeyChar);
            _player2.KeyPress(e.KeyChar);
        }
    }
}
