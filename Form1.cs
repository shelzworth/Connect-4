using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_4
{
    public partial class Form1 : Form
    {
        int[,] board =
           {
                { 0,0,0,0,0,0,}, //collumn 1
                { 0,0,0,0,0,0,}, //collumn 2
                { 0,0,0,0,0,0,}, //collumn 3
                { 0,0,0,0,0,0,}, //collumn 4
                { 0,0,0,0,0,0,}, //collumn 5
                { 0,0,0,0,0,0,}, //collumn 6
                { 0,0,0,0,0,0,}, //collumn 7
            };
        bool turn = true;
        int tracker = 7 * 6;
        bool player1win = false;
        bool player2win = false;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disable();
        }
        private void btnClick1()
        {
            name1 = txtName1.Text.ToLower();
            txtName2.Visible = true;
            lblName2.Visible = true;
            btnStart2.Visible = true;

            txtName1.Visible = false;
            lblName1.Visible = false;
            btnStart1.Visible = false;
        }
        private void btnClick2()
        {
            name2 = txtName2.Text.ToLower();
            Random box = new Random();
            int num = box.Next(1, 3);
            if (num == 2)
            {
                MessageBox.Show(name2 + " goes first");
                turn = false;
            }
            else if (num == 1)
            {
                MessageBox.Show(name1 + " goes first");
                turn = true;

            }

            txtName2.Visible = false;
            lblName2.Visible = false;
            btnStart2.Visible = false;
            lblp1.Text = name1;
            lblp2.Text = name2;
            enable();
        }
        private void hover(object sender, EventArgs e)
        {
            PictureBox picked = (PictureBox) sender;
            picked.BackgroundImage = Properties.Resources.bluem;
            if (turn) picked.BackgroundImage = Properties.Resources.bluem;
            else if (!turn) picked.BackgroundImage = Properties.Resources.yellowm;

        }

        private void leave(object sender, EventArgs e)
        {
            PictureBox picked = (PictureBox)sender;
            picked.BackgroundImage = Properties.Resources.mnm;
        }

        private void dropit(object sender, EventArgs e)
        {
            PictureBox picked = (PictureBox)sender;
            char[] broken = picked.Name.ToCharArray();
            int namenum = int.Parse(broken[7].ToString());
            int dropspot = blankCheck(namenum);
            int rowspot = dropspot - 1;
            if (rowspot >= 0)
            {
                if (turn)
                {
                    if (dropspot != 0)
                    {
                        this.Controls["pb" + namenum + rowspot].BackgroundImage = Properties.Resources.bluem;
                        board[namenum, rowspot] = 1;
                        turn = false;
                    }
                }
                else if (!turn)
                {
                    if (dropspot != 0)

                    {
                        this.Controls["pb" + namenum + rowspot].BackgroundImage = Properties.Resources.yellowm;
                        board[namenum, rowspot] = 2;
                        turn = true;
                    }
                } 
            }
            WinScenarios();
            Win();
            
        }
        private int blankCheck(int col)
        {
            int blanks = 0;
            for (int i = 0; i < 6; i++)
            {
                if (board[col, i] == 0) blanks++;
            }
            return blanks;
        }
        private void randomize()
        {

        }
        string name2 = "";
        string name1 = "";
        private void btnStart1_Click(object sender, EventArgs e)
        {
            btnClick1();

        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            btnClick2();
        }
        private void disable()
        {
            pbhover0.Enabled = false;
            pbhover1.Enabled = false;
            pbhover2.Enabled = false;
            pbhover3.Enabled = false;
            pbhover4.Enabled = false;
            pbhover5.Enabled = false;
            pbhover6.Enabled = false;
        }
        private void enable()
        {
            pbhover0.Enabled = true;
            pbhover1.Enabled = true;
            pbhover2.Enabled = true;
            pbhover3.Enabled = true;
            pbhover4.Enabled = true;
            pbhover5.Enabled = true;
            pbhover6.Enabled = true;
        }
        private void Win()
        {
            if (player1win)
            {
                MessageBox.Show("Player 1 wins");
                btnLeave.Enabled = true;
                btnLeave.Visible = true;
            }
            else if (player2win)
            {
                MessageBox.Show("Player 2 wins");
                btnLeave.Enabled = true;
                btnLeave.Visible = true;
            }
        }
        private void WinScenarios()
        {
            //vertical check
            string vcheckstring = "";
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    vcheckstring = vcheckstring + board[i, j].ToString();
                }
                vcheckstring = vcheckstring + "---";
            }
            if (vcheckstring.Contains("1111"))
            {
                lblp1.BackColor = Color.LightGreen; 
                lblp2.BackColor = Color.Red;
                player1win = true;
                Win();
            }
            else if (vcheckstring.Contains("2222"))
            {
                lblp2.BackColor = Color.LightGreen;
                lblp1.BackColor = Color.Red;
                player2win = true;
                Win();
            }
            //horizontal check
            string hcheckstring = "";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    hcheckstring = hcheckstring + board[j, i].ToString();
                }
                hcheckstring = hcheckstring + "---";
            }
            if (hcheckstring.Contains("1111"))
            {
                lblp1.BackColor = Color.LightGreen;
                lblp2.BackColor = Color.Red;
                player1win = true;
                disable();
                Win();
            }
            else if (hcheckstring.Contains("2222"))
            {
                lblp2.BackColor = Color.LightGreen;
                lblp1.BackColor = Color.Red;
                player2win = true;
                disable();
                Win();
            }
            //diagonal
            string[] diagonal = new string[12];
            //
            diagonal[0] = board[0, 3].ToString() + board[1, 2] + board[2, 1] + board[3, 0];
            //
            diagonal[1] = board[0, 4].ToString() + board[1, 3] + board[2, 2] + board[3, 1] + board[4,0];
            //
            diagonal[2] = board[0, 5].ToString() + board[1, 4] + board[2, 3] + board[3, 2] + board[4,1] + board[5,0];
            diagonal[3] = board[1, 5].ToString() + board[2, 4] + board[3, 3] + board[4, 2] + board[5,1] + board[6,0];
            //
            diagonal[4] = board[2, 5].ToString() + board[3, 4] + board[4, 3] + board[5, 2] + board[6,1];
            //
            diagonal[5] = board[3,5].ToString() + board[4,4] + board[5,3] + board[6,2];
            diagonal[6] = board[6,3].ToString() + board[5,2] + board[4,1] + board[3,0];
            //
            diagonal[7] = board[6,4].ToString() + board[5,3] + board[4, 2] + board[3, 1] + board[2, 1];
            //
            diagonal[8] = board[6, 5].ToString() + board[5, 4] + board[4, 3] + board[3, 2] + board[2, 1] + board[1, 0];
            diagonal[9] = board[5, 5].ToString() + board[4, 4] + board[3, 3] + board[2, 2] + board[1, 1] + board[0, 0];
            //
            diagonal[10] = board[4, 5].ToString() + board[3, 4] + board[2, 3] + board[1, 2] + board[0, 1];
            //
            diagonal[11] = board[3,5].ToString() + board[2,4] + board[1,3] + board[0, 2];

            foreach (string dia in diagonal)
            {
                if (dia.Contains("1111"))
                {
                    lblp1.BackColor = Color.LightGreen;
                    lblp2.BackColor = Color.Red;
                    player1win = true;
                    disable();
                    Win();
                }
                if (dia.Contains("2222"))
                {
                    lblp2.BackColor = Color.LightGreen;
                    lblp1.BackColor = Color.Red;
                    player2win = true;
                    disable();
                    Win();
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
