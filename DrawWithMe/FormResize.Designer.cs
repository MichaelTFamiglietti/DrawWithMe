namespace DrawWithMe
{
    partial class FormResize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResize));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonResize = new System.Windows.Forms.Button();
            this.Width = new System.Windows.Forms.NumericUpDown();
            this.Height = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // buttonResize
            // 
            this.buttonResize.Location = new System.Drawing.Point(15, 61);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(163, 23);
            this.buttonResize.TabIndex = 4;
            this.buttonResize.Text = "Resize";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.Click += new System.EventHandler(this.Resize);
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(53, 10);
            this.Width.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(120, 20);
            this.Width.TabIndex = 5;
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(53, 36);
            this.Height.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(120, 20);
            this.Height.TabIndex = 6;
            // 
            // FormResize
            // 
            this.AcceptButton = this.buttonResize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 87);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResize";
            this.Text = "FormResize";
            ((System.ComponentModel.ISupportInitialize)(this.Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.NumericUpDown Width;
        private System.Windows.Forms.NumericUpDown Height;
    }
}