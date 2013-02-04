using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawWithMe
{
    public partial class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            InitializeComponent();
            // Set the value of the double-buffering style bits to true.
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }
    }
}
