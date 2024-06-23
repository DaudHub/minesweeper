using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Config : Form
    {

        private List<Form> Subscribers;
        private Color Theme { get; set; }
        private Color ForeTheme { get; set; }

        public Config()
        {
            InitializeComponent();
            Subscribers = new List<Form>() { this };
        }

        public void Subscribe(Form form)
        {
            Subscribers.Add(form);
        }

        private void ApplyConfig()
        {
            foreach (Form form in Subscribers)
            {
                form.BackColor = Theme;
                foreach (Control txt in form.Controls) txt.ForeColor = ForeTheme;
            }
        }

        private void btnDark_Click(object sender, EventArgs e)
        {
            Theme = Color.DarkGray;
            ForeTheme = Color.White;
            ApplyConfig();
        }

        private void btnLight_Click(object sender, EventArgs e)
        {

        }
    }
}
