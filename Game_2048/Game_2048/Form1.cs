using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_2048
{
    public partial class Form1 : Form
    {
        Label[,] grid;
        int n = 4;
        int r_x, r_y;
        string r;

        public Form1()
        {
            InitializeComponent();

            grid = new Label[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i, j] = new Label();

                    tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    grid[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                    grid[i, j].Text = "";
                    grid[i, j].Font = new Font("Clear Sans", 38, FontStyle.Bold);

                    tableLayoutPanel1.BackColor = Color.FromArgb(187, 173, 160);
                    grid[i, j].BackColor = Color.FromArgb(238, 228, 218);
                    grid[i, j].ForeColor = Color.FromArgb(119, 110, 101);

                    grid[i, j].BorderStyle = BorderStyle.None;
                    grid[i, j].TextAlign = ContentAlignment.MiddleCenter;

                    var margin = grid[i, j].Margin;
                    margin.All = 8;
                    grid[i, j].Margin = margin;

                    tableLayoutPanel1.Controls.Add(grid[i, j], i, j);
                }
            }

            make_rn();
            make_rn();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool move = false;
            for (int k = 0; k < 3; k++)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Up:
                                if (j > 0)
                                    if (grid[i, j - 1].Text == "")
                                    {
                                        move = true;
                                        grid[i, j - 1].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                    else if (j > 0 && grid[i, j - 1].Text == grid[i, j].Text)
                                    {
                                        grid[i, j - 1].Text = Convert.ToString(Convert.ToInt32(grid[i, j].Text) * 2);
                                        grid[i, j].Text = "";
                                    }

                                break;

                            case Keys.Down:
                                if (j < n - 1)
                                    if (grid[i, j + 1].Text == "")
                                    {
                                        move = true;
                                        grid[i, j + 1].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                    else if (j < 3 && grid[i, j + 1].Text == grid[i, j].Text)
                                    {
                                        grid[i, j + 1].Text = Convert.ToString(Convert.ToInt32(grid[i, j].Text) * 2);
                                        grid[i, j].Text = "";
                                    }
                                break;

                            case Keys.Left:
                                if (i > 0)
                                    if (grid[i - 1, j].Text == "")
                                    {
                                        move = true;
                                        grid[i - 1, j].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                    else if (i > 0 && grid[i - 1, j].Text == grid[i, j].Text)
                                    {
                                        grid[i - 1, j].Text = Convert.ToString(Convert.ToInt32(grid[i, j].Text) * 2);
                                        grid[i, j].Text = "";
                                    }
                                break;

                            case Keys.Right:
                                if (i < n - 1)
                                    if (grid[i + 1, j].Text == "")
                                    {
                                        move = true;
                                        grid[i + 1, j].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                    else if (i < 3 && grid[i + 1, j].Text == grid[i, j].Text)
                                    {
                                        grid[i + 1, j].Text = Convert.ToString(Convert.ToInt32(grid[i, j].Text) * 2);
                                        grid[i, j].Text = "";
                                    }
                                break;
                        }
                    }
                }
            if (move == true)
            {
                make_rn();
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void make_rn()
        {
            var rand = new Random();
            int[] num = { 2, 2, 2, 4 };

            bool empty;
            do
            {
                empty = true;

                r_x = rand.Next(0, 3);
                r_y = rand.Next(0, 3);

                if (grid[r_x, r_y].Text != "")
                    empty = false;
            } while (empty == false);

            r = (num[rand.Next(0, num.Length)]).ToString();
            grid[r_x, r_y].Text = r;
        }
    }
}