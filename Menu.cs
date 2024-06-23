using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Menu : Form
    {

        public static int Difficulty { get; set; }
        public static int HorizontalSize { get; set; }
        public static int VerticalSize { get; set; }

        public Menu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxDifficulty.SelectedItem?.ToString() != null) switch (cbxDifficulty.SelectedItem?.ToString())
                {
                    case "Easy":
                        Difficulty = 8;
                        break;
                    case "Medium":
                        Difficulty = 6;
                        break;
                    case "Hard":
                        Difficulty = 4;
                        break;
                    default:
                        return;
                }
                else throw new Exception();
                if (cbxSize.SelectedItem?.ToString() != null) switch (cbxSize.SelectedItem?.ToString())
                {
                    case "10x10":
                        HorizontalSize = 10;
                        VerticalSize = 10;
                        break;
                    case "16x16":
                        HorizontalSize = 16;
                        VerticalSize = 16;
                        break;
                    case "20x20":
                        HorizontalSize = 20;
                        VerticalSize = 20;
                        break;
                    case "25x25":
                        HorizontalSize = 25;
                        VerticalSize = 25;
                        break;
                    default:
                        return;
                }
                else throw new Exception();
                Hide();
                new Game().Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Select size and difficulty");
            }
        }
    }
}
