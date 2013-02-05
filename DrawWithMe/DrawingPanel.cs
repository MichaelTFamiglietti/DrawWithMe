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
    public partial class DrawingPanel : Panel
    {
        public Color Color1, Color2;
        public Bitmap Image;
        public Point OldPoint, NewPoint;

        public DrawingPanel()
        {
            InitializeComponent();
            // Set the value of the double-buffering style bits to true.
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        #region Methods
        public void Clear(Color color)
        {
            Image = new Bitmap(Image, Size);
            for (int col = 0; col < Image.Width; col++)
                for (int row = 0; row < Image.Height; row++)
                    Image.SetPixel(col, row, color);
            BackgroundImage = Image;
        }

        public void DrawLine(Point p1, Point p2, Color color)
        {
            Image = new Bitmap(Image, Size);

            var g = Graphics.FromImage(Image);
            g.DrawLine(new Pen(color), p1, p2);

            BackgroundImage = Image;
        }

        public void Paste(Bitmap toPaste, int x, int y)
        {
            Bitmap bmp = new Bitmap(toPaste);
            Image = new Bitmap(Image, Size);

            for (int col = 0; col < bmp.Width; col++)
                for (int row = 0; row < bmp.Height; row++)
                    if (col + x >= 0 && col + x < Image.Width && row + y >= 0 && row + y < Image.Height)
                        Image.SetPixel(col + x, row + y, bmp.GetPixel(col, row));

            BackgroundImage = Image;
        }

        public void SetPixel(Point point, Color color)
        {
            Image = new Bitmap(Image, Size);
            Image.SetPixel(point.X, point.Y, color);
            BackgroundImage = Image;
        }

        public void NewImage(Bitmap image)
        {

        }

        public void ResizePanel(int width, int height)
        {
            Bitmap old = new Bitmap(Image);
            Image = new Bitmap(width, height);
            Size = new Size(width, height);
            BackgroundImage = Image;
            Clear(Color.White);
            Paste(old, 0, 0);
        }
        #endregion

        #region Override
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            OldPoint = NewPoint;
            NewPoint = new Point(e.X, e.Y);

            if (e.Button == MouseButtons.Left)
                if (NewPoint.X >= 0 && NewPoint.X < Image.Width && NewPoint.Y >= 0 && NewPoint.Y < Image.Height)
                    DrawLine(OldPoint, NewPoint, Color1);

            if (e.Button == MouseButtons.Right)
                if (NewPoint.X >= 0 && NewPoint.X < Image.Width && NewPoint.Y >= 0 && NewPoint.Y < Image.Height)
                    DrawLine(OldPoint, NewPoint, Color2);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (NewPoint.X >= 0 && NewPoint.X < Image.Width && NewPoint.Y >= 0 && NewPoint.Y < Image.Height)
                    SetPixel(NewPoint, Color1);

            if (e.Button == MouseButtons.Right)
                if (NewPoint.X >= 0 && NewPoint.X < Image.Width && NewPoint.Y >= 0 && NewPoint.Y < Image.Height)
                    SetPixel(NewPoint, Color2);
        }
        #endregion
    }
}
