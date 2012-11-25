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

        public Crasher()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            gameState = new GameState();

            Brick.Height = 20;
            Brick.Width = 20;

            Wall.Width = 40;
            Wall.Height = 200;

            Ball.Radius = 20;
            Ball.InitialSpeed = 400.0;

            //Create the bat Sprites - they need the keyboard controls and the gameplay area limits
            _player1 = new Wall(30.0f,Keys.Up,Keys.Down ,0.0f, (float)ClientSize.Height, Wall.Width, Wall.Height);

            //use this line for a second human player
            //_player2 = new Bat(player2Bat, ClientSize.Width - 30 - Bat.Width, Keys.P, Keys.L, 0, ClientSize.Height);

            //use this line for a computer player
            _player2 = new Wall((float)ClientSize.Width - 30.0f - Wall.Width, 0.0f, (float)ClientSize.Height, Wall.Width, Wall.Height);


            _ball_1 = new Ball(0.0f, (float)ClientSize.Width, 0.0f, (float)ClientSize.Height, gameState, ref _player1, ref _player2);

            _player1.Ball = _ball_1;

            //Connect the AI player with the ball
            _player2.Ball = _ball_1;

            //Initialise and start the timer
            _lastTime = 0.0;
            _timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 3);
            p.Brush = Brushes.Black;
            Graphics g = e.Graphics;

            //Work out how long since we were last here in seconds
            double gameTime = _timer.ElapsedMilliseconds / 1000.0;
            double elapsedTime = gameTime - _lastTime;
            _lastTime = gameTime;
            _frameCounter++;

            //Perform any animation
            _player1.Update(gameTime, elapsedTime);
            _player2.Update(gameTime, elapsedTime);
            _ball_1.Update(gameTime, elapsedTime);

            //Draw the scores
            //player1Score.Text = gameState.Player1Score.ToString();
            //player1Score.Refresh();
            //player2Score.Text = gameState.Player2Score.ToString();
            //player2Score.Refresh();

            //Draw the scores
            Font myFont = new System.Drawing.Font("Arial", 12);
            PointF pfScore = new PointF(this.ClientSize.Width / 2 - 100  , 10);
            g.DrawString(String.Format("Player1 : {0} / Player2: {1}", gameState.Player1Score.ToString(), gameState.Player2Score.ToString()),myFont,p.Brush,pfScore);


            //and the game objects
            _player1.Draw(g, p);
            _player2.Draw(g, p);
            _ball_1.Draw(g, p);

            //Force the next Paint()
            this.Invalidate();

         
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


        /* OLD Codes 

        int p1X;
        int p1Y;
        int p2X;
        int p2Y;

        int moveSpeed = 20;
        int brickLines = 3;
        int bricksOnLine = 20;
        int brickHeight = 16;
        int brickWidth = 8;
        int distanceFromEdges = 100;

        int minX;
        int minY;
        int maxX;
        int maxY;

        int ballX;
        int ballY;
        int radius = 30;

        List<BrickPosition> playerBlocks = new List<BrickPosition>();

        bool init = true;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetPlayArea();

        }

        private void SetPlayArea()
        {
            p1X = distanceFromEdges - brickLines * brickWidth;
            p2X = this.ClientSize.Width - distanceFromEdges;
            p1Y = p2Y = (this.ClientSize.Height - brickHeight * bricksOnLine) / 2;

            minX = 0;
            minY = 0;
            maxX = this.ClientSize.Width;
            maxY = this.ClientSize.Height;


 

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Pen pDraw = new Pen(Color.Black, 2);
            Graphics g = e.Graphics;

            if (init)
            {
                ballX = 300;
                ballY = 300;
                Rectangle rect = new Rectangle(ballX, ballY, radius, radius);
                g.FillEllipse(Brushes.Green, rect);
                g.DrawEllipse(pDraw, rect);
            }
            

            for (int i = 0; i < brickLines; i++)
            {
                int _startY1 = p1Y;
                int _startY2 = p2Y;

                for (int j = 0; j < bricksOnLine; j++)
                {

                    if (i % 2 != 0 && (j == 0 || j == bricksOnLine - 1))
                    {
                        if (j == bricksOnLine - 1)
                        {
                            //Player1
                            CreatePlayerBlock(pDraw, g, p1X + i * brickWidth, _startY1, brickWidth, brickHeight, Brushes.LightYellow,1);
                            //Player2
                            CreatePlayerBlock(pDraw, g, p2X + i * brickWidth, _startY2, brickWidth, brickHeight, Brushes.LightYellow,2);

                            _startY1 += brickHeight;
                            _startY2 += brickHeight;

                            //Player1
                            CreatePlayerBlock(pDraw, g, p1X + i * brickWidth, _startY1, brickWidth, brickHeight/2, Brushes.LightYellow,1);
                            //Player2
                            CreatePlayerBlock(pDraw, g, p2X + i * brickWidth, _startY2, brickWidth, brickHeight/2, Brushes.LightYellow,2);
                            break;
                        }
                        else
                        {
                            //Player1
                            CreatePlayerBlock(pDraw, g, p1X + i * brickWidth, _startY1, brickWidth, brickHeight / 2, Brushes.LightYellow,1);
                            //Player2
                            CreatePlayerBlock(pDraw, g, p2X + i * brickWidth, _startY2, brickWidth, brickHeight / 2, Brushes.LightYellow,2);
                            _startY1 += brickHeight / 2;
                            _startY2 += brickHeight / 2;
                        }

                    }
                    else
                    {
                        //Player1
                        CreatePlayerBlock(pDraw, g, p1X + i * brickWidth, _startY1, brickWidth, brickHeight, Brushes.LightYellow,1);
                        //Player2
                        CreatePlayerBlock(pDraw, g, p2X + i * brickWidth, _startY2, brickWidth, brickHeight, Brushes.LightYellow,2);
                        _startY1 += brickHeight;
                        _startY2 += brickHeight;
                    }
                    
                }
            }

            init = false;

            this.Invalidate();
        }

   
        private void CreatePlayerBlock(Pen pDraw, Graphics g, int x, int y, int width,int height, Brush b,int player)
        {

           
                Rectangle rect = new Rectangle(x, y, width, height);
                g.FillRectangle(b, rect);
                g.DrawRectangle(pDraw, rect);
           
                
            if (init)
            {
                playerBlocks.Add(new BrickPosition() { X = x, Y = y, Player = player });
            }
               
            
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='s')
            {
                p1Y += moveSpeed;
            }
            else if (e.KeyChar=='w')
            {
                p1Y -= moveSpeed;
            }



            if (e.KeyChar == 'o')
            {
                p2Y -= moveSpeed;
            }
            else if (e.KeyChar =='l')
            {
                p2Y += moveSpeed;
            }
 


            this.Invalidate();
        }
        */
    }
}
