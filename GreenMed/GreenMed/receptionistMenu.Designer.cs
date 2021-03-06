
namespace ELEE_1149_Phase_3_Assignment
{
    partial class receptionistMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(receptionistMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMedication = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.bntPatients = new System.Windows.Forms.Button();
            this.btnNewAppointment = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnMedication
            // 
            this.btnMedication.BackColor = System.Drawing.Color.SlateGray;
            this.btnMedication.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedication.ForeColor = System.Drawing.Color.White;
            this.btnMedication.Location = new System.Drawing.Point(487, 21);
            this.btnMedication.Name = "btnMedication";
            this.btnMedication.Size = new System.Drawing.Size(104, 41);
            this.btnMedication.TabIndex = 1;
            this.btnMedication.Text = "Medications";
            this.btnMedication.UseVisualStyleBackColor = false;
            this.btnMedication.Click += new System.EventHandler(this.btnMedication_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.BackColor = System.Drawing.Color.SlateGray;
            this.btnAppointments.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppointments.ForeColor = System.Drawing.Color.White;
            this.btnAppointments.Location = new System.Drawing.Point(369, 21);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(112, 41);
            this.btnAppointments.TabIndex = 2;
            this.btnAppointments.Text = "Appointments";
            this.btnAppointments.UseVisualStyleBackColor = false;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // bntPatients
            // 
            this.bntPatients.BackColor = System.Drawing.Color.SlateGray;
            this.bntPatients.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntPatients.ForeColor = System.Drawing.Color.White;
            this.bntPatients.Location = new System.Drawing.Point(259, 21);
            this.bntPatients.Name = "bntPatients";
            this.bntPatients.Size = new System.Drawing.Size(104, 41);
            this.bntPatients.TabIndex = 3;
            this.bntPatients.Text = "Patients";
            this.bntPatients.UseVisualStyleBackColor = false;
            this.bntPatients.Click += new System.EventHandler(this.bntPatients_Click);
            // 
            // btnNewAppointment
            // 
            this.btnNewAppointment.BackColor = System.Drawing.Color.SlateGray;
            this.btnNewAppointment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAppointment.ForeColor = System.Drawing.Color.White;
            this.btnNewAppointment.Location = new System.Drawing.Point(104, 160);
            this.btnNewAppointment.Name = "btnNewAppointment";
            this.btnNewAppointment.Size = new System.Drawing.Size(192, 71);
            this.btnNewAppointment.TabIndex = 4;
            this.btnNewAppointment.Text = "Add New Appointment";
            this.btnNewAppointment.UseVisualStyleBackColor = false;
            this.btnNewAppointment.Click += new System.EventHandler(this.btnNewAppointment_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.SlateGray;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(369, 160);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(192, 71);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Appointment";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.SlateGray;
            this.btnLogOut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(277, 237);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(104, 41);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // receptionistMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(67)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(659, 361);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnNewAppointment);
            this.Controls.Add(this.bntPatients);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnMedication);
            this.Controls.Add(this.pictureBox1);
            this.Name = "receptionistMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.receptionistMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMedication;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button bntPatients;
        private System.Windows.Forms.Button btnNewAppointment;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnLogOut;
    }
}