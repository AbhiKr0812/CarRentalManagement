namespace CarRentalMang.WinFormApp
{
    partial class ClosedRentals
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
            this.gvRentals = new System.Windows.Forms.DataGridView();
            this.rentalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentedCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOpenRentals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvRentals)).BeginInit();
            this.SuspendLayout();
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
            this.gvRentals.Location = new System.Drawing.Point(12, 12);
            this.gvRentals.Name = "gvRentals";
            this.gvRentals.RowHeadersWidth = 51;
            this.gvRentals.RowTemplate.Height = 24;
            this.gvRentals.Size = new System.Drawing.Size(1090, 438);
            this.gvRentals.TabIndex = 18;
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
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(305, 473);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(158, 57);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpenRentals
            // 
            this.btnOpenRentals.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpenRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenRentals.Location = new System.Drawing.Point(653, 473);
            this.btnOpenRentals.Name = "btnOpenRentals";
            this.btnOpenRentals.Size = new System.Drawing.Size(152, 57);
            this.btnOpenRentals.TabIndex = 20;
            this.btnOpenRentals.Text = "Open Rentals";
            this.btnOpenRentals.UseVisualStyleBackColor = false;
            this.btnOpenRentals.Click += new System.EventHandler(this.btnOpenRentals_Click);
            // 
            // ClosedRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 560);
            this.Controls.Add(this.btnOpenRentals);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gvRentals);
            this.Name = "ClosedRentals";
            this.Text = "Closed Rentals";
            this.Load += new System.EventHandler(this.ClosedRentals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRentals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvRentals;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn custName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentedCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn drop;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn completion;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOpenRentals;
    }
}