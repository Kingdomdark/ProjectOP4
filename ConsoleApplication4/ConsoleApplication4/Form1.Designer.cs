namespace ConsoleApplication4
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PBchar = new System.Windows.Forms.PictureBox();
            this.PbBlock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBchar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBlock)).BeginInit();
            this.SuspendLayout();
            // 
            // PBchar
            // 
            this.PBchar.Image = ((System.Drawing.Image)(resources.GetObject("PBchar.Image")));
            this.PBchar.Location = new System.Drawing.Point(490, 404);
            this.PBchar.Name = "PBchar";
            this.PBchar.Size = new System.Drawing.Size(100, 100);
            this.PBchar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBchar.TabIndex = 0;
            this.PBchar.TabStop = false;
            // 
            // PbBlock
            // 
            this.PbBlock.Image = ((System.Drawing.Image)(resources.GetObject("PbBlock.Image")));
            this.PbBlock.Location = new System.Drawing.Point(490, 1);
            this.PbBlock.Name = "PbBlock";
            this.PbBlock.Size = new System.Drawing.Size(50, 50);
            this.PbBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbBlock.TabIndex = 1;
            this.PbBlock.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1137, 531);
            this.Controls.Add(this.PbBlock);
            this.Controls.Add(this.PBchar);
            this.Name = "Form1";
            this.Text = "Block Catcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBchar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBlock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBchar;
        private System.Windows.Forms.PictureBox PbBlock;
    }
}