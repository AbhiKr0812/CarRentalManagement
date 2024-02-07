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
            this.carNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tbCarId = new System.Windows.Forms.TextBox();
            this.lbCarId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvCars
            // 
            this.gvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.carNo,
            this.carModel,
            this.carColor,
            this.carMake});
            this.gvCars.Location = new System.Drawing.Point(12, 28);
            this.gvCars.Name = "gvCars";
            this.gvCars.RowHeadersVisible = false;
            this.gvCars.RowHeadersWidth = 51;
            this.gvCars.RowTemplate.Height = 24;
            this.gvCars.Size = new System.Drawing.Size(1141, 391);
            this.gvCars.TabIndex = 1;
            this.gvCars.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCars_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "CarId";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Id.Visible = false;
            // 
            // carNo
            // 
            this.carNo.DataPropertyName = "LicensePlateNumber";
            this.carNo.HeaderText = "License Plate No";
            this.carNo.MinimumWidth = 6;
            this.carNo.Name = "carNo";
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
            // carMake
            // 
            this.carMake.DataPropertyName = "Make";
            this.carMake.HeaderText = "Make";
            this.carMake.MinimumWidth = 6;
            this.carMake.Name = "carMake";
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.Location = new System.Drawing.Point(504, 38);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(56, 22);
            this.lbColor.TabIndex = 4;
            this.lbColor.Text = "Color";
            // 
            // tbCarNo
            // 
            this.tbCarNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCarNo.Location = new System.Drawing.Point(758, 62);
            this.tbCarNo.Name = "tbCarNo";
            this.tbCarNo.Size = new System.Drawing.Size(198, 27);
            this.tbCarNo.TabIndex = 2;
            this.tbCarNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCarNo_KeyPress);
            // 
            // lbCarNo
            // 
            this.lbCarNo.AutoSize = true;
            this.lbCarNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarNo.Location = new System.Drawing.Point(758, 38);
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
            this.lbMake.Location = new System.Drawing.Point(20, 38);
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
            this.lbCarModel.Location = new System.Drawing.Point(276, 38);
            this.lbCarModel.Name = "lbCarModel";
            this.lbCarModel.Size = new System.Drawing.Size(61, 22);
            this.lbCarModel.TabIndex = 10;
            this.lbCarModel.Text = "Model";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(179, 122);
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
            this.btnUpdate.Location = new System.Drawing.Point(387, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 42);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(604, 122);
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
            this.btnReset.Location = new System.Drawing.Point(806, 122);
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
            this.cbCarMake.Location = new System.Drawing.Point(20, 62);
            this.cbCarMake.Name = "cbCarMake";
            this.cbCarMake.Size = new System.Drawing.Size(174, 28);
            this.cbCarMake.TabIndex = 19;
            this.cbCarMake.SelectedIndexChanged += new System.EventHandler(this.cbCarMake_SelectedIndexChanged);
            // 
            // cbCarModel
            // 
            this.cbCarModel.FormattingEnabled = true;
            this.cbCarModel.Location = new System.Drawing.Point(276, 62);
            this.cbCarModel.Name = "cbCarModel";
            this.cbCarModel.Size = new System.Drawing.Size(174, 28);
            this.cbCarModel.TabIndex = 20;
            // 
            // cbCarColor
            // 
            this.cbCarColor.AutoCompleteCustomSource.AddRange(new string[] {
            "Black",
            "Grey",
            "Red",
            "White"});
            this.cbCarColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCarColor.FormattingEnabled = true;
            this.cbCarColor.Items.AddRange(new object[] {
            "--Select--",
            "Black",
            "Grey",
            "Red",
            "White"});
            this.cbCarColor.Location = new System.Drawing.Point(504, 62);
            this.cbCarColor.Name = "cbCarColor";
            this.cbCarColor.Size = new System.Drawing.Size(174, 28);
            this.cbCarColor.TabIndex = 21;
            // 
            // tbCarId
            // 
            this.tbCarId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCarId.Location = new System.Drawing.Point(1059, 63);
            this.tbCarId.Name = "tbCarId";
            this.tbCarId.Size = new System.Drawing.Size(39, 27);
            this.tbCarId.TabIndex = 45;
            this.tbCarId.Visible = false;
            // 
            // lbCarId
            // 
            this.lbCarId.AutoSize = true;
            this.lbCarId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCarId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarId.Location = new System.Drawing.Point(1060, 38);
            this.lbCarId.Name = "lbCarId";
            this.lbCarId.Size = new System.Drawing.Size(62, 22);
            this.lbCarId.TabIndex = 44;
            this.lbCarId.Text = "Car Id";
            this.lbCarId.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(474, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Please Click On License Plate No, To Update or Delete A Car.";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.cbCarMake);
            this.groupBox1.Controls.Add(this.lbColor);
            this.groupBox1.Controls.Add(this.tbCarId);
            this.groupBox1.Controls.Add(this.lbCarNo);
            this.groupBox1.Controls.Add(this.lbCarId);
            this.groupBox1.Controls.Add(this.tbCarNo);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.cbCarColor);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.lbMake);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.cbCarModel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lbCarModel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 436);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1141, 179);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Car Operation";
            // 
            // ManageCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1165, 656);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gvCars);
            this.Name = "ManageCars";
            this.Text = "Manage Cars";
            this.Load += new System.EventHandler(this.ManageCars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox tbCarId;
        private System.Windows.Forms.Label lbCarId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn carNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn carModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn carColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn carMake;
    }
}