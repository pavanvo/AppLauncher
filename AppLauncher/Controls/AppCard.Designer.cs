
namespace AppLauncher {
    partial class AppCard {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vlcControl
            // 
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.vlcControl.Location = new System.Drawing.Point(0, 56);
            this.vlcControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(488, 337);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 0;
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcMediaplayerOptions = null;
            // 
            // labelName
            // 
            this.labelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Blue;
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Margin = new System.Windows.Forms.Padding(8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(488, 35);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrice
            // 
            this.labelPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(189, 359);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(108, 33);
            this.labelPrice.TabIndex = 2;
            this.labelPrice.Text = "200";
            this.labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AppCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.vlcControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AppCard";
            this.Size = new System.Drawing.Size(488, 393);
            this.Load += new System.EventHandler(this.AppCard_Load);
            this.FontChanged += new System.EventHandler(this.AppCard_Click);
            this.Click += new System.EventHandler(this.AppCard_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPrice;
    }
}
