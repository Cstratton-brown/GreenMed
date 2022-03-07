
namespace GreenMed
{
    partial class RemoveAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveAppointment));
            this.cbName = new System.Windows.Forms.ComboBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnRemoveAppointment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cbDate = new System.Windows.Forms.ComboBox();
            this.lblWith = new System.Windows.Forms.Label();
            this.cbPractitioner = new System.Windows.Forms.ComboBox();
            this.cbStart = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cbName
            // 
            this.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(162, 116);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(121, 21);
            this.cbName.TabIndex = 62;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(241, 59);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 61;
            this.picLogo.TabStop = false;
            // 
            // btnRemoveAppointment
            // 
            this.btnRemoveAppointment.BackColor = System.Drawing.Color.SlateGray;
            this.btnRemoveAppointment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAppointment.ForeColor = System.Drawing.Color.White;
            this.btnRemoveAppointment.Location = new System.Drawing.Point(115, 256);
            this.btnRemoveAppointment.Name = "btnRemoveAppointment";
            this.btnRemoveAppointment.Size = new System.Drawing.Size(117, 55);
            this.btnRemoveAppointment.TabIndex = 60;
            this.btnRemoveAppointment.Text = "Remove Appointment";
            this.btnRemoveAppointment.UseVisualStyleBackColor = false;
            this.btnRemoveAppointment.Click += new System.EventHandler(this.btnRemoveAppointment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SlateGray;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(115, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 55);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(57, 146);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(55, 13);
            this.lblStart.TabIndex = 54;
            this.lblStart.Text = "Start Time";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(57, 120);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(71, 13);
            this.lblPatient.TabIndex = 53;
            this.lblPatient.Text = "Patient Name";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(57, 94);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 52;
            this.lblDate.Text = "Date";
            // 
            // cbDate
            // 
            this.cbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Location = new System.Drawing.Point(162, 89);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(121, 21);
            this.cbDate.TabIndex = 64;
            // 
            // lblWith
            // 
            this.lblWith.AutoSize = true;
            this.lblWith.Location = new System.Drawing.Point(59, 172);
            this.lblWith.Name = "lblWith";
            this.lblWith.Size = new System.Drawing.Size(97, 13);
            this.lblWith.TabIndex = 58;
            this.lblWith.Text = "With Doctor/Nurse";
            // 
            // cbPractitioner
            // 
            this.cbPractitioner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPractitioner.FormattingEnabled = true;
            this.cbPractitioner.Location = new System.Drawing.Point(162, 170);
            this.cbPractitioner.Name = "cbPractitioner";
            this.cbPractitioner.Size = new System.Drawing.Size(121, 21);
            this.cbPractitioner.TabIndex = 63;
            // 
            // cbStart
            // 
            this.cbStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStart.FormattingEnabled = true;
            this.cbStart.Location = new System.Drawing.Point(162, 143);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(121, 21);
            this.cbStart.TabIndex = 65;
            // 
            // RemoveAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(67)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(322, 360);
            this.Controls.Add(this.cbStart);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.cbPractitioner);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnRemoveAppointment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWith);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblDate);
            this.Name = "RemoveAppointment";
            this.Text = "RemoveAppointment";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnRemoveAppointment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cbDate;
        private System.Windows.Forms.Label lblWith;
        private System.Windows.Forms.ComboBox cbPractitioner;
        private System.Windows.Forms.ComboBox cbStart;
    }
}