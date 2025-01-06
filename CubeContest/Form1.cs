using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CubeContest
{
    public partial class Form1 : Form
    {
        // Global variables

        Rectangle playerRed = new Rectangle(30, 100, 30, 30);
        Rectangle playerBlue = new Rectangle(475, 100, 30, 30);
        Rectangle speedBoostBerry = new Rectangle(260, 250, 10, 10);
        Rectangle pointBerry = new Rectangle(260, 190, 10, 10);
        Rectangle slowBerry = new Rectangle(260, 300, 10, 10);
        Rectangle wall1 = new Rectangle(5, 55, 10, 397);
        Rectangle wall2 = new Rectangle(5, 55, 520, 10);
        Rectangle wall3 = new Rectangle(5, 443, 520, 10);
        Rectangle wall4 = new Rectangle(520, 55, 10, 398);

        int playerRedScore = 0;
        int playerBlueScore = 0;
        int playerRedSpeed = 5;
        int playerBlueSpeed = 5;

        bool wPressed = false;
        bool aPressed = false;
        bool sPressed = false;
        bool dPressed = false;
        bool upPressed = false;
        bool leftPressed = false;
        bool downPressed = false;
        bool rightPressed = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);

        Random ranGen = new Random();


        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;

            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the red cube on button press

            if (wPressed == true && playerRed.Y > 0)
            {
                playerRed.Y -= playerRedSpeed;
            }

            if (sPressed == true && playerRed.Y > 0)
            {
                playerRed.Y += playerRedSpeed;
            }

            if (aPressed == true && playerRed.X > 0)
            {
                playerRed.X -= playerRedSpeed;
            }

            if (dPressed == true && playerRed.X > 0)
            {
                playerRed.X += playerRedSpeed;
            }

            // Move the blue cube on button press

            if (upPressed == true && playerBlue.Y > 0)
            {
                playerBlue.Y -= playerBlueSpeed;
            }

            if (downPressed == true && playerBlue.Y > 0)
            {
                playerBlue.Y += playerBlueSpeed;
            }

            if (leftPressed == true && playerBlue.X > 0)
            {
                playerBlue.X -= playerBlueSpeed;
            }

            if (rightPressed == true && playerBlue.X > 0)
            {
                playerBlue.X += playerBlueSpeed;
            }

            // Stop both cubes from going through the orange wall by reversing controls

            if (playerRed.IntersectsWith(wall1))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();

                playerRedSpeed *= -1;

            }

            else if (playerRed.IntersectsWith(wall2))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerRedSpeed *= -1;

            }

            else if (playerRed.IntersectsWith(wall3))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerRedSpeed *= -1;

            }

            else if (playerRed.IntersectsWith(wall4))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerRedSpeed *= -1;

            }

            if (playerBlue.IntersectsWith(wall1))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerBlueSpeed *= -1;

            }

            else if (playerBlue.IntersectsWith(wall2))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerBlueSpeed *= -1;

            }

            else if (playerBlue.IntersectsWith(wall3))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerBlueSpeed *= -1;

            }

            else if (playerBlue.IntersectsWith(wall4))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerBlueSpeed *= -1;

            }

            // When both cubes bump into each other their controls reverse

            else if (playerRed.IntersectsWith(playerBlue))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.hit);
                sp.Play();
                playerBlueSpeed *= -1;
                playerRedSpeed *= -1;

            }

            // When a cube colides with a green berry give that cube a point

            if (playerRed.IntersectsWith(pointBerry))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.pointberry);
                sp.Play();
                pointBerry.Y = ranGen.Next(70, 425);
                pointBerry.X = ranGen.Next(70, 425);

                playerRedScore++;

            }

            if (playerBlue.IntersectsWith(pointBerry))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.pointberry);
                sp.Play();
                pointBerry.Y = ranGen.Next(70, 425);
                pointBerry.X = ranGen.Next(70, 425);

                playerBlueScore++;

            }

            // When a cupe collides with a yellow berry give that cube a speed boost

            if (playerRed.IntersectsWith(speedBoostBerry))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.speedberry);
                sp.Play();
                speedBoostBerry.Y = ranGen.Next(70, 425);
                speedBoostBerry.X = ranGen.Next(70, 425);

                if (playerRedSpeed > 0)
                {
                    playerRedSpeed += 5;

                }
                else
                {
                    playerRedSpeed -= 5;

                }

            }

            if (playerBlue.IntersectsWith(speedBoostBerry))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.speedberry);
                sp.Play();
                speedBoostBerry.Y = ranGen.Next(70, 425);
                speedBoostBerry.X = ranGen.Next(70, 425);

                if (playerBlueSpeed > 0)
                {
                    playerBlueSpeed += 5;

                }

                if (playerBlueSpeed < 0)
                {
                    playerBlueSpeed -= 5;

                }


            }

            // When a cube collides with a purple berry slow that player down

            if (playerRed.IntersectsWith(slowBerry))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.slowberry);
                sp.Play();
                slowBerry.Y = ranGen.Next(70, 425);
                slowBerry.X = ranGen.Next(70, 425);

                if (playerRedSpeed > 0)
                {
                    playerRedSpeed -= 5;

                }

                if (playerRedSpeed < 0)
                {
                    playerRedSpeed += 5;

                }
            }

            if (playerBlue.IntersectsWith(slowBerry))
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.slowberry);
                sp.Play();
                slowBerry.Y = ranGen.Next(70, 425);
                slowBerry.X = ranGen.Next(70, 425);

                if (playerBlueSpeed > 0)
                {
                    playerBlueSpeed -= 5;

                }

                if (playerBlueSpeed < 0)
                {
                    playerBlueSpeed += 5;

                }

                
            }

            // Make sure the cubes speed can't ever be 0 so they don't get stuck
            if (playerRedSpeed == 0)
            {
                playerRedSpeed = 2;

            }

            if (playerRedSpeed == 7)
            {
                playerRedSpeed = 5;

            }

            if (playerBlueSpeed == 0)
            {
                playerBlueSpeed = 2;

            }

            if (playerBlueSpeed == 7)
            {
                playerBlueSpeed = 5;

            }

            // Limit a cubes speed

            if (playerRedSpeed == 20)
            {
                playerRedSpeed = 15;

            }

            if (playerBlueSpeed == 20)
            {
                playerBlueSpeed = 15;

            }

            // When a cube gets 10 points end the game and announce the winner

            if (playerRedScore == 10)
            {
                gameTimer.Stop();
                titleLabel.Text = "Red Wins!!";
                instructionLabel.Text = "Click the screen to play again!";

            }

            if (playerBlueScore == 10)
            {
                gameTimer.Stop();
                titleLabel.Text = "Blue Wins!!";
                instructionLabel.Text = "Click the screen to play again!";

            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            redScoreLabel.Text = $"{playerRedScore}";
            blueScoreLabel.Text = $"{playerBlueScore}";
            e.Graphics.FillRectangle(redBrush, playerRed);
            e.Graphics.FillRectangle(blueBrush, playerBlue);
            e.Graphics.FillRectangle(yellowBrush, speedBoostBerry);
            e.Graphics.FillRectangle(greenBrush, pointBerry);
            e.Graphics.FillRectangle(purpleBrush, slowBerry);
            e.Graphics.FillRectangle(orangeBrush, wall1);
            e.Graphics.FillRectangle(orangeBrush, wall2);
            e.Graphics.FillRectangle(orangeBrush, wall3);
            e.Graphics.FillRectangle(orangeBrush, wall4);

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            playerRedScore = 0;
            playerBlueScore = 0;
            gameTimer.Start();
            titleLabel.Text = "";
            instructionLabel.Text = "";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            gameTimer.Stop();
            titleLabel.Text = "Cube Contest!!";
            instructionLabel.Text = "Click the screen to start!";

        }

        
    }
}
