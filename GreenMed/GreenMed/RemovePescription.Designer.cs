
namespace ELEE_1149_Phase_3_Assignment
{
    partial class RemovePescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemovePescription));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnRemovePescription = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblPescription = new System.Windows.Forms.Label();
            this.txtPescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 106);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(95, 13);
            this.lblName.TabIndex = 32;
            this.lblName.Text = "Patients Full Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(153, 103);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 31;
            // 
            // btnRemovePescription
            // 
            this.btnRemovePescription.BackColor = System.Drawing.Color.SlateGray;
            this.btnRemovePescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemovePescription.ForeColor = System.Drawing.Color.White;
            this.btnRemovePescription.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemovePescription.Location = new System.Drawing.Point(83, 252);
            this.btnRemovePescription.Name = "btnRemovePescription";
            this.btnRemovePescription.Size = new System.Drawing.Size(117, 55);
            this.btnRemovePescription.TabIndex = 30;
            this.btnRemovePescription.Text = "Remove Pescription";
            this.btnRemovePescription.UseVisualStyleBackColor = false;
            this.btnRemovePescription.Click += new System.EventHandler(this.btnRemovePescription_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SlateGray;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.Location = new System.Drawing.Point(83, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 55);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(241, 59);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 28;
            this.picLogo.TabStop = false;
            // 
            // lblPescription
            // 
            this.lblPescription.AutoSize = true;
            this.lblPescription.Location = new System.Drawing.Point(66, 132);
            this.lblPescription.Name = "lblPescription";
            this.lblPescription.Size = new System.Drawing.Size(59, 13);
            this.lblPescription.TabIndex = 33;
            this.lblPescription.Text = "Pescription";
            // 
            // txtPescription
            // 
            this.txtPescription.Location = new System.Drawing.Point(153, 129);
            this.txtPescription.Name = "txtPescription";
            this.txtPescription.Size = new System.Drawing.Size(100, 20);
            this.txtPescription.TabIndex = 34;
            // 
            // RemovePescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(67)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(288, 319);
            this.Controls.Add(this.txtPescription);
            this.Controls.Add(this.lblPescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnRemovePescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.picLogo);
            this.Name = "RemovePescription";
            this.Text = "RemovePescription";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnRemovePescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblPescription;
        private System.Windows.Forms.TextBox txtPescription;
    }
}