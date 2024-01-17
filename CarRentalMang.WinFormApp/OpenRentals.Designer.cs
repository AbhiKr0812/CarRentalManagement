namespace CarRentalMang.WinFormApp
{
    partial class OpenRentals
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
            this.rentalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentedCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtPickUp = new System.Windows.Forms.DateTimePicker();
            this.dtDrop = new System.Windows.Forms.DateTimePicker();
            this.cbAvailCars = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCompletion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRentalId = new System.Windows.Forms.TextBox();
            this.lbrentalId = new System.Windows.Forms.Label();
            this.bynReset = new System.Windows.Forms.Button();
            this.btnClosedRentals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(867, 579);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 39);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(732, 579);
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
            this.gvRentals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rentalId,
            this.custName,
            this.dlNo,
            this.rentedCar,
            this.pickUp,
            this.drop,
            this.cost,
            this.completion});
            this.gvRentals.Location = new System.Drawing.Point(16, 26);
            this.gvRentals.Name = "gvRentals";
            this.gvRentals.RowHeadersWidth = 51;
            this.gvRentals.RowTemplate.Height = 24;
            this.gvRentals.Size = new System.Drawing.Size(1090, 438);
            this.gvRentals.TabIndex = 17;
            this.gvRentals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRentals_CellClick);
            // 
            // rentalId
            // 
            this.rentalId.DataPropertyName = "Id";
            this.rentalId.HeaderText = "Id";
            this.rentalId.MinimumWidth = 6;
            this.rentalId.Name = "rentalId";
            this.rentalId.Visible = false;
            // 
            // custName
            // 
            this.custName.DataPropertyName = "CustomerName";
            this.custName.HeaderText = "Customer Name";
            this.custName.MinimumWidth = 6;
            this.custName.Name = "custName";
            // 
            // dlNo
            // 
            this.dlNo.DataPropertyName = "DrivingLicenceNo";
            this.dlNo.HeaderText = "Driving License No";
            this.dlNo.MinimumWidth = 6;
            this.dlNo.Name = "dlNo";
            // 
            // rentedCar
            // 
            this.rentedCar.DataPropertyName = "VehicleId";
            this.rentedCar.HeaderText = "Rented Car";
            this.rentedCar.MinimumWidth = 6;
            this.rentedCar.Name = "rentedCar";
            // 
            // pickUp
            // 
            this.pickUp.DataPropertyName = "PickUpDate";
            this.pickUp.HeaderText = "PickUp Date/Time";
            this.pickUp.MinimumWidth = 6;
            this.pickUp.Name = "pickUp";
            // 
            // drop
            // 
            this.drop.DataPropertyName = "DropDate";
            this.drop.HeaderText = "Drop Date/Time";
            this.drop.MinimumWidth = 6;
            this.drop.Name = "drop";
            // 
            // cost
            // 
            this.cost.DataPropertyName = "Cost";
            this.cost.HeaderText = "Rental Cost";
            this.cost.MinimumWidth = 6;
            this.cost.Name = "cost";
            // 
            // completion
            // 
            this.completion.DataPropertyName = "CompletionStatus";
            this.completion.HeaderText = "Completed";
            this.completion.MinimumWidth = 6;
            this.completion.Name = "completion";
            this.completion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.completion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.dtDrop.CustomFormat = "dd-MM-yyyy HH:mm:ss";
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
            this.tbCompletion.Text = "False";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(732, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 22);
            this.label3.TabIndex = 35;
            this.label3.Text = "Completion Status";
            // 
            // tbRentalId
            // 
            this.tbRentalId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbRentalId.Location = new System.Drawing.Point(709, 538);
            this.tbRentalId.Name = "tbRentalId";
            this.tbRentalId.Size = new System.Drawing.Size(39, 22);
            this.tbRentalId.TabIndex = 38;
            this.tbRentalId.Visible = false;
            // 
            // lbrentalId
            // 
            this.lbrentalId.AutoSize = true;
            this.lbrentalId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbrentalId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrentalId.Location = new System.Drawing.Point(709, 511);
            this.lbrentalId.Name = "lbrentalId";
            this.lbrentalId.Size = new System.Drawing.Size(2, 22);
            this.lbrentalId.TabIndex = 37;
            this.lbrentalId.Visible = false;
            // 
            // bynReset
            // 
            this.bynReset.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bynReset.Location = new System.Drawing.Point(999, 579);
            this.bynReset.Name = "bynReset";
            this.bynReset.Size = new System.Drawing.Size(107, 39);
            this.bynReset.TabIndex = 39;
            this.bynReset.Text = "Reset";
            this.bynReset.UseVisualStyleBackColor = false;
            this.bynReset.Click += new System.EventHandler(this.bynReset_Click);
            // 
            // btnClosedRentals
            // 
            this.btnClosedRentals.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClosedRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosedRentals.Location = new System.Drawing.Point(960, 498);
            this.btnClosedRentals.Name = "btnClosedRentals";
            this.btnClosedRentals.Size = new System.Drawing.Size(133, 52);
            this.btnClosedRentals.TabIndex = 40;
            this.btnClosedRentals.Text = "Closed Rentals";
            this.btnClosedRentals.UseVisualStyleBackColor = false;
            this.btnClosedRentals.Click += new System.EventHandler(this.btnClosedRentals_Click);
            // 
            // OpenRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1118, 642);
            this.Controls.Add(this.btnClosedRentals);
            this.Controls.Add(this.bynReset);
            this.Controls.Add(this.tbRentalId);
            this.Controls.Add(this.lbrentalId);
            this.Controls.Add(this.tbCompletion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAvailCars);
            this.Controls.Add(this.dtDrop);
            this.Controls.Add(this.dtPickUp);
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
            this.Name = "OpenRentals";
            this.Text = "Open Rentals";
            this.Load += new System.EventHandler(this.OpenRentals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.DataGridViewTextBoxColumn rentalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn custName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentedCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn drop;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn completion;
        private System.Windows.Forms.TextBox tbRentalId;
        private System.Windows.Forms.Label lbrentalId;
        private System.Windows.Forms.Button bynReset;
        private System.Windows.Forms.Button btnClosedRentals;
    }
}