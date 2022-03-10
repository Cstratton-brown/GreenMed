
namespace ELEE_1149_Phase_3_Assignment
{
    partial class Patients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patients));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgPatients = new System.Windows.Forms.DataGridView();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateofBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(241, 59);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.SlateGray;
            this.btnLogOut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(480, 12);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(104, 41);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SlateGray;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(370, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 41);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgPatients
            // 
            this.dgPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullName,
            this.Age,
            this.Gender,
            this.DateofBirth});
            this.dgPatients.Location = new System.Drawing.Point(12, 77);
            this.dgPatients.Name = "dgPatients";
            this.dgPatients.Size = new System.Drawing.Size(443, 361);
            this.dgPatients.TabIndex = 9;
            // 
            // fullName
            // 
            this.fullName.HeaderText = "Full Name";
            this.fullName.Name = "fullName";
            this.fullName.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // DateofBirth
            // 
            this.DateofBirth.HeaderText = "Date of Birth";
            this.DateofBirth.Name = "DateofBirth";
            this.DateofBirth.ReadOnly = true;
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.BackColor = System.Drawing.Color.SlateGray;
            this.btnAddPatient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.ForeColor = System.Drawing.Color.White;
            this.btnAddPatient.Location = new System.Drawing.Point(461, 315);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(117, 55);
            this.btnAddPatient.TabIndex = 10;
            this.btnAddPatient.Text = "Add New Patient";
            this.btnAddPatient.UseVisualStyleBackColor = false;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.SlateGray;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(461, 376);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(117, 55);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove Patient";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(67)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(596, 450);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.dgPatients);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.picLogo);
            this.Name = "Patients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patients";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateofBirth;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnRemove;
    }
}