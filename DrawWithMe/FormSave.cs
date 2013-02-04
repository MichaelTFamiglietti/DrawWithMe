using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Interop;

namespace DrawWithMe
{
    public partial class FormSave : Form
    {
        Bitmap bmp;
        
        public FormSave(Bitmap image, string location, string format)
        {
            InitializeComponent();

            bmp = image;
            comboFileTypes.Items.AddRange(new string[] { "PNG", "BMP", "JPEG" });
            textLocation.Text = location;
            folderBrowser.SelectedPath = location;

            if(format != null)
                comboFileTypes.Text = format;
            else
                comboFileTypes.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textLocation.Text != "" && textName.Text != "" && comboFileTypes.Text != "")
                Save(textLocation.Text + textName.Text, comboFileTypes.Text);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                textLocation.Text = folderBrowser.SelectedPath;
        }

        private void Save(string file, string type)
        {
            switch(type)
            {
                case "BMP": SaveBMP(file); break;
                case "JPEG": SaveJPEG(file); break;
                case "PNG": SavePNG(file); break;
                default: MessageBox.Show("That file type is not supported"); break;
            }
        }

        void SaveBMP(string location)
        {
            FileStream saveStream = new FileStream(location + ".bmp", FileMode.OpenOrCreate);
            bmp.Save(saveStream, ImageFormat.Bmp);

            saveStream.Flush();
            saveStream.Close();

            this.Close();
        }

        void SavePNG(string location)
        {
            FileStream saveStream = new FileStream(location + ".png", FileMode.OpenOrCreate);
            bmp.Save(saveStream, ImageFormat.Png);

            saveStream.Flush();
            saveStream.Close();

            this.Close();
        }

        void SaveJPEG(string location)
        {
            FileStream saveStream = new FileStream(location + ".jpeg", FileMode.OpenOrCreate);
            bmp.Save(saveStream, ImageFormat.Jpeg);

            saveStream.Flush();
            saveStream.Close();

            this.Close();
        }
    }
}
