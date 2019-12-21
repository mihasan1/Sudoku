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
    public partial class Form1 : Form
    {
        private SudokuGame game = new SudokuGame();
        private Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SudokuGame.Difficulty = 0;
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SudokuGame.Difficulty = 1;
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SudokuGame.Difficulty = 2;
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
