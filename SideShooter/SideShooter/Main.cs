﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace SideShooter
{
    public partial class Main : Form
    {
        public static TranslatedWindow TWindow = null;

        private Timer FrameTimer;
        public NewFrame NFrame;

        public BufferedGraphicsContext context;
        public BufferedGraphics buffer;

        public static IntakeAssets assets;
        public static Random randNum;

        public static ShipClass ship;

        public static int frameCount;

        public static DeepSpaceBackground DSBackground;
        public static MidSpaceBackground MSBackground;
        public static ForeSpaceBackground FSBackground;

        public static EnemyClass enemyWave = new EnemyClass(3);
        public bool enemiesPresent = false;
        public int waveLevel = 3;

        public bool startGame = false;

        public static Sound SoundEngine;

        public static CollisionClass CollisionEngine;

        public static int score = 0;
        public static bool maystartnewgame = true;
        public static int waitTimer = 0;
        
        public Main()
        {
            InitializeComponent();

            TWindow = new TranslatedWindow(this);
            NFrame = new NewFrame();

            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(TWindow.xMax - 1, TWindow.yMax - 1);
            buffer = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, TWindow.xMax, TWindow.yMax));

            assets = new IntakeAssets();
            randNum = new Random();
            initializeGame();

            frameCount = 0;

            FrameTimer = new Timer();
            FrameTimer.Interval = 40;
            FrameTimer.Tick += new EventHandler(TimerElapsedEvent);
            FrameTimer.Start();

            waitTimer = frameCount + 20;
        }

        private void TimerElapsedEvent(object source, EventArgs e)
        {            
            GameLoop();
            UpdateBuffer(buffer.Graphics);
            frameCount++;
            this.Refresh();
        }

        private void initializeGame()
        {
            ship = new ShipClass();

            DSBackground = new DeepSpaceBackground();
            MSBackground = new MidSpaceBackground();
            FSBackground = new ForeSpaceBackground();
            
            SoundEngine = new Sound();
            SoundEngine.PlayMusic();

            CollisionEngine = new CollisionClass();
        }

        private void GameLoop()
        {
            //Do this no matter the game state
            ScoreLabel.Text = "Player One:  " + score.ToString();
            MSBackground.MidMoveStars();
            FSBackground.ForeMoveStars();

            if (ship.lives < 0)
            {
                if (PressStartLabel.Visible == false)
                {
                    SideShooter.Main.SoundEngine.PlayGameOver();
                    PressStartLabel.Visible = true;
                }
                
                startGame = false;
                if (waitTimer < frameCount)
                    maystartnewgame = true;
                return;
            }

            if (startGame)
            {
                if (!(enemiesPresent))
                {
                    enemyWave.InitializeEnemies(waveLevel);
                    enemiesPresent = true;
                }
                else
                {
                    if (enemyWave.enemyCount >= 1)
                    {
                        enemyWave.EnemyMove();
                    }
                    else
                    {
                        enemiesPresent = false;
                        if (waveLevel < 100)
                        {
                            waveLevel = waveLevel + 4;
                        }
                    }

                }
            }
            //do cleanup
            ship.CheckShotsForLife();
            CollisionEngine.CheckCollisions();
            ship.MoveShots();

            //then do new stuff...            
            if (startGame)
            {
                if (ship.explosionFrame <= 0) 
                {
                    ship.MoveShip();

                    
                    ship.FireLaser();
                }

            }
        }

        private void UpdateBuffer(Graphics g)
        {
            NFrame.CreateFrame(buffer.Graphics);
        }


        private void Main_Paint(object sender, PaintEventArgs e)
        {
            buffer.Render(e.Graphics);
        }        

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (maystartnewgame && (waitTimer <= frameCount))
            {
                startGame = true;
                PressStartLabel.Visible = false;
                ship.lives = 3;
                waveLevel = 3;
                score = 0;
                ship.position.X = 100;
                ship.position.Y = 220;
                maystartnewgame = false;
                enemyWave.InitializeEnemies(waveLevel);
                ship.shotsAlive = 0;
            }
            
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                ship.mUp = true;
            }
            if (e.KeyCode == Keys.S)
            {
                ship.mDown = true;
            }
            if (e.KeyCode == Keys.D)
            {
                ship.mRight = true;
            }
            if (e.KeyCode == Keys.A)
            {
                ship.mLeft = true;
            }
            if (e.KeyCode == Keys.Space)
            {                
                ship.firing = true;
            }

            e.Handled = true;
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                ship.mUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                ship.mDown = false;
            }
            if (e.KeyCode == Keys.D)
            {
                ship.mRight = false;
            }
            if (e.KeyCode == Keys.A)
            {
                ship.mLeft = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                ship.firing = false;
            }

            e.Handled = true;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 1; i < assets.SoundCount; i++)
            {
                assets.soundMachine[i].Dispose();
            }

            buffer.Dispose();
        }
    }
}
