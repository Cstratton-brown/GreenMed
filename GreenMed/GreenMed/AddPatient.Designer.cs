
namespace ELEE_1149_Phase_3_Assignment
{
    partial class AddPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPatient));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDateofBirth = new System.Windows.Forms.Label();
            this.udAge = new System.Windows.Forms.NumericUpDown();
            this.dpAge = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAge)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(241, 59);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SlateGray;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(79, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 55);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.BackColor = System.Drawing.Color.SlateGray;
            this.btnAddPatient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.ForeColor = System.Drawing.Color.White;
            this.btnAddPatient.Location = new System.Drawing.Point(79, 300);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(117, 55);
            this.btnAddPatient.TabIndex = 11;
            this.btnAddPatient.Text = "Add New Patient";
            this.btnAddPatient.UseVisualStyleBackColor = false;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(139, 109);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 20);
            this.txtName.TabIndex = 12;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(139, 161);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(125, 20);
            this.txtGender.TabIndex = 14;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 112);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 13);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Full Name";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(30, 138);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 17;
            this.lblAge.Text = "Age";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(30, 164);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 18;
            this.lblGender.Text = "Gender";
            // 
            // lblDateofBirth
            // 
            this.lblDateofBirth.AutoSize = true;
            this.lblDateofBirth.Location = new System.Drawing.Point(30, 190);
            this.lblDateofBirth.Name = "lblDateofBirth";
            this.lblDateofBirth.Size = new System.Drawing.Size(66, 13);
            this.lblDateofBirth.TabIndex = 19;
            this.lblDateofBirth.Text = "Date of Birth";
            // 
            // udAge
            // 
            this.udAge.Location = new System.Drawing.Point(139, 136);
            this.udAge.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.udAge.Name = "udAge";
            this.udAge.Size = new System.Drawing.Size(125, 20);
            this.udAge.TabIndex = 20;
            // 
            // dpAge
            // 
            this.dpAge.Location = new System.Drawing.Point(139, 190);
            this.dpAge.MaxDate = new System.DateTime(2022, 3, 10, 0, 0, 0, 0);
            this.dpAge.MinDate = new System.DateTime(1902, 1, 1, 0, 0, 0, 0);
            this.dpAge.Name = "dpAge";
            this.dpAge.Size = new System.Drawing.Size(125, 20);
            this.dpAge.TabIndex = 21;
            this.dpAge.Value = new System.DateTime(2022, 3, 10, 0, 0, 0, 0);
            // 
            // AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(67)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(276, 367);
            this.Controls.Add(this.dpAge);
            this.Controls.Add(this.udAge);
            this.Controls.Add(this.lblDateofBirth);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.picLogo);
            this.Name = "AddPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPatient";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDateofBirth;
        private System.Windows.Forms.NumericUpDown udAge;
        private System.Windows.Forms.DateTimePicker dpAge;
    }
}