namespace Mod3EmpSystem
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
            lblEmpId = new Label();
            lblEmpName = new Label();
            lblEmpSalaray = new Label();
            lblEmpDept = new Label();
            txtEmpId = new TextBox();
            txtName = new TextBox();
            txtSalaray = new TextBox();
            comboDept = new ComboBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Location = new Point(126, 127);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(73, 15);
            lblEmpId.TabIndex = 0;
            lblEmpId.Text = "Employee ID";
            // 
            // lblEmpName
            // 
            lblEmpName.AutoSize = true;
            lblEmpName.Location = new Point(126, 164);
            lblEmpName.Name = "lblEmpName";
            lblEmpName.Size = new Size(94, 15);
            lblEmpName.TabIndex = 1;
            lblEmpName.Text = "Employee Name";
            // 
            // lblEmpSalaray
            // 
            lblEmpSalaray.AutoSize = true;
            lblEmpSalaray.Location = new Point(126, 201);
            lblEmpSalaray.Name = "lblEmpSalaray";
            lblEmpSalaray.Size = new Size(99, 15);
            lblEmpSalaray.TabIndex = 2;
            lblEmpSalaray.Text = "Employee Salaray";
            // 
            // lblEmpDept
            // 
            lblEmpDept.AutoSize = true;
            lblEmpDept.Location = new Point(126, 273);
            lblEmpDept.Name = "lblEmpDept";
            lblEmpDept.Size = new Size(87, 15);
            lblEmpDept.TabIndex = 3;
            lblEmpDept.Text = "Employee Dept";
            // 
            // txtEmpId
            // 
            txtEmpId.Location = new Point(231, 127);
            txtEmpId.Name = "txtEmpId";
            txtEmpId.Size = new Size(100, 23);
            txtEmpId.TabIndex = 4;
            txtEmpId.Validating += txtEmpId_Validating;
            // 
            // txtName
            // 
            txtName.Location = new Point(231, 161);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 5;
            // 
            // txtSalaray
            // 
            txtSalaray.Location = new Point(231, 198);
            txtSalaray.Name = "txtSalaray";
            txtSalaray.Size = new Size(100, 23);
            txtSalaray.TabIndex = 6;
            // 
            // comboDept
            // 
            comboDept.FormattingEnabled = true;
            comboDept.Location = new Point(231, 265);
            comboDept.Name = "comboDept";
            comboDept.Size = new Size(121, 23);
            comboDept.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(200, 328);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Addform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(comboDept);
            Controls.Add(txtSalaray);
            Controls.Add(txtName);
            Controls.Add(txtEmpId);
            Controls.Add(lblEmpDept);
            Controls.Add(lblEmpSalaray);
            Controls.Add(lblEmpName);
            Controls.Add(lblEmpId);
            Name = "Addform";
            Text = "Addform";
            Load += Addform_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmpId;
        private Label lblEmpName;
        private Label lblEmpSalaray;
        private Label lblEmpDept;
        private TextBox txtEmpId;
        private TextBox txtName;
        private TextBox txtSalaray;
        private ComboBox comboDept;
        private Button btnAdd;
    }
}