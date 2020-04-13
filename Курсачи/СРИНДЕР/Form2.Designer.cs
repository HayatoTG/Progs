namespace СРИНДЕР
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox profileimage;
        private System.Windows.Forms.Label labelnameage;
        private System.Windows.Forms.Label aboutme;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Button editprofile;
        private System.Windows.Forms.Button messages;
        private System.Windows.Forms.Button notifications;
        private System.Windows.Forms.Button findcouple;     
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel infopanel;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.Form form3;
        private System.Windows.Forms.Form form4;
        private System.Windows.Forms.PictureBox profileimageCF;
        private System.Windows.Forms.Label labelnameageCF;
        private System.Windows.Forms.Label aboutmeCF;
        private System.Windows.Forms.Panel infopanelCF;
        private System.Windows.Forms.Label textinfo;
        private System.Windows.Forms.Label textinfoCF;
        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.Button buttonfocus;
        private System.Windows.Forms.PictureBox like;
        private System.Windows.Forms.PictureBox dislike;
    }
}