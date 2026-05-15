using System;
using System.Drawing;
using System.Windows.Forms;

namespace PongGame
{
    public partial class Form1 : Form
    {
        // =========================
        // ΡΑΚΕΤΕΣ
        // =========================

        int leftPaddleY = 250;
        int rightPaddleY = 250;

        int paddleWidth = 20;
        int paddleHeight = 120;

        int paddleSpeed = 12;

        // =========================
        // ΜΠΑΛΑ
        // =========================

        int ballX = 390;
        int ballY = 290;

        int ballSize = 20;

        int ballSpeedX = 6;
        int ballSpeedY = 6;

        // =========================
        // SCORE
        // =========================

        int scoreLeft = 0;
        int scoreRight = 0;

        bool gameOver = false;

        // =========================
        // INPUTS
        // =========================

        bool wPressed;
        bool sPressed;

        bool upPressed;
        bool downPressed;

        // =========================
        // TIMER
        // =========================

        System.Windows.Forms.Timer gameTimer =
          new System.Windows.Forms.Timer();
        
            

        public Form1()
        {
            InitializeComponent();

            // Μέγεθος παραθύρου
            this.Width = 800;
            this.Height = 600;

            // Τίτλος
            this.Text = "PONG GAME";

            // Background
            this.BackColor = Color.Black;

            // Double Buffer
            this.DoubleBuffered = true;

            // Keyboard events
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Timer
            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        // =========================
        // GAME LOOP
        // =========================

        private void GameLoop(object sender, EventArgs e)
        {
            if (gameOver)
            {
                Invalidate();
                return;
            }

            // =========================
            // LEFT PLAYER
            // =========================

            if (wPressed)
            {
                leftPaddleY -= paddleSpeed;
            }

            if (sPressed)
            {
                leftPaddleY += paddleSpeed;
            }

            // =========================
            // RIGHT PLAYER
            // =========================

            if (upPressed)
            {
                rightPaddleY -= paddleSpeed;
            }

            if (downPressed)
            {
                rightPaddleY += paddleSpeed;
            }

            // =========================
            // ΟΡΙΑ ΡΑΚΕΤΩΝ
            // =========================

            if (leftPaddleY < 0)
                leftPaddleY = 0;

            if (leftPaddleY > this.ClientSize.Height - paddleHeight)
                leftPaddleY = this.ClientSize.Height - paddleHeight;

            if (rightPaddleY < 0)
                rightPaddleY = 0;

            if (rightPaddleY > this.ClientSize.Height - paddleHeight)
                rightPaddleY = this.ClientSize.Height - paddleHeight;

            // =========================
            // ΚΙΝΗΣΗ ΜΠΑΛΑΣ
            // =========================

            // Μετακίνηση μπάλας
            ballX += ballSpeedX;
            ballY += ballSpeedY;

            // =========================
            // COLLISION ΠΑΝΩ / ΚΑΤΩ
            // =========================

            // Αν η μπάλα ακουμπήσει πάνω ή κάτω τοίχο
            if (ballY <= 0 || ballY >= this.ClientSize.Height - ballSize)
            {
                // Αλλαγή κατεύθυνσης στον άξονα Y
                ballSpeedY *= -1;
            }

            // =========================
            // RECTANGLES
            // =========================

            // Rectangle αριστερής ρακέτας
            Rectangle leftPaddle =
                new Rectangle(
                    20,
                    leftPaddleY,
                    paddleWidth,
                    paddleHeight);

            // Rectangle δεξιάς ρακέτας
            Rectangle rightPaddle =
                new Rectangle(
                    this.ClientSize.Width - 40,
                    rightPaddleY,
                    paddleWidth,
                    paddleHeight);

            // Rectangle μπάλας
            Rectangle ball =
                new Rectangle(
                    ballX,
                    ballY,
                    ballSize,
                    ballSize);

            // =========================
            // COLLISION ΡΑΚΕΤΑΣ
            // =========================

            // Collision με αριστερή ρακέτα
            if (ball.IntersectsWith(leftPaddle))
            {
                // Πάντα προς τα δεξιά
                ballSpeedX = Math.Abs(ballSpeedX);

                // Αύξηση δυσκολίας
                ballSpeedX += 1;

                // Βγάζει τη μπάλα έξω από τη ρακέτα
                // για να μην κολλάει
                ballX = leftPaddle.Right;

                // Υπολογισμός γωνίας
                int offset =
                    ballY - (leftPaddleY + paddleHeight / 2);

                // Κατεύθυνση στον άξονα Y
                ballSpeedY = offset / 10;

                // Αν γίνει 0 δίνουμε μικρή κίνηση
                if (ballSpeedY == 0)
                {
                    ballSpeedY = 1;
                }

                // Μέγιστη ταχύτητα Y
                if (ballSpeedY > 8)
                {
                    ballSpeedY = 8;
                }

                // Ελάχιστη ταχύτητα Y
                if (ballSpeedY < -8)
                {
                    ballSpeedY = -8;
                }
            }

            // Collision με δεξιά ρακέτα
            if (ball.IntersectsWith(rightPaddle))
            {
                // Πάντα προς τα αριστερά
                ballSpeedX = -Math.Abs(ballSpeedX);

                // Αύξηση δυσκολίας
                ballSpeedX -= 1;

                // Βγάζει τη μπάλα έξω από τη ρακέτα
                ballX = rightPaddle.Left - ballSize;

                // Υπολογισμός γωνίας
                int offset =
                    ballY - (rightPaddleY + paddleHeight / 2);

                // Κατεύθυνση στον άξονα Y
                ballSpeedY = offset / 10;

                // Αν γίνει 0 δίνουμε μικρή κίνηση
                if (ballSpeedY == 0)
                {
                    ballSpeedY = 1;
                }

                // Μέγιστη ταχύτητα Y
                if (ballSpeedY > 8)
                {
                    ballSpeedY = 8;
                }

                // Ελάχιστη ταχύτητα Y
                if (ballSpeedY < -8)
                {
                    ballSpeedY = -8;
                }
            }

            // =========================
            // SCORE SYSTEM
            // =========================

            // Πέρασε αριστερά
            if (ballX < 0)
            {
                scoreRight++;
                ResetBall();
            }

            // Πέρασε δεξιά
            if (ballX > this.ClientSize.Width)
            {
                scoreLeft++;
                ResetBall();
            }

            // =========================
            // GAME OVER
            // =========================

            if (scoreLeft >= 5 || scoreRight >= 5)
            {
                gameOver = true;
            }

            // Refresh
            Invalidate();
        }

        // =========================
        // RESET ΜΠΑΛΑΣ
        // =========================

        void ResetBall()
        {
            ballX = 390;
            ballY = 290;

            ballSpeedX = -ballSpeedX;

            ballSpeedY = 6;
        }

        // =========================
        // KEY DOWN
        // =========================

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // LEFT PLAYER

            if (e.KeyCode == Keys.W)
                wPressed = true;

            if (e.KeyCode == Keys.S)
                sPressed = true;

            // RIGHT PLAYER

            if (e.KeyCode == Keys.Up)
                upPressed = true;

            if (e.KeyCode == Keys.Down)
                downPressed = true;

            // RESTART

            if (e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
            }
        }

