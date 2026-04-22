namespace Assignment_3._3_Student_Management
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
            lblStudId = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblAddress = new Label();
            comboMonth = new ComboBox();
            lblMonth = new Label();
            lblGrade = new Label();
            btnAdd = new Button();
            txtStudId = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtAddress = new TextBox();
            txtGrade = new TextBox();
            SuspendLayout();
            // 
            // lblStudId
            // 
            lblStudId.AutoSize = true;
            lblStudId.Location = new Point(309, 111);
            lblStudId.Name = "lblStudId";
            lblStudId.Size = new Size(62, 15);
            lblStudId.TabIndex = 0;
            lblStudId.Text = "Student ID";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(309, 144);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(309, 178);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(309, 208);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(49, 15);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "Address";
            // 
            // comboMonth
            // 
            comboMonth.FormattingEnabled = true;
            comboMonth.Location = new Point(431, 238);
            comboMonth.Name = "comboMonth";
            comboMonth.Size = new Size(121, 23);
            comboMonth.TabIndex = 4;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(309, 238);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(116, 15);
            lblMonth.TabIndex = 5;
            lblMonth.Text = "Month of Admission";
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(309, 277);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(38, 15);
            lblGrade.TabIndex = 6;
            lblGrade.Text = "Grade";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(359, 319);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtStudId
            // 
            txtStudId.Location = new Point(431, 111);
            txtStudId.Name = "txtStudId";
            txtStudId.Size = new Size(100, 23);
            txtStudId.TabIndex = 8;
            txtStudId.Validating += txtStudId_Validating;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(431, 144);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 9;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(431, 173);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 10;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(431, 208);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 11;
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(431, 277);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(100, 23);
            txtGrade.TabIndex = 12;
            // 
            // Addform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtGrade);
            Controls.Add(txtAddress);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtStudId);
            Controls.Add(btnAdd);
            Controls.Add(lblGrade);
            Controls.Add(lblMonth);
            Controls.Add(comboMonth);
            Controls.Add(lblAddress);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblStudId);
            Name = "Addform";
            Text = "Addform";
            Load += Addform_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudId;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblAddress;
        private ComboBox comboMonth;
        private Label lblMonth;
        private Label lblGrade;
        private Button btnAdd;
        private TextBox txtStudId;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtAddress;
        private TextBox txtGrade;
    }
}