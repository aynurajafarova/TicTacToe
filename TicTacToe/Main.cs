using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
       
        bool turn = true; //true-x; false-O
        int turnCount = 0;
        int player1_score = 0;
        int player2_score = 0;

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
           
            Button btn = sender as Button;
           
            if (turn)
            {
                btn.Text = "X";
                btn.BackColor = Color.Green;
                player.Text = "Player 1";
            }

            else
            {
                btn.Text = "O";
                btn.BackColor = Color.Red;
                player.Text = "Player 2";
            }


            turn = !turn;
            btn.Enabled = false;

            turnCount++;
            lbl_turnCount.Text = turnCount.ToString();
           
            CheckWinner();
        }

        private void  NewGame()
        {
            turnCount = 0;

            lbl_turnCount.Text = turnCount.ToString();

            player.Text = "Player 1";

            Button[] buttons = { FirstRow_1, FirstRow_2, FirstRow_3, SecondRow_1, SecondRow_2, SecondRow_3, ThirdRow_1, ThirdRow_2, ThirdRow_3 };

            foreach (Button btn in buttons)
            {
                turn = true;
                btn.Enabled = true;
                btn.Text = string.Empty;
                btn.BackColor = Color.White;
            }
        }

         private void CheckWinner()
        {
           bool winner = false;

                // Horizontal checks
                if ((FirstRow_1.Text == FirstRow_2.Text) && (FirstRow_2.Text == FirstRow_3.Text) && (!FirstRow_1.Enabled))
                {
                    winner = true;
               
                }
                else if ((SecondRow_1.Text == SecondRow_2.Text) && (SecondRow_2.Text == SecondRow_3.Text) && (!SecondRow_1.Enabled))
                {
                    winner = true;
                }
                else if ((ThirdRow_1.Text == ThirdRow_2.Text) && (ThirdRow_2.Text == ThirdRow_3.Text) && (!ThirdRow_1.Enabled))
                {
                    winner = true;
                }

                //Vertical Checks
                else if ((FirstRow_1.Text == SecondRow_1.Text) && (SecondRow_1.Text == ThirdRow_1.Text) && (!FirstRow_1.Enabled))
                {
                    winner = true;
                }
                else if ((FirstRow_2.Text == SecondRow_2.Text) && (SecondRow_2.Text == ThirdRow_2.Text) && (!FirstRow_2.Enabled))
                {
                    winner = true;
                }
                else if ((FirstRow_3.Text == SecondRow_3.Text) && (SecondRow_3.Text == ThirdRow_3.Text) && (!FirstRow_3.Enabled))
                {
                    winner = true;
                }

                // Diagonal checks
                else if ((FirstRow_1.Text == SecondRow_2.Text) && (SecondRow_2.Text == ThirdRow_3.Text) && (!FirstRow_1.Enabled))
                {
                    winner = true;
                }
                else if ((FirstRow_3.Text == SecondRow_2.Text) && (SecondRow_2.Text == ThirdRow_1.Text) && (!ThirdRow_1.Enabled))
                {
                    winner = true;
                }

            if (winner)
            {
                string whoIsTheWinner = string.Empty;

                if (turn)
                {
                    whoIsTheWinner = "Player 2";
                    player2_score++;
                    lbl_player2_score.Text = player2_score.ToString();
                }
                else
                {
                    whoIsTheWinner = "Player 1";
                    player1_score++;
                    lbl_player1_score.Text = player1_score.ToString();
                }

                MessageBox.Show(whoIsTheWinner + " won!!!", "Yehuuu!");
                NewGame();
            }
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("No one won", "Oops!");
                    NewGame();
                }
            }

        }

        private void BtnResetGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void BtnPlayAgain_Click(object sender, EventArgs e)
        {
            player1_score = 0;
            player2_score = 0;

            lbl_player1_score.Text = player1_score.ToString();
            lbl_player2_score.Text = player2_score.ToString();

            NewGame();
        }

    }
}
