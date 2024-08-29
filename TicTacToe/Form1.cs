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
    public partial class Form1 : Form
    {
        /// <summary>
        /// Determines which players turn it is (true for Player X, false for Player O).
        /// </summary>
        Boolean checker;
        /// <summary>
        /// Track score for player X
        /// </summary>
        int playerXScore = 0;
        /// <summary>
        /// Track score for player O
        /// </summary>
        int playerOScore = 0;
        /// <summary>
        /// Detects Draw
        /// </summary>
        bool draw = true;
        /// <summary>
        /// Track draw score
        /// </summary>
        int drawscore = 0;

        //==========================================================================================================================================================================//
        /// <summary>
        /// Disables all Tic Tac Toe buttons, preventing further moves.
        /// </summary>
        void Enable_False()
        {
            btnTic1.Enabled = false;
            btnTic2.Enabled = false;
            btnTic3.Enabled = false;
            btnTic4.Enabled = false;
            btnTic5.Enabled = false;
            btnTic6.Enabled = false;
            btnTic7.Enabled = false;
            btnTic8.Enabled = false;
            btnTic9.Enabled = false;
        }
        //==========================================================================================================================================================================//
        /// <summary>
        /// Checks for a win and draw condition and updates the score and game status accordingly.
        /// </summary>
        void Score()
        {
            // Check for Player X win
            if ((btnTic1.Text == "X" && btnTic2.Text == "X" && btnTic3.Text == "X") ||
                (btnTic4.Text == "X" && btnTic5.Text == "X" && btnTic6.Text == "X") ||
                (btnTic7.Text == "X" && btnTic8.Text == "X" && btnTic9.Text == "X") ||
                (btnTic1.Text == "X" && btnTic4.Text == "X" && btnTic7.Text == "X") ||
                (btnTic2.Text == "X" && btnTic5.Text == "X" && btnTic8.Text == "X") ||
                (btnTic3.Text == "X" && btnTic6.Text == "X" && btnTic9.Text == "X") ||
                (btnTic1.Text == "X" && btnTic5.Text == "X" && btnTic9.Text == "X") ||
                (btnTic3.Text == "X" && btnTic5.Text == "X" && btnTic7.Text == "X"))
            {
                Enable_False();
                MessageBox.Show("Player X Wins!", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                playerXScore++;
                lblScoreX.Text = playerXScore.ToString();
                draw = false;
            }

            // Check for Player O win
            if ((btnTic1.Text == "O" && btnTic2.Text == "O" && btnTic3.Text == "O") ||
                (btnTic4.Text == "O" && btnTic5.Text == "O" && btnTic6.Text == "O") ||
                (btnTic7.Text == "O" && btnTic8.Text == "O" && btnTic9.Text == "O") ||
                (btnTic1.Text == "O" && btnTic4.Text == "O" && btnTic7.Text == "O") ||
                (btnTic2.Text == "O" && btnTic5.Text == "O" && btnTic8.Text == "O") ||
                (btnTic3.Text == "O" && btnTic6.Text == "O" && btnTic9.Text == "O") ||
                (btnTic1.Text == "O" && btnTic5.Text == "O" && btnTic9.Text == "O") ||
                (btnTic3.Text == "O" && btnTic5.Text == "O" && btnTic7.Text == "O"))
            {
                Enable_False();
                MessageBox.Show("Player O Wins!", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                playerOScore++;
                lblScoreO.Text = playerOScore.ToString();
                draw = false;
            }
           
            // Check for Draw
            if ((draw && btnTic1.Enabled == false && btnTic2.Enabled == false && btnTic3.Enabled == false) &&
               (btnTic4.Enabled == false && btnTic5.Enabled == false && btnTic6.Enabled == false) &&
               (btnTic7.Enabled == false && btnTic8.Enabled == false && btnTic9.Enabled == false))
            {
                MessageBox.Show("It's a Draw!","Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawscore++;
                lblDrawScore.Text = drawscore.ToString();
            }

        }
        //==========================================================================================================================================================================//
        /// <summary>
        /// Resets the game board and enables all buttons for a new game.
        /// </summary>
        void Reset()
        {
            btnTic1.Enabled = true;
            btnTic2.Enabled = true;
            btnTic3.Enabled = true;
            btnTic4.Enabled = true;
            btnTic5.Enabled = true;
            btnTic6.Enabled = true;
            btnTic7.Enabled = true;
            btnTic8.Enabled = true;
            btnTic9.Enabled = true;

            btnTic1.Text = "";
            btnTic2.Text = "";
            btnTic3.Text = "";
            btnTic4.Text = "";
            btnTic5.Text = "";
            btnTic6.Text = "";
            btnTic7.Text = "";
            btnTic8.Text = "";
            btnTic9.Text = "";

            btnTic1.BackColor = Color.White;
            btnTic2.BackColor = Color.White;
            btnTic3.BackColor = Color.White;
            btnTic4.BackColor = Color.White;
            btnTic5.BackColor = Color.White;
            btnTic6.BackColor = Color.White;
            btnTic7.BackColor = Color.White;
            btnTic8.BackColor = Color.White;
            btnTic9.BackColor = Color.White;

            checker = true; // Reset turn to Player X
            draw = true; // Reset bool value for new game
        }
        //==========================================================================================================================================================================//
        /// <summary>
        /// Handles the click event for each Tic Tac Toe button, updates the game board, and checks the game status.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTic_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (checker)
            {
                btn.Text = "X";
                checker = false;
            }
            else
            {
                btn.Text = "O";
                checker = true;
            }

            btn.Enabled = false;
            Score();
        }
        //==========================================================================================================================================================================//
        /// <summary>
        /// Initializes the form and sets the initial player turn to Player X.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            checker = true; // Start with Player X
        }

        //==========================================================================================================================================================================//

        /// <summary>
        /// resets the game board for a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Reset();
        }
        //==========================================================================================================================================================================//
        /// <summary>
        /// resets both the game board and the player scores and draw score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            playerXScore = 0;
            playerOScore = 0;
            drawscore = 0;
            lblScoreX.Text = "0";
            lblScoreO.Text = "0";
            lblDrawScore.Text = "0";
            
            Reset();
        }
        //==========================================================================================================================================================================//
        /// <summary>
        /// closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //==========================================================================================================================================================================//
    }
}
//==========================================================================END=OF=FILE=====================================================================================// 