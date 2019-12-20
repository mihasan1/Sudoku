using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form2 : Form
    {
        private SudokuGame game = new SudokuGame();
        private Random r = new Random();
        public Form2()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            dataGridView1.Paint += dataGridView1_Paint;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            game.ShowClues += game_ShowClues;
            game.ShowSolution += game_ShowSolution;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(9);
            button1.PerformClick();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            game.NewGame(r);
        }

        private void dataGridView1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 121, 0, 121, 360);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 239, 0, 239, 360);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 104, 360, 104);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 205, 360, 205);
        }

        public void game_ShowClues(int[][] grid)
        {
            for (int y = 0; y <= 8; y++)
            {
                List<int> cells = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                for (int c = 1; c <= 9 - (5 - game.Difficulty); c++)
                {
                    int randomNumber = cells[r.Next(0, cells.Count())];
                    cells.Remove(randomNumber);
                }
                for (int x = 0; x <= 8; x++)
                {
                    if (cells.Contains(x + 1))
                    {
                        dataGridView1.Rows[y].Cells[x].Value = grid[y][x];
                        dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.LightGray;
                        dataGridView1.Rows[y].Cells[x].ReadOnly = true;
                    }
                    else
                    {
                        dataGridView1.Rows[y].Cells[x].Value = "";
                        dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.Teal;
                        dataGridView1.Rows[y].Cells[x].ReadOnly = false;
                    }
                }
            }
        }

        public void game_ShowSolution(int[][] grid)
        {
            bool isError = false;
            for (int y = 0; y <= 8; y++)
            {
                for (int x = 0; x <= 8; x++)
                {
                    if (dataGridView1.Rows[y].Cells[x].Style.ForeColor == Color.Teal)
                    {
                        if (string.IsNullOrEmpty(dataGridView1.Rows[y].Cells[x].Value.ToString()))
                        {
                            dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.DarkRed;
                            dataGridView1.Rows[y].Cells[x].Value = grid[y][x];
                        }
                        else
                        {
                            if (grid[y][x].ToString() != dataGridView1.Rows[y].Cells[x].Value.ToString())
                            {
                                dataGridView1.Rows[y].Cells[x].Style.ForeColor = Color.DarkRed;
                                dataGridView1.Rows[y].Cells[x].Value = grid[y][x];
                            }
                        }
                    }
                }
            }
            for(int i=0; i<=8; i++)
            {
                for(int j=0; j<=8; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Style.ForeColor == Color.Red)
                        isError = true;
                }
            }
            if (isError)
                MessageBox.Show("Ви вирішили судоку без помилок!", "Вітаємо!");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            game.showGridSolution();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            int b = dataGridView1.CurrentCell.ColumnIndex;
            for(int i=0; i<=8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(30, 30, 30);
                    dataGridView1.Rows[a].Cells[j].Style.BackColor = Color.FromArgb(20, 20, 20);
                    dataGridView1.Rows[i].Cells[b].Style.BackColor = Color.FromArgb(20, 20, 20);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.PerformClick();
            game.Difficulty = comboBox1.SelectedIndex;
        }
    }
}
