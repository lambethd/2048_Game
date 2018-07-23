using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        private Label[,] labels = new Label[4, 4];
        private Game game = new Game();
        private int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labels[0, 0] = lbl00;
            labels[0, 1] = lbl01;
            labels[0, 2] = lbl02;
            labels[0, 3] = lbl03;

            labels[1, 0] = lbl10;
            labels[1, 1] = lbl11;
            labels[1, 2] = lbl12;
            labels[1, 3] = lbl13;

            labels[2, 0] = lbl20;
            labels[2, 1] = lbl21;
            labels[2, 2] = lbl22;
            labels[2, 3] = lbl23;

            labels[3, 0] = lbl30;
            labels[3, 1] = lbl31;
            labels[3, 2] = lbl32;
            labels[3, 3] = lbl33;

            ResetLabels();
            game.ResetGame();
            DrawGame();
        }

        private void ResetLabels()
        {
            lbl00.Text = "";
            lbl01.Text = "";
            lbl02.Text = "";
            lbl03.Text = "";
            lbl10.Text = "";
            lbl11.Text = "";
            lbl12.Text = "";
            lbl13.Text = "";
            lbl20.Text = "";
            lbl21.Text = "";
            lbl22.Text = "";
            lbl23.Text = "";
            lbl30.Text = "";
            lbl31.Text = "";
            lbl32.Text = "";
            lbl33.Text = "";
        }

        private void DrawGame()
        {
            int[,] tiles = game.Tiles;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    labels[x, y].Text = tiles[x, y].ToString();
                    labels[x, y].BackColor = GetBackColour(tiles[x, y]);
                    labels[x, y].Visible = tiles[x, y] != 0;
                }
            }
            score = game.GetScore();
            lblScore.Text = "Score: " + score;
        }

        private void EndGame()
        {
            MessageBox.Show("You lose! Score was: " + game.GetScore());
            game.ResetGame();
            DrawGame();
        }

        public void KeyPress(Direction direction)
        {
            MoveResponse response = game.RegisterDirection(direction);
            if (response == MoveResponse.END_GAME)
            {
                EndGame();
            }

            if (response == MoveResponse.CAN_MOVE)
            {
                DrawGame();
            }
        }

        private void UserKeyPress(object sender, KeyEventArgs e)
        {
            Direction userDirection;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    userDirection = Direction.LEFT;
                    break;
                case Keys.Right:
                    userDirection = Direction.RIGHT;
                    break;
                case Keys.Up:
                    userDirection = Direction.UP;
                    break;
                case Keys.Down:
                    userDirection = Direction.DOWN;
                    break;
                default:
                    return;
            }
            KeyPress(userDirection);
        }

        private Color GetBackColour(int cellValue)
        {
            switch (cellValue)
            {
                case 2:
                    return Color.FromArgb(200, 200, 200);
                case 4:
                    return Color.FromArgb(200, 200, 180);
                case 8:
                    return Color.FromArgb(200, 128, 0);
                case 16:
                    return Color.FromArgb(255, 128, 0);
                case 32:
                    return Color.FromArgb(255, 64, 0);
                case 64:
                    return Color.FromArgb(255, 32, 0);
                case 128:
                    return Color.FromArgb(255, 200, 0);
                case 256:
                    return Color.FromArgb(255, 180, 0);
                case 512:
                    return Color.FromArgb(255, 160, 0);
                case 1024:
                    return Color.FromArgb(255, 140, 0);
                case 2048:
                    return Color.FromArgb(255, 120, 0);
                case 4096:
                    return Color.FromArgb(255, 100, 0);
                case 8192:
                    return Color.FromArgb(255, 80, 0);
                case 16384:
                    return Color.FromArgb(255, 60, 0);
                case 32768:
                    return Color.FromArgb(255, 40, 0);
                case 65536:
                    return Color.FromArgb(255, 0, 0);
                default:
                    return Color.Beige;
            }
        }
    }
}
