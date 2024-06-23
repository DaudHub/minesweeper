using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Minesweeper.Menu; // HorizontalSize, VerticalSize & Difficulty

namespace Minesweeper
{
    public partial class Game : Form
    {
        Time time;
        bool gameEnded;

        public Game()
        {
            InitializeComponent();
            gameEnded = false;
            time = new Time(0, 0, 0);
            pnlLayout.RowStyles.Clear();
            pnlLayout.ColumnStyles.Clear();
            pnlLayout.ColumnCount = 0;
            pnlLayout.RowCount = 0;
            for (int i = 0; i < HorizontalSize; i++)
            {
                pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, GetCellSizeFromNumberOfSquares(HorizontalSize)));
                pnlLayout.ColumnCount++;
            }
            for (int i = 0; i < VerticalSize; i++)
            {
                pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, GetCellSizeFromNumberOfSquares(VerticalSize)));
                pnlLayout.RowCount++;
            }
            createSquares();
        }

        private float GetCellSizeFromNumberOfSquares(int numberOfSquares)
        {
            return 400 / numberOfSquares;
        }
        
        private async void Sq_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameEnded == false)
            {
                Square sq = (Square)sender;
                if (e.Button == MouseButtons.Left)
                {
                    if (sq.Mined && sq.Marked == false)
                    {
                        EndGame();
                    }
                    else if (sq.Marked == false && sq.Sweeped == false)
                    {
                        sq.Sweeped = true;
                        sq.BackColor = Color.LightGray;
                        if (sq.MinesAround == 0) await asyncSweepZeroes(sq);
                        else
                        {
                            ShowLabel(sq);
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (sq.Sweeped == false)
                    {
                        sq.Marked = sq.Marked ? false : true;
                        if (sq.Marked) sq.BackColor = Color.Red;
                        else sq.BackColor = Color.Gray;
                    }
                }
                EndIfWin();
            }
        }

        private void Sq_MouseEnter(object sender, EventArgs e)
        {
            if (gameEnded == false)
            {
                Square sq = (Square)sender;
                if (sq.Sweeped == false && sq.Marked == false)
                    sq.BackColor = Color.LightGray;
            }
        }

        private void Sq_MouseLeave(object sender, EventArgs e)
        {
            if (gameEnded == false)
            {
                Square sq = (Square)sender;
                if (sq.Sweeped == false && sq.Marked == false)
                    sq.BackColor = Color.Gray;
            }
        }

        private void EndGame()
        {
            gameEnded = true;
            foreach (Square sq in pnlLayout.Controls)
            {
                if (sq.Mined)
                {
                    if (sq.Marked) sq.BackColor = Color.Green;
                    else sq.BackColor = Color.Black;
                }
            }
            gameTime.Enabled = false;
        }

        private void ResetGame()
        {
            foreach (Square sq in pnlLayout.Controls)
            {
                sq.Mined = false;
                sq.Marked = false;
                sq.Sweeped = false;
                sq.MinesAround = 0;
                sq.BackColor = Color.Gray;
                sq.Controls.Clear();
            }
            gameEnded = false;
            defineSquareData();
            time.ResetCount();
            lblTimeCount.Text = time.ToString();
            gameTime.Enabled = true;
        }

        private void createSquares()
        {
            for (int i = 0; i < pnlLayout.ColumnCount * pnlLayout.RowCount; i++)
            {
                Square sq = new Square();
                sq.MouseClick += new MouseEventHandler(Sq_MouseClick);
                sq.MouseEnter += new EventHandler(Sq_MouseEnter);
                sq.MouseLeave += new EventHandler(Sq_MouseLeave);
                pnlLayout.Controls.Add(sq);
            }
            defineSquareData();
        }

        public void defineSquareData()
        {
            Random randomizer = new Random();
            foreach (Square sq in pnlLayout.Controls)
            {
                int random;
                random = randomizer.Next(0, Difficulty);
                if (random == 0)
                {
                    sq.Mined = true;
                }
            }
            foreach (Square current in pnlLayout.Controls)
            {
                if (current.Mined == false)
                {
                    foreach (Square sq in GetSquaresAround(current))
                    {
                        if (sq.Mined) current.MinesAround++;
                    }
                }
            }
        }

        private async Task asyncSweepZeroes(Square sq)
        {
            await Task.Run(() => Thread.Sleep(30));
            List<Square> squaresAround = GetSquaresAround(sq);
            foreach (Square square in squaresAround)
            {
                if (square.MinesAround == 0 && square.Sweeped == false)
                {
                    square.Sweeped = true;
                    square.BackColor = Color.LightGray;
                    foreach (Square subSquare in GetSquaresAround(square))
                    {
                        if (subSquare.MinesAround != 0)
                        {
                            ShowLabel(subSquare);
                        }
                    }
                    await asyncSweepZeroes(square);
                }else if (square.MinesAround != 0 && square.Sweeped == false)
                {
                    ShowLabel(square);
                }
            }
        }

        private async void EndIfWin()
        {
            await Task.Run(() =>
            {
                if (WinCheck())
                {
                    gameEnded = true;
                    gameTime.Enabled = false;
                    MessageBox.Show($"You win!! Your time was {time.ToString()}");
                }
            });
        }

        private bool WinCheck()
        {
            foreach (Square sq in pnlLayout.Controls)
            {
                if (sq.Mined && !sq.Marked)
                    return false;
                if (!sq.Mined && sq.Marked)
                    return false;
                if (!sq.Mined && !sq.Sweeped)
                    return false;
            }
            return true;
        }

        private List<Square> GetSquaresAround(Square square)
        {
            List<Square> result = new List<Square>();
            TableLayoutPanelCellPosition origin = pnlLayout.GetPositionFromControl(square);
            int column = origin.Column;
            int row = origin.Row;
            Square selectedSq;
            if (row > 0 && column > 0)
            {
                selectedSq = (Square) pnlLayout.GetControlFromPosition(column - 1, row - 1);
                result.Add(selectedSq);
            }
            if (column > 0)
            {
                selectedSq = (Square)pnlLayout.GetControlFromPosition(column - 1, row);
                result.Add(selectedSq);
            }
            if (column > 0 && row < (pnlLayout.RowCount - 1))
            {
                selectedSq = (Square)pnlLayout.GetControlFromPosition(column - 1, row + 1);
                result.Add(selectedSq);
            }
            if (row > 0)
            {
                selectedSq = (Square)pnlLayout.GetControlFromPosition(column, row - 1);
                result.Add(selectedSq);
            }
            if (row < (pnlLayout.RowCount - 1))
            {
                selectedSq = (Square)pnlLayout.GetControlFromPosition(column, row + 1);
                result.Add(selectedSq);
            }
            if (column < (pnlLayout.ColumnCount - 1) && row > 0)
            {
                selectedSq = (Square)pnlLayout.GetControlFromPosition(column + 1, row - 1);
                result.Add(selectedSq);
            }
            if (column < (pnlLayout.ColumnCount - 1))
            {
                selectedSq = (Square)pnlLayout.GetControlFromPosition(column + 1, row);
                result.Add(selectedSq);
            }
            if (row < (pnlLayout.RowCount - 1) && column < (pnlLayout.ColumnCount - 1))
            {
                selectedSq = (Square)pnlLayout.GetControlFromPosition(column + 1, row + 1);
                result.Add(selectedSq);
            }
            return result;
        }

        private void ShowLabel(Square sq)
        {
            sq.Sweeped = true;
            sq.BackColor = Color.LightGray;
            sq.LblNum.Text = sq.MinesAround.ToString();
            sq.Controls.Add(sq.LblNum);
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void gameTime_Tick(object sender, EventArgs e)
        {
            time.AddOneSecond();
            lblTimeCount.Text = time.ToString();
        }
        
        private void Game_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}