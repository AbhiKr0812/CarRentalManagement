namespace CarRentalMang.WinFormApp
{
    partial class ManageRentals
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.lbCarName = new System.Windows.Forms.Label();
            this.lbMake = new System.Windows.Forms.Label();
            this.tbDLNo = new System.Windows.Forms.TextBox();
            this.lbCarNo = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.gvRentals = new System.Windows.Forms.DataGridView();
            this.dtPickUp = new System.Windows.Forms.DateTimePicker();
            this.dtDrop = new System.Windows.Forms.DateTimePicker();
            this.cbAvailCars = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCompletion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(981, 574);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 39);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(855, 574);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 39);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(732, 574);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 39);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbCost
            // 
            this.tbCost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCost.Location = new System.Drawing.Point(495, 587);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(198, 22);
            this.tbCost.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(495, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 26;
            this.label1.Text = "Cost";
            // 
            // tbCustName
            // 
            this.tbCustName.Location = new System.Drawing.Point(17, 510);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(198, 22);
            this.tbCustName.TabIndex = 25;
            // 
            // lbCarName
            // 
            this.lbCarName.AutoSize = true;
            this.lbCarName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarName.Location = new System.Drawing.Point(17, 483);
            this.lbCarName.Name = "lbCarName";
            this.lbCarName.Size = new System.Drawing.Size(146, 22);
            this.lbCarName.TabIndex = 24;
            this.lbCarName.Text = "Customer Name";
            // 
            // lbMake
            // 
            this.lbMake.AutoSize = true;
            this.lbMake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMake.Location = new System.Drawing.Point(252, 557);
            this.lbMake.Name = "lbMake";
            this.lbMake.Size = new System.Drawing.Size(145, 22);
            this.lbMake.TabIndex = 22;
            this.lbMake.Text = "Drop Date/Time";
            // 
            // tbDLNo
            // 
            this.tbDLNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbDLNo.Location = new System.Drawing.Point(252, 510);
            this.tbDLNo.Name = "tbDLNo";
            this.tbDLNo.Size = new System.Drawing.Size(198, 22);
            this.tbDLNo.TabIndex = 21;
            // 
            // lbCarNo
            // 
            this.lbCarNo.AutoSize = true;
            this.lbCarNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarNo.Location = new System.Drawing.Point(252, 483);
            this.lbCarNo.Name = "lbCarNo";
            this.lbCarNo.Size = new System.Drawing.Size(172, 22);
            this.lbCarNo.TabIndex = 20;
            this.lbCarNo.Text = "Driving License No";
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.Location = new System.Drawing.Point(17, 557);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(163, 22);
            this.lbColor.TabIndex = 18;
            this.lbColor.Text = "PickUp Date/Time";
            // 
            // gvRentals
            // 
            this.gvRentals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRentals.Location = new System.Drawing.Point(16, 26);
            this.gvRentals.Name = "gvRentals";
            this.gvRentals.RowHeadersWidth = 51;
            this.gvRentals.RowTemplate.Height = 24;
            this.gvRentals.Size = new System.Drawing.Size(1090, 438);
            this.gvRentals.TabIndex = 17;
            this.gvRentals.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvRentals_CellMouseDoubleClick);
            // 
            // dtPickUp
            // 
            this.dtPickUp.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtPickUp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickUp.Location = new System.Drawing.Point(17, 587);
            this.dtPickUp.Name = "dtPickUp";
            this.dtPickUp.Size = new System.Drawing.Size(200, 22);
            this.dtPickUp.TabIndex = 31;
            // 
            // dtDrop
            // 
            this.dtDrop.CustomFormat = "dd-mm-yyyy HH:mm:ss";
            this.dtDrop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDrop.Location = new System.Drawing.Point(252, 587);
            this.dtDrop.Name = "dtDrop";
            this.dtDrop.Size = new System.Drawing.Size(200, 22);
            this.dtDrop.TabIndex = 32;
            // 
            // cbAvailCars
            // 
            this.cbAvailCars.FormattingEnabled = true;
            this.cbAvailCars.ItemHeight = 16;
            this.cbAvailCars.Location = new System.Drawing.Point(495, 508);
            this.cbAvailCars.Name = "cbAvailCars";
            this.cbAvailCars.Size = new System.Drawing.Size(198, 24);
            this.cbAvailCars.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(495, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 22);
            this.label2.TabIndex = 34;
            this.label2.Text = "Available Cars";
            // 
            // tbCompletion
            // 
            this.tbCompletion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCompletion.Location = new System.Drawing.Point(732, 510);
            this.tbCompletion.Name = "tbCompletion";
            this.tbCompletion.Size = new System.Drawing.Size(198, 22);
            this.tbCompletion.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(732, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 22);
            this.label3.TabIndex = 35;
            this.label3.Text = "Mark Completion";
            // 
            // ManageRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1118, 642);
            this.Controls.Add(this.tbCompletion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAvailCars);
            this.Controls.Add(this.dtDrop);
            this.Controls.Add(this.dtPickUp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCustName);
            this.Controls.Add(this.lbCarName);
            this.Controls.Add(this.lbMake);
            this.Controls.Add(this.tbDLNo);
            this.Controls.Add(this.lbCarNo);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.gvRentals);
            this.Name = "ManageRentals";
            this.Text = "Manage Rentals";
            this.Load += new System.EventHandler(this.ManageRentals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.Label lbCarName;
        private System.Windows.Forms.Label lbMake;
        private System.Windows.Forms.TextBox tbDLNo;
        private System.Windows.Forms.Label lbCarNo;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.DataGridView gvRentals;
        private System.Windows.Forms.DateTimePicker dtPickUp;
        private System.Windows.Forms.DateTimePicker dtDrop;
        private System.Windows.Forms.ComboBox cbAvailCars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCompletion;
        private System.Windows.Forms.Label label3;
    }
}