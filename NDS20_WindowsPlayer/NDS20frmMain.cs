using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDS20_WindowsPlayer
{
    public partial class NDS20frmMain : Form
    {
        public NDS20frmMain()
        {
            InitializeComponent();
        }

        private void NDS20frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Controls.Clear();
                    //this.Close();
                    Application.Exit();
                    break;
            }
  
        }
    }
}
