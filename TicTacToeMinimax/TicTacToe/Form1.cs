using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TicTacToe
{
    
    // Minimax algorithm for AI

    public partial class Form1 : Form
    {
        public class MyButton : Button
        {
            public bool taken { get; set; }
        }

        Screen src = Screen.PrimaryScreen;
        MyButton[,] buttons = new MyButton[3, 3];
        string[] moves = new string[] { "X", "O" };
        int currentMove = 0;

        bool gameWon = false;

        public Form1()
        {
            InitializeComponent();
            CreateButtons();
            Thread a = new Thread(Main);
            a.IsBackground = true;
            a.Start();
        }

        void CreateButtons()
        {
            int uBound0 = buttons.GetUpperBound(0);
            int uBound1 = buttons.GetUpperBound(1);
            int x = (src.WorkingArea.Width - this.Width) / 2;
            int y = (src.WorkingArea.Height - this.Height) / 8;
            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                {
                    //Console.WriteLine(i);
                    MyButton newButton = new MyButton();
                    buttons[i, j] = newButton;
                    this.buttons[i, j].Location = new Point(x, y);
                    buttons[i, j].Height = 100;
                    buttons[i, j].Tag = i.ToString() + "," + j.ToString();
                    buttons[i, j].Width = 100;
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].Font = new Font("Georgia", 16);
                    buttons[i, j].Click += new EventHandler(DynamicButton_Click);
                    Controls.Add(buttons[i, j]);
                    x += 200;
                    Debug.WriteLine(buttons[i, j].Name);
                }
                x = (src.WorkingArea.Width - this.Width) / 2;
                y += 150;
            }
        }

        void Main ()
        {
            MyButton[] columnZero = Enumerable.Range(0, buttons.GetLength(0))
                        .Select(x => buttons[x, 0])
                        .ToArray();
            MyButton[] columnOne = Enumerable.Range(0, buttons.GetLength(0))
                        .Select(x => buttons[x, 1])
                        .ToArray();
            MyButton[] columnTwo = Enumerable.Range(0, buttons.GetLength(0))
                        .Select(x => buttons[x, 2])
                        .ToArray();
            int countforP1 = 0;
            int countforP2 = 0;
            while (true)
            {
                for(int i = 0; i < 3; i++)
                {
                    countforP1 = 0;
                    countforP2 = 0;
                    for(int j = 0; j < 3; j++)
                    {
                        if(buttons[i, j].Text == "X")
                        {
                            countforP1++;
                            buttons[i, j].taken = true;
                        }
                        if (buttons[i, j].Text == "O")
                        {
                            countforP2++;
                            buttons[i, j].taken = true;
                        }
                        if (countforP1 == 3 && !gameWon)
                        {
                            DialogResult result = MessageBox.Show("X Wins!", "Game Over", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                            gameWon = true;
                        }
                        if (countforP2 == 3 && !gameWon)
                        {
                            DialogResult result = MessageBox.Show("O Wins!", "Game Over", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                            gameWon = true;
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    countforP1 = 0;
                    countforP2 = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (buttons[j, i].Text == "X")
                        {
                            countforP1++;
                            buttons[j, i].taken = true;
                        }
                        if (buttons[j, i].Text == "O")
                        {
                            countforP2++;
                            buttons[j, i].taken = true;
                        }
                        if (countforP1 == 3 && !gameWon)
                        {
                            DialogResult result = MessageBox.Show("X Wins!", "Game Over", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                            gameWon = true;
                        }
                        if (countforP2 == 3 && !gameWon)
                        {
                            DialogResult result = MessageBox.Show("O Wins!", "Game Over", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                            gameWon = true;
                        }
                    }
                }
                if(buttons[1, 1].Text == "X")
                {
                    if(buttons[0, 0].Text == "X" && buttons[2, 2].Text == "X" && !gameWon)
                    {
                        DialogResult result = MessageBox.Show("X Wins!", "Game Over", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                        gameWon = true;
                    }
                    if (buttons[0, 2].Text == "X" && buttons[2, 0].Text == "X" && !gameWon)
                    {
                        DialogResult result = MessageBox.Show("X Wins!", "Game Over", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                        gameWon = true;
                    }
                }
                if (buttons[1, 1].Text == "O")
                {
                    if (buttons[0, 0].Text == "O" && buttons[2, 2].Text == "O" && !gameWon)
                    {
                        DialogResult result = MessageBox.Show("O Wins!", "Game Over", MessageBoxButtons.OK);
                        if(result == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                        gameWon = true;
                    }
                    if (buttons[0, 2].Text == "O" && buttons[2, 0].Text == "O" && !gameWon)
                    {
                        DialogResult result = MessageBox.Show("O Wins!", "Game Over", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                        gameWon = true;
                    }
                }
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if (!buttons[i, j].taken)
                            break;
                        else if (buttons[i, j].taken && i == 2 && j == 2)
                        {
                            DialogResult result = MessageBox.Show("Draw!", "Game Over", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                        }
                    }
                }
            }
        }

        private void DynamicButton_Click(object sender, EventArgs e)
        {
            MyButton btn = sender as MyButton;
            string[] indexesStr = btn.Tag.ToString().Split(',');
            int[] indexes = new int[indexesStr.Length];
            for (int i = 0; i < indexesStr.Length; i++)
            {
                indexes[i] = Int32.Parse(indexesStr[i]);
            }
            MyButton currentButton = buttons[indexes[0], indexes[1]];
            if (currentButton.taken == false)
            {
                currentButton.Text = moves[currentMove];
                currentButton.taken = true;
                if (currentMove == 0)
                    currentMove = 1;
                else if (currentMove == 1)
                    currentMove = 0;
            }
        }
    }
}
