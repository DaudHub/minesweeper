using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Minesweeper
{
    public class Square : Panel
    {
        public bool Mined { get; set; }
        public int MinesAround { get; set; }
        public bool Marked { get; set; }
        public bool Sweeped { get; set; }
        public Label LblNum { get; set; }

        public Square()
        {
            InitializeComponent();
            Mined = false;
            MinesAround = 0;
            Marked = false;
            Sweeped = false;
            BackColor = Color.Gray;
            LblNum = new Label();
            LblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LblNum.Dock = DockStyle.Fill;
            Margin = new System.Windows.Forms.Padding(1);
        }

        public Square(bool Mined, int MinesAround, bool Marked) : base()
        {
            InitializeComponent();
            this.Mined = Mined;
            this.MinesAround = MinesAround;
            this.Marked = Marked;
            Sweeped = false;
            BackColor = Color.Gray;
            LblNum = new Label();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        public override string ToString()
        {
            return $"Mined:{Mined},MinesAround:{MinesAround},Marked:{Marked},Sweeped:{Sweeped},BackColor:{BackColor},LblNum:{LblNum}";
        }
    }
}