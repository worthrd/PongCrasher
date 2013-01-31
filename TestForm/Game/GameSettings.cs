using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestForm.Game
{
    public class GameSettings
    {
        private static readonly GameSettings instance = new GameSettings();

        float ammoSpeed = 200;

        public float AmmoSpeed
        {
            get { return ammoSpeed; }
            set { ammoSpeed = value; }
        }

        private int defaultAmmo = 100;

        public int DefaultAmmo
        {
            get { return defaultAmmo; }
            set { defaultAmmo = value; }
        }

        float brickWidth = 20;

        public float BrickWidth
        {
            get { return brickWidth; }
            set { brickWidth = value; }
        }

        float brickHeight = 20;

        public float BrickHeight
        {
            get { return brickHeight; }
            set { brickHeight = value; }
        }

        float wallWidth = 40;

        public float WallWidth
        {
            get { return wallWidth; }
            set { wallWidth = value; }
        }

        float wallHeight = 200;

        public float WallHeight
        {
            get { return wallHeight; }
            set { wallHeight = value; }
        }

        float ballRadius = 20;

        public float BallRadius
        {
            get { return ballRadius; }
            set { ballRadius = value; }
        }

        float ballInitialSpeed = 400;

        public float BallInitialSpeed
        {
            get { return ballInitialSpeed; }
            set { ballInitialSpeed = value; }
        }

        float playerDefaultX = 30;

        public float PlayerDefaultX
        {
            get { return playerDefaultX; }
            set { playerDefaultX = value; }
        }

        float minPosition = 0;

        public float MinPosition
        {
            get { return minPosition; }
            set { minPosition = value; }
        }

        float ballMinX = 0;

        public float BallMinX
        {
            get { return ballMinX; }
            set { ballMinX = value; }
        }

        float ballMinY = 0;

        public float BallMinY
        {
            get { return ballMinY; }
            set { ballMinY = value; }
        }

        float ballMaxX;

        public float BallMaxX
        {
            get { return ballMaxX; }
            set { ballMaxX = value; }
        }

        float ballMaxY;

        public float BallMaxY
        {
            get { return ballMaxY; }
            set { ballMaxY = value; }
        }

        float bulletWidthHeight = 10;

        public float BulletWidthHeight
        {
            get { return bulletWidthHeight; }
            set { bulletWidthHeight = value; }
        }

        private GameSettings() 
        {
            pen = new Pen(Brushes.Black, 3);
        }

        public static GameSettings GetInstance() 
        {
            return instance;
        }

        Graphics graphics;

        public Graphics Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }

        Pen pen;

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }
    }
}
