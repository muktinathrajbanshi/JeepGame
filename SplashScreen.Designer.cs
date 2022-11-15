
namespace GeepGameOk
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.pictureSplash = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.progressSplash = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureSplash
            // 
            this.pictureSplash.Image = global::GeepGameOk.Properties.Resources._123;
            this.pictureSplash.Location = new System.Drawing.Point(-16, -2);
            this.pictureSplash.Name = "pictureSplash";
            this.pictureSplash.Size = new System.Drawing.Size(709, 366);
            this.pictureSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSplash.TabIndex = 0;
            this.pictureSplash.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(-3, 395);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "This is a text";
            // 
            // timerProgress
            // 
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // progressSplash
            // 
            this.progressSplash.Location = new System.Drawing.Point(0, 364);
            this.progressSplash.Name = "progressSplash";
            this.progressSplash.Size = new System.Drawing.Size(702, 30);
            this.progressSplash.TabIndex = 2;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 433);
            this.ControlBox = false;
            this.Controls.Add(this.progressSplash);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pictureSplash);
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSplash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureSplash;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timerProgress;
        private System.Windows.Forms.ProgressBar progressSplash;
    }
}

