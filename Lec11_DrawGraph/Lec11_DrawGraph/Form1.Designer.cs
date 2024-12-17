
namespace Lec11_DrawGraph
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
            this.pictureBoxGraphVisualization = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphVisualization)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGraphVisualization
            // 
            this.pictureBoxGraphVisualization.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxGraphVisualization.Name = "pictureBoxGraphVisualization";
            this.pictureBoxGraphVisualization.Size = new System.Drawing.Size(775, 425);
            this.pictureBoxGraphVisualization.TabIndex = 0;
            this.pictureBoxGraphVisualization.TabStop = false;
            this.pictureBoxGraphVisualization.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphVisualization_MouseDown);
            this.pictureBoxGraphVisualization.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphVisualization_MouseMove);
            this.pictureBoxGraphVisualization.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraphVisualization_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxGraphVisualization);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphVisualization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGraphVisualization;
    }
}

