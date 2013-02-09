using Alta.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace DrawWithMe
{
    public partial class FormDrawWithMe : Form
    {
        public bool Online;
        public ClientHandler Client;
        public int port;
        public string ip;
        
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
        #endregion

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            SetStatus(Canvas.NewPoint.X + ", " + Canvas.NewPoint.Y);
        }

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
            Client = new ClientHandler();
            Client.SynchronizingObject = this;
            Client.Connect(IPAddress.Parse(ip), port, Connect);
            Client.ReceivedTcp += Client_ReceivedTcp;
            Client.AuthRequested += Client_AuthRequested;
            Client.Disconnected += Client_Disconnected;
            Online = true;
        }

        #region Client
        private void Client_ReceivedTcp(object sender, PacketEventArgs e)
        {

        }

        private void Client_AuthRequested(object sender, EventArgs e)
        {

        }

        private void Client_Disconnected(object sender, NetEventArgs e)
        {

        }

        private void DrawLine(Point p1, Point p2, Color color)
        {
            Canvas.Image = new Bitmap(Canvas.Image, Size);

            var g = Graphics.FromImage(Canvas.Image);
            g.DrawLine(new Pen(color), p1, p2);

            Canvas.BackgroundImage = Canvas.Image;
        }
        #endregion

        public void Connect(object sender, Exception e)
        {
            if (e != null)
            {
                MessageBox.Show(e.Message);
                Client.Dispose();
                Online = false;
                return;
            }
        }
    }
}
