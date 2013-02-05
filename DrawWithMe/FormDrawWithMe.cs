using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace DrawWithMe
{
    public partial class FormDrawWithMe : Form
    {
        public bool Online;
        public LoginInfo LoginInfo;

        public FormDrawWithMe(string file)
        {
            InitializeComponent();

            Online = false;
            if (file != "")
                LoadImage(file);

            //Setup colors
            Canvas.Color1 = Color.Black;
            Canvas.Color2 = Color.White;
            colorDialog1.Color = Canvas.Color1;
            colorDialog2.Color = Canvas.Color2;
            panelColor1.BackColor = Canvas.Color1;
            panelColor2.BackColor = Canvas.Color2;

            //Setup image
            Canvas.Image = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Clear(Color.White);
            Canvas.BackgroundImage = Canvas.Image;
        }

        #region Events

        #region Buttons
        private void buttonSave_Click(object sender, EventArgs e)
        {
            new FormSave(Canvas.Image, "C:\\", null).ShowDialog();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Canvas.NewImage(LoadImage(@"C:\Users\Taylor\Pictures\RandomNiggahShit.PNG"));
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Canvas.Clear(Color.White);
        }

        private void multiplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMultiplayer(this).ShowDialog();
            if (Online)
                ConnectToMultiplayer();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            SetStatus(Canvas.NewPoint.X + ", " + Canvas.NewPoint.Y);
        }
        #endregion

        new private void Resize(object sender, EventArgs e)
        {
            new FormResize(this).ShowDialog();
        }

        private void panelColor1_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            Canvas.Color1 = colorDialog1.Color;
            panelColor1.BackColor = Canvas.Color1;
        }

        private void panelColor2_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog2.ShowDialog();
            Canvas.Color2 = colorDialog2.Color;
            panelColor2.BackColor = Canvas.Color2;
        }
        #endregion

        public Bitmap LoadImage(string location)
        {
            var bmp = new Bitmap(location);
            return bmp;
        }

        public void SetStatus(string text)
        {
            Status.Text = text;
        }

        public void ConnectToMultiplayer()
        {

        }
    }
}
