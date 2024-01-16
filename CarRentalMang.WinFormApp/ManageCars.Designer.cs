namespace CarRentalMang.WinFormApp
{
    partial class ManageCars
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
            this.gvCars = new System.Windows.Forms.DataGridView();
            this.tbCarColor = new System.Windows.Forms.TextBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.tbCarNo = new System.Windows.Forms.TextBox();
            this.lbCarNo = new System.Windows.Forms.Label();
            this.tbCarBrand = new System.Windows.Forms.TextBox();
            this.lbMake = new System.Windows.Forms.Label();
            this.tbCarName = new System.Windows.Forms.TextBox();
            this.lbCarName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAvailability = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.tbCarId = new System.Windows.Forms.TextBox();
            this.lbCarId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // gvCars
            // 
            this.gvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCars.Location = new System.Drawing.Point(12, 12);
            this.gvCars.Name = "gvCars";
            this.gvCars.RowHeadersWidth = 51;
            this.gvCars.RowTemplate.Height = 24;
            this.gvCars.Size = new System.Drawing.Size(1141, 438);
            this.gvCars.TabIndex = 1;
            this.gvCars.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvCars_CellMouseDoubleClick);
            // 
            // tbCarColor
            // 
            this.tbCarColor.Location = new System.Drawing.Point(304, 496);
            this.tbCarColor.Name = "tbCarColor";
            this.tbCarColor.Size = new System.Drawing.Size(198, 22);
            this.tbCarColor.TabIndex = 1;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.Location = new System.Drawing.Point(305, 469);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(56, 22);
            this.lbColor.TabIndex = 4;
            this.lbColor.Text = "Color";
            // 
            // tbCarNo
            // 
            this.tbCarNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCarNo.Location = new System.Drawing.Point(13, 570);
            this.tbCarNo.Name = "tbCarNo";
            this.tbCarNo.Size = new System.Drawing.Size(198, 22);
            this.tbCarNo.TabIndex = 2;
            // 
            // lbCarNo
            // 
            this.lbCarNo.AutoSize = true;
            this.lbCarNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarNo.Location = new System.Drawing.Point(13, 543);
            this.lbCarNo.Name = "lbCarNo";
            this.lbCarNo.Size = new System.Drawing.Size(155, 22);
            this.lbCarNo.TabIndex = 6;
            this.lbCarNo.Text = "License Plate No";
            // 
            // tbCarBrand
            // 
            this.tbCarBrand.Location = new System.Drawing.Point(305, 570);
            this.tbCarBrand.Name = "tbCarBrand";
            this.tbCarBrand.Size = new System.Drawing.Size(198, 22);
            this.tbCarBrand.TabIndex = 3;
            // 
            // lbMake
            // 
            this.lbMake.AutoSize = true;
            this.lbMake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMake.Location = new System.Drawing.Point(305, 543);
            this.lbMake.Name = "lbMake";
            this.lbMake.Size = new System.Drawing.Size(55, 22);
            this.lbMake.TabIndex = 8;
            this.lbMake.Text = "Make";
            // 
            // tbCarName
            // 
            this.tbCarName.Location = new System.Drawing.Point(13, 496);
            this.tbCarName.Name = "tbCarName";
            this.tbCarName.Size = new System.Drawing.Size(198, 22);
            this.tbCarName.TabIndex = 0;
            // 
            // lbCarName
            // 
            this.lbCarName.AutoSize = true;
            this.lbCarName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarName.Location = new System.Drawing.Point(13, 469);
            this.lbCarName.Name = "lbCarName";
            this.lbCarName.Size = new System.Drawing.Size(59, 22);
            this.lbCarName.TabIndex = 10;
            this.lbCarName.Text = "Name";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(856, 486);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 43);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(856, 549);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 43);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(1001, 486);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 42);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(586, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Availability";
            // 
            // tbAvailability
            // 
            this.tbAvailability.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbAvailability.Location = new System.Drawing.Point(586, 570);
            this.tbAvailability.Name = "tbAvailability";
            this.tbAvailability.Size = new System.Drawing.Size(198, 22);
            this.tbAvailability.TabIndex = 13;
            this.tbAvailability.Text = "True";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReset.Location = new System.Drawing.Point(1001, 549);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 42);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tbCarId
            // 
            this.tbCarId.Location = new System.Drawing.Point(586, 496);
            this.tbCarId.Name = "tbCarId";
            this.tbCarId.Size = new System.Drawing.Size(198, 22);
            this.tbCarId.TabIndex = 18;
            this.tbCarId.Visible = false;
            // 
            // lbCarId
            // 
            this.lbCarId.AutoSize = true;
            this.lbCarId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarId.Location = new System.Drawing.Point(587, 469);
            this.lbCarId.Name = "lbCarId";
            this.lbCarId.Size = new System.Drawing.Size(62, 22);
            this.lbCarId.TabIndex = 19;
            this.lbCarId.Text = "Car Id";
            this.lbCarId.Visible = false;
            // 
            // ManageCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1165, 627);
            this.Controls.Add(this.tbCarId);
            this.Controls.Add(this.lbCarId);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbAvailability);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCarName);
            this.Controls.Add(this.lbCarName);
            this.Controls.Add(this.tbCarBrand);
            this.Controls.Add(this.lbMake);
            this.Controls.Add(this.tbCarNo);
            this.Controls.Add(this.lbCarNo);
            this.Controls.Add(this.tbCarColor);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.gvCars);
            this.Name = "ManageCars";
            this.Text = "Manage Cars";
            this.Load += new System.EventHandler(this.ManageCars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvCars;
        private System.Windows.Forms.TextBox tbCarColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.TextBox tbCarNo;
        private System.Windows.Forms.Label lbCarNo;
        private System.Windows.Forms.TextBox tbCarBrand;
        private System.Windows.Forms.Label lbMake;
        private System.Windows.Forms.TextBox tbCarName;
        private System.Windows.Forms.Label lbCarName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAvailability;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbCarId;
        private System.Windows.Forms.Label lbCarId;
    }
}