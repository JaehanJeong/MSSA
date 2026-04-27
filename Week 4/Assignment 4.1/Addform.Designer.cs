namespace Assignment_4._1
{
    partial class Addform
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
            lblFirstName = new Label();
            lblLastName = new Label();
            lblMobilePhone = new Label();
            lblWorkPhone = new Label();
            lblAddress = new Label();
            txtFName = new TextBox();
            txtLName = new TextBox();
            txtMobPhone = new TextBox();
            txtWorkPhone = new TextBox();
            txtAddress = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(60, 35);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(60, 78);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Last Name";
            // 
            // lblMobilePhone
            // 
            lblMobilePhone.AutoSize = true;
            lblMobilePhone.Location = new Point(60, 121);
            lblMobilePhone.Name = "lblMobilePhone";
            lblMobilePhone.Size = new Size(81, 15);
            lblMobilePhone.TabIndex = 2;
            lblMobilePhone.Text = "Mobile Phone";
            // 
            // lblWorkPhone
            // 
            lblWorkPhone.AutoSize = true;
            lblWorkPhone.Location = new Point(60, 160);
            lblWorkPhone.Name = "lblWorkPhone";
            lblWorkPhone.Size = new Size(72, 15);
            lblWorkPhone.TabIndex = 3;
            lblWorkPhone.Text = "Work Phone";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(60, 195);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(49, 15);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address";
            // 
            // txtFName
            // 
            txtFName.Location = new Point(177, 35);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(217, 23);
            txtFName.TabIndex = 5;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(177, 75);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(217, 23);
            txtLName.TabIndex = 6;
            // 
            // txtMobPhone
            // 
            txtMobPhone.Location = new Point(177, 121);
            txtMobPhone.Name = "txtMobPhone";
            txtMobPhone.Size = new Size(217, 23);
            txtMobPhone.TabIndex = 7;
            // 
            // txtWorkPhone
            // 
            txtWorkPhone.Location = new Point(177, 157);
            txtWorkPhone.Name = "txtWorkPhone";
            txtWorkPhone.Size = new Size(217, 23);
            txtWorkPhone.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(177, 192);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(217, 98);
            txtAddress.TabIndex = 9;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(177, 305);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // Addform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 342);
            Controls.Add(btnSubmit);
            Controls.Add(txtAddress);
            Controls.Add(txtWorkPhone);
            Controls.Add(txtMobPhone);
            Controls.Add(txtLName);
            Controls.Add(txtFName);
            Controls.Add(lblAddress);
            Controls.Add(lblWorkPhone);
            Controls.Add(lblMobilePhone);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Name = "Addform";
            Text = "Addform";
            Load += Addform_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFirstName;
        private Label lblLastName;
        private Label lblMobilePhone;
        private Label lblWorkPhone;
        private Label lblAddress;
        private TextBox txtFName;
        private TextBox txtLName;
        private TextBox txtMobPhone;
        private TextBox txtWorkPhone;
        private TextBox txtAddress;
        private Button btnSubmit;
    }
}