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
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carAvailability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbColor = new System.Windows.Forms.Label();
            this.tbCarNo = new System.Windows.Forms.TextBox();
            this.lbCarNo = new System.Windows.Forms.Label();
            this.lbMake = new System.Windows.Forms.Label();
            this.lbCarModel = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbCarMake = new System.Windows.Forms.ComboBox();
            this.cbCarModel = new System.Windows.Forms.ComboBox();
            this.cbCarColor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // gvCars
            // 
            this.gvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.carMake,
            this.carModel,
            this.carColor,
            this.carNo,
            this.carAvailability});
            this.gvCars.Location = new System.Drawing.Point(12, 28);
            this.gvCars.Name = "gvCars";
            this.gvCars.RowHeadersWidth = 51;
            this.gvCars.RowTemplate.Height = 24;
            this.gvCars.Size = new System.Drawing.Size(1141, 419);
            this.gvCars.TabIndex = 1;
            this.gvCars.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvCars_CellMouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "CarId";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // carMake
            // 
            this.carMake.DataPropertyName = "Make";
            this.carMake.HeaderText = "Make";
            this.carMake.MinimumWidth = 6;
            this.carMake.Name = "carMake";
            // 
            // carModel
            // 
            this.carModel.DataPropertyName = "Model";
            this.carModel.HeaderText = "Model";
            this.carModel.MinimumWidth = 6;
            this.carModel.Name = "carModel";
            // 
            // carColor
            // 
            this.carColor.DataPropertyName = "Color";
            this.carColor.HeaderText = "Color";
            this.carColor.MinimumWidth = 6;
            this.carColor.Name = "carColor";
            // 
            // carNo
            // 
            this.carNo.DataPropertyName = "LicensePlateNumber";
            this.carNo.HeaderText = "License Plate No";
            this.carNo.MinimumWidth = 6;
            this.carNo.Name = "carNo";
            // 
            // carAvailability
            // 
            this.carAvailability.DataPropertyName = "Availability";
            this.carAvailability.HeaderText = "Available";
            this.carAvailability.MinimumWidth = 6;
            this.carAvailability.Name = "carAvailability";
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.Location = new System.Drawing.Point(522, 469);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(56, 22);
            this.lbColor.TabIndex = 4;
            this.lbColor.Text = "Color";
            // 
            // tbCarNo
            // 
            this.tbCarNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCarNo.Location = new System.Drawing.Point(790, 493);
            this.tbCarNo.Name = "tbCarNo";
            this.tbCarNo.Size = new System.Drawing.Size(198, 22);
            this.tbCarNo.TabIndex = 2;
            // 
            // lbCarNo
            // 
            this.lbCarNo.AutoSize = true;
            this.lbCarNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarNo.Location = new System.Drawing.Point(790, 469);
            this.lbCarNo.Name = "lbCarNo";
            this.lbCarNo.Size = new System.Drawing.Size(155, 22);
            this.lbCarNo.TabIndex = 6;
            this.lbCarNo.Text = "License Plate No";
            // 
            // lbMake
            // 
            this.lbMake.AutoSize = true;
            this.lbMake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMake.Location = new System.Drawing.Point(12, 469);
            this.lbMake.Name = "lbMake";
            this.lbMake.Size = new System.Drawing.Size(55, 22);
            this.lbMake.TabIndex = 8;
            this.lbMake.Text = "Make";
            // 
            // lbCarModel
            // 
            this.lbCarModel.AutoSize = true;
            this.lbCarModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarModel.Location = new System.Drawing.Point(268, 469);
            this.lbCarModel.Name = "lbCarModel";
            this.lbCarModel.Size = new System.Drawing.Size(61, 22);
            this.lbCarModel.TabIndex = 10;
            this.lbCarModel.Text = "Model";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(124, 558);
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
            this.btnUpdate.Location = new System.Drawing.Point(370, 558);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 43);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(621, 559);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 42);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReset.Location = new System.Drawing.Point(876, 558);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 42);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbCarMake
            // 
            this.cbCarMake.FormattingEnabled = true;
            this.cbCarMake.Location = new System.Drawing.Point(12, 493);
            this.cbCarMake.Name = "cbCarMake";
            this.cbCarMake.Size = new System.Drawing.Size(174, 24);
            this.cbCarMake.TabIndex = 19;
            this.cbCarMake.SelectedIndexChanged += new System.EventHandler(this.cbCarMake_SelectedIndexChanged);
            // 
            // cbCarModel
            // 
            this.cbCarModel.FormattingEnabled = true;
            this.cbCarModel.Location = new System.Drawing.Point(268, 493);
            this.cbCarModel.Name = "cbCarModel";
            this.cbCarModel.Size = new System.Drawing.Size(174, 24);
            this.cbCarModel.TabIndex = 20;
            // 
            // cbCarColor
            // 
            this.cbCarColor.AutoCompleteCustomSource.AddRange(new string[] {
            "Black",
            "Grey",
            "Red",
            "White"});
            this.cbCarColor.FormattingEnabled = true;
            this.cbCarColor.Items.AddRange(new object[] {
            "--Select--",
            "Black",
            "Grey",
            "Red",
            "White"});
            this.cbCarColor.Location = new System.Drawing.Point(522, 493);
            this.cbCarColor.Name = "cbCarColor";
            this.cbCarColor.Size = new System.Drawing.Size(174, 24);
            this.cbCarColor.TabIndex = 21;
            // 
            // ManageCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1165, 627);
            this.Controls.Add(this.cbCarColor);
            this.Controls.Add(this.cbCarModel);
            this.Controls.Add(this.cbCarMake);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbCarModel);
            this.Controls.Add(this.lbMake);
            this.Controls.Add(this.tbCarNo);
            this.Controls.Add(this.lbCarNo);
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
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.TextBox tbCarNo;
        private System.Windows.Forms.Label lbCarNo;
        private System.Windows.Forms.Label lbMake;
        private System.Windows.Forms.Label lbCarModel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbCarMake;
        private System.Windows.Forms.ComboBox cbCarModel;
        private System.Windows.Forms.ComboBox cbCarColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn carMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn carModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn carColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn carNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn carAvailability;
    }
}