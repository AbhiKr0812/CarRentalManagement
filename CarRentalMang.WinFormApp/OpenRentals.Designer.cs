﻿namespace CarRentalMang.WinFormApp
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
            this.lbCustName = new System.Windows.Forms.Label();
            this.lbDrop = new System.Windows.Forms.Label();
            this.tbDLNo = new System.Windows.Forms.TextBox();
            this.lbCarNo = new System.Windows.Forms.Label();
            this.lbPickUp = new System.Windows.Forms.Label();
            this.gvRentals = new System.Windows.Forms.DataGridView();
            this.rentalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentedCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtPickUp = new System.Windows.Forms.DateTimePicker();
            this.dtDrop = new System.Windows.Forms.DateTimePicker();
            this.cbAvailCars = new System.Windows.Forms.ComboBox();
            this.lbAvailableCars = new System.Windows.Forms.Label();
            this.tbRentalId = new System.Windows.Forms.TextBox();
            this.lbrentalId = new System.Windows.Forms.Label();
            this.bynReset = new System.Windows.Forms.Button();
            this.btnClosedRentals = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCarId = new System.Windows.Forms.TextBox();
            this.lbCarId = new System.Windows.Forms.Label();
            this.richTbComment = new System.Windows.Forms.RichTextBox();
            this.lbComment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(381, 592);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(122, 38);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(173, 592);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 38);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbCost
            // 
            this.tbCost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCost.Location = new System.Drawing.Point(492, 548);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(198, 22);
            this.tbCost.TabIndex = 27;
            this.tbCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCost_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(492, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 26;
            this.label1.Text = "Cost";
            // 
            // tbCustName
            // 
            this.tbCustName.Location = new System.Drawing.Point(14, 471);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(198, 22);
            this.tbCustName.TabIndex = 25;
            this.tbCustName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustName_KeyPress);
            // 
            // lbCustName
            // 
            this.lbCustName.AutoSize = true;
            this.lbCustName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustName.Location = new System.Drawing.Point(14, 444);
            this.lbCustName.Name = "lbCustName";
            this.lbCustName.Size = new System.Drawing.Size(146, 22);
            this.lbCustName.TabIndex = 24;
            this.lbCustName.Text = "Customer Name";
            // 
            // lbDrop
            // 
            this.lbDrop.AutoSize = true;
            this.lbDrop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDrop.Location = new System.Drawing.Point(249, 518);
            this.lbDrop.Name = "lbDrop";
            this.lbDrop.Size = new System.Drawing.Size(145, 22);
            this.lbDrop.TabIndex = 22;
            this.lbDrop.Text = "Drop Date/Time";
            // 
            // tbDLNo
            // 
            this.tbDLNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbDLNo.Location = new System.Drawing.Point(249, 471);
            this.tbDLNo.Name = "tbDLNo";
            this.tbDLNo.Size = new System.Drawing.Size(198, 22);
            this.tbDLNo.TabIndex = 21;
            this.tbDLNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDLNo_KeyPress);
            // 
            // lbCarNo
            // 
            this.lbCarNo.AutoSize = true;
            this.lbCarNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarNo.Location = new System.Drawing.Point(249, 444);
            this.lbCarNo.Name = "lbCarNo";
            this.lbCarNo.Size = new System.Drawing.Size(172, 22);
            this.lbCarNo.TabIndex = 20;
            this.lbCarNo.Text = "Driving License No";
            // 
            // lbPickUp
            // 
            this.lbPickUp.AutoSize = true;
            this.lbPickUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbPickUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPickUp.Location = new System.Drawing.Point(14, 518);
            this.lbPickUp.Name = "lbPickUp";
            this.lbPickUp.Size = new System.Drawing.Size(163, 22);
            this.lbPickUp.TabIndex = 18;
            this.lbPickUp.Text = "PickUp Date/Time";
            // 
            // gvRentals
            // 
            this.gvRentals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRentals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rentalId,
            this.vehicleId,
            this.custName,
            this.dlNo,
            this.rentedCar,
            this.pickUp,
            this.drop,
            this.cost,
            this.compStatus});
            this.gvRentals.Location = new System.Drawing.Point(16, 38);
            this.gvRentals.Name = "gvRentals";
            this.gvRentals.RowHeadersWidth = 51;
            this.gvRentals.RowTemplate.Height = 24;
            this.gvRentals.Size = new System.Drawing.Size(1090, 382);
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
            // vehicleId
            // 
            this.vehicleId.DataPropertyName = "VehicleId";
            this.vehicleId.HeaderText = "Car Id";
            this.vehicleId.MinimumWidth = 6;
            this.vehicleId.Name = "vehicleId";
            this.vehicleId.Visible = false;
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
            this.rentedCar.DataPropertyName = "CarName";
            this.rentedCar.HeaderText = "Rented Car";
            this.rentedCar.MinimumWidth = 6;
            this.rentedCar.Name = "rentedCar";
            // 
            // pickUp
            // 
            this.pickUp.DataPropertyName = "PickUpDate";
            this.pickUp.HeaderText = "PickUp Date";
            this.pickUp.MinimumWidth = 6;
            this.pickUp.Name = "pickUp";
            // 
            // drop
            // 
            this.drop.DataPropertyName = "DropDate";
            this.drop.HeaderText = "Drop Date";
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
            // compStatus
            // 
            this.compStatus.DataPropertyName = "CompletionStatus";
            this.compStatus.HeaderText = "Completed";
            this.compStatus.MinimumWidth = 6;
            this.compStatus.Name = "compStatus";
            this.compStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.compStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dtPickUp
            // 
            this.dtPickUp.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtPickUp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickUp.Location = new System.Drawing.Point(14, 548);
            this.dtPickUp.Name = "dtPickUp";
            this.dtPickUp.Size = new System.Drawing.Size(200, 22);
            this.dtPickUp.TabIndex = 31;
            // 
            // dtDrop
            // 
            this.dtDrop.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            this.dtDrop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDrop.Location = new System.Drawing.Point(249, 548);
            this.dtDrop.Name = "dtDrop";
            this.dtDrop.Size = new System.Drawing.Size(200, 22);
            this.dtDrop.TabIndex = 32;
            // 
            // cbAvailCars
            // 
            this.cbAvailCars.FormattingEnabled = true;
            this.cbAvailCars.ItemHeight = 16;
            this.cbAvailCars.Location = new System.Drawing.Point(492, 469);
            this.cbAvailCars.Name = "cbAvailCars";
            this.cbAvailCars.Size = new System.Drawing.Size(198, 24);
            this.cbAvailCars.TabIndex = 33;
            // 
            // lbAvailableCars
            // 
            this.lbAvailableCars.AutoSize = true;
            this.lbAvailableCars.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbAvailableCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAvailableCars.Location = new System.Drawing.Point(492, 444);
            this.lbAvailableCars.Name = "lbAvailableCars";
            this.lbAvailableCars.Size = new System.Drawing.Size(2, 22);
            this.lbAvailableCars.TabIndex = 34;
            // 
            // tbRentalId
            // 
            this.tbRentalId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbRentalId.Location = new System.Drawing.Point(408, 521);
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
            this.lbrentalId.Location = new System.Drawing.Point(408, 496);
            this.lbrentalId.Name = "lbrentalId";
            this.lbrentalId.Size = new System.Drawing.Size(86, 22);
            this.lbrentalId.TabIndex = 37;
            this.lbrentalId.Text = "Rental Id";
            this.lbrentalId.Visible = false;
            // 
            // bynReset
            // 
            this.bynReset.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bynReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bynReset.Location = new System.Drawing.Point(578, 592);
            this.bynReset.Name = "bynReset";
            this.bynReset.Size = new System.Drawing.Size(122, 38);
            this.bynReset.TabIndex = 39;
            this.bynReset.Text = "Reset";
            this.bynReset.UseVisualStyleBackColor = false;
            this.bynReset.Click += new System.EventHandler(this.bynReset_Click);
            // 
            // btnClosedRentals
            // 
            this.btnClosedRentals.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClosedRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosedRentals.Location = new System.Drawing.Point(790, 587);
            this.btnClosedRentals.Name = "btnClosedRentals";
            this.btnClosedRentals.Size = new System.Drawing.Size(180, 43);
            this.btnClosedRentals.TabIndex = 40;
            this.btnClosedRentals.Text = "Closed Rentals";
            this.btnClosedRentals.UseVisualStyleBackColor = false;
            this.btnClosedRentals.Click += new System.EventHandler(this.btnClosedRentals_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Please Click On Customer Name, To Update.";
            // 
            // tbCarId
            // 
            this.tbCarId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCarId.Location = new System.Drawing.Point(547, 521);
            this.tbCarId.Name = "tbCarId";
            this.tbCarId.Size = new System.Drawing.Size(39, 22);
            this.tbCarId.TabIndex = 43;
            this.tbCarId.Visible = false;
            // 
            // lbCarId
            // 
            this.lbCarId.AutoSize = true;
            this.lbCarId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarId.Location = new System.Drawing.Point(548, 496);
            this.lbCarId.Name = "lbCarId";
            this.lbCarId.Size = new System.Drawing.Size(62, 22);
            this.lbCarId.TabIndex = 42;
            this.lbCarId.Text = "Car Id";
            this.lbCarId.Visible = false;
            // 
            // richTbComment
            // 
            this.richTbComment.Location = new System.Drawing.Point(729, 469);
            this.richTbComment.Name = "richTbComment";
            this.richTbComment.Size = new System.Drawing.Size(253, 101);
            this.richTbComment.TabIndex = 44;
            this.richTbComment.Text = "Customer has read and agreed to the rental Terms & Conditions.";
            // 
            // lbComment
            // 
            this.lbComment.AutoSize = true;
            this.lbComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComment.Location = new System.Drawing.Point(729, 444);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(90, 22);
            this.lbComment.TabIndex = 45;
            this.lbComment.Text = "Comment";
            // 
            // OpenRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1118, 642);
            this.Controls.Add(this.lbComment);
            this.Controls.Add(this.richTbComment);
            this.Controls.Add(this.tbCarId);
            this.Controls.Add(this.lbCarId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClosedRentals);
            this.Controls.Add(this.bynReset);
            this.Controls.Add(this.tbRentalId);
            this.Controls.Add(this.lbrentalId);
            this.Controls.Add(this.lbAvailableCars);
            this.Controls.Add(this.cbAvailCars);
            this.Controls.Add(this.dtDrop);
            this.Controls.Add(this.dtPickUp);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCustName);
            this.Controls.Add(this.lbCustName);
            this.Controls.Add(this.lbDrop);
            this.Controls.Add(this.tbDLNo);
            this.Controls.Add(this.lbCarNo);
            this.Controls.Add(this.lbPickUp);
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
        private System.Windows.Forms.Label lbCustName;
        private System.Windows.Forms.Label lbDrop;
        private System.Windows.Forms.TextBox tbDLNo;
        private System.Windows.Forms.Label lbCarNo;
        private System.Windows.Forms.Label lbPickUp;
        private System.Windows.Forms.DataGridView gvRentals;
        private System.Windows.Forms.DateTimePicker dtPickUp;
        private System.Windows.Forms.DateTimePicker dtDrop;
        private System.Windows.Forms.ComboBox cbAvailCars;
        private System.Windows.Forms.Label lbAvailableCars;
        private System.Windows.Forms.TextBox tbRentalId;
        private System.Windows.Forms.Label lbrentalId;
        private System.Windows.Forms.Button bynReset;
        private System.Windows.Forms.Button btnClosedRentals;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCarId;
        private System.Windows.Forms.Label lbCarId;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn custName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentedCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn drop;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn compStatus;
        private System.Windows.Forms.RichTextBox richTbComment;
        private System.Windows.Forms.Label lbComment;
    }
}