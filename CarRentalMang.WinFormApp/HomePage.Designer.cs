namespace CarRentalMang.WinFormApp
{
    partial class HomePage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageCarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mangeRentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closedRentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageCarsToolStripMenuItem,
            this.mangeRentalsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1135, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageCarsToolStripMenuItem
            // 
            this.manageCarsToolStripMenuItem.Name = "manageCarsToolStripMenuItem";
            this.manageCarsToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.manageCarsToolStripMenuItem.Text = "Manage Cars";
            this.manageCarsToolStripMenuItem.Click += new System.EventHandler(this.manageCarsToolStripMenuItem_Click);
            // 
            // mangeRentalsToolStripMenuItem
            // 
            this.mangeRentalsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRentalsToolStripMenuItem,
            this.closedRentalsToolStripMenuItem});
            this.mangeRentalsToolStripMenuItem.Name = "mangeRentalsToolStripMenuItem";
            this.mangeRentalsToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.mangeRentalsToolStripMenuItem.Text = "Manage Rentals";
            // 
            // openRentalsToolStripMenuItem
            // 
            this.openRentalsToolStripMenuItem.Name = "openRentalsToolStripMenuItem";
            this.openRentalsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openRentalsToolStripMenuItem.Text = "Open Rentals";
            this.openRentalsToolStripMenuItem.Click += new System.EventHandler(this.openRentalsToolStripMenuItem_Click);
            // 
            // closedRentalsToolStripMenuItem
            // 
            this.closedRentalsToolStripMenuItem.Name = "closedRentalsToolStripMenuItem";
            this.closedRentalsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closedRentalsToolStripMenuItem.Text = "Closed Rentals";
            this.closedRentalsToolStripMenuItem.Click += new System.EventHandler(this.closedRentalsToolStripMenuItem_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 569);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomePage";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageCarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mangeRentalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRentalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closedRentalsToolStripMenuItem;
    }
}

