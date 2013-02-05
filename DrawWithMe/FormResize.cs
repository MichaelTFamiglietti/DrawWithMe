using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawWithMe
{
    public partial class FormResize : Form
    {
        Panel panel;
        FormDrawWithMe Main;

        public FormResize(FormDrawWithMe parent)
        {
            Main = parent;

            InitializeComponent();
            panel = Main.Canvas;
            numWidth.Value = panel.Width;
            numHeight.Value = panel.Height;
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            Main.Canvas.ResizePanel((int)numWidth.Value, (int)numHeight.Value);
            this.Close();
        }
    }
}