        // =========================
        // KEY UP
        // =========================

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                wPressed = false;

            if (e.KeyCode == Keys.S)
                sPressed = false;

            if (e.KeyCode == Keys.Up)
                upPressed = false;

            if (e.KeyCode == Keys.Down)
                downPressed = false;
        }

        // =========================
        // RESTART GAME
        // =========================

        void RestartGame()
        {
            scoreLeft = 0;
            scoreRight = 0;

            leftPaddleY = 250;
            rightPaddleY = 250;

            gameOver = false;

            ResetBall();
        }

        // =========================
        // DRAW
        // =========================

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Brush whiteBrush = Brushes.White;

            // =========================
            // ΡΑΚΕΤΕΣ
            // =========================

            g.FillRectangle(
                whiteBrush,
                20,
                leftPaddleY,
                paddleWidth,
                paddleHeight);

            g.FillRectangle(
                whiteBrush,
                this.ClientSize.Width - 40,
                rightPaddleY,
                paddleWidth,
                paddleHeight);

            // =========================
            // ΜΠΑΛΑ
            // =========================

            g.FillEllipse(
                whiteBrush,
                ballX,
                ballY,
                ballSize,
                ballSize);

            // =========================
            // SCORE
            // =========================

            Font scoreFont =
                new Font("Arial", 24);

            g.DrawString(
                scoreLeft.ToString(),
                scoreFont,
                whiteBrush,
                300,
                20);

            g.DrawString(
                scoreRight.ToString(),
                scoreFont,
                whiteBrush,
                470,
                20);

            // =========================
            // GAME OVER
            // =========================

            if (gameOver)
            {
                Font gameOverFont =
                    new Font("Arial", 22);

                string text;

                if (scoreLeft > scoreRight)
                {
                    text = "LEFT PLAYER WINS";
                }
                else
                {
                    text = "RIGHT PLAYER WINS";
                }

                g.DrawString(
                    text,
                    gameOverFont,
                    Brushes.Red,
                    230,
                    250);

                g.DrawString(
                    "PRESS R TO RESTART",
                    new Font("Arial", 16),
                    Brushes.White,
                    250,
                    320);
            }
        }
    }
}