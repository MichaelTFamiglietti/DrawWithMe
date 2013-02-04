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
            comboFileTypes.Items.AddRange(new string[] { "PNG", "BMP", "JPEG", "ICO", "GIF", "TIFF" });
            textLocation.Text = location;
            folderBrowser.SelectedPath = location;

            if(format != null)
                comboFileTypes.Text = format;
            else
                comboFileTypes.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!textLocation.Text.EndsWith("\\"))
                textLocation.Text += "\\";
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
                case "BMP": SaveAll(file + ".bmp", ImageFormat.Bmp); break;
                case "JPEG": SaveAll(file + ".jpg", ImageFormat.Jpeg); break;
                case "PNG": SaveAll(file + ".png", ImageFormat.Png); break;
                case "ICO": SaveAll(file + ".ico", ImageFormat.Icon); break;
                case "GIF": SaveAll(file + ".gif", ImageFormat.Gif); break;
                case "TIFF": SaveAll(file + ".tiff", ImageFormat.Tiff); break;
                default: MessageBox.Show("That file type is not supported"); break;
            }
        }

        void SaveAll(string location, ImageFormat format)
        {
            FileStream saveStream = new FileStream(location, FileMode.OpenOrCreate);
            bmp.Save(saveStream, format);

            saveStream.Flush();
            saveStream.Close();

            this.Close();
        }
    }
}
