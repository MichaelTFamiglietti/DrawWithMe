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
        FormDrawWithMe Parent;

        public FormResize(FormDrawWithMe parent)
        {
            Parent = parent;

            InitializeComponent();
            panel = Parent.Canvas;
            Width.Value = panel.Width;
            Height.Value = panel.Height;
        }

        private void Resize(object sender, EventArgs e)
        {
            Bitmap old = new Bitmap(Parent.image);
            Parent.image = new Bitmap(Parent.Canvas.Size.Width, Parent.Canvas.Size.Height);
            Parent.Canvas.Size = new Size((int)Width.Value, (int)Height.Value);
            Parent.Canvas.BackgroundImage = Parent.image;
            Parent.Clear(Color.White);
            Parent.Paste(old, 0, 0);
            this.Close();
        }
    }
}
