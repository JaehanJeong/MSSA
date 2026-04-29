namespace Assignment_4._2_Teacher_Student_Forms
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
            lblStudentId = new Label();
            lblStudentName = new Label();
            lblGPA = new Label();
            txtStudentID = new TextBox();
            txtStudentName = new TextBox();
            txtGPA = new TextBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(116, 67);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(62, 15);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "Student ID";
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Location = new Point(116, 107);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(83, 15);
            lblStudentName.TabIndex = 1;
            lblStudentName.Text = "Student Name";
            // 
            // lblGPA
            // 
            lblGPA.AutoSize = true;
            lblGPA.Location = new Point(116, 156);
            lblGPA.Name = "lblGPA";
            lblGPA.Size = new Size(29, 15);
            lblGPA.TabIndex = 2;
            lblGPA.Text = "GPA";
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(243, 67);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(100, 23);
            txtStudentID.TabIndex = 3;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(243, 107);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(100, 23);
            txtStudentName.TabIndex = 4;
            // 
            // txtGPA
            // 
            txtGPA.Location = new Point(243, 153);
            txtGPA.Name = "txtGPA";
            txtGPA.Size = new Size(100, 23);
            txtGPA.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(183, 213);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Addform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 286);
            Controls.Add(btnAdd);
            Controls.Add(txtGPA);
            Controls.Add(txtStudentName);
            Controls.Add(txtStudentID);
            Controls.Add(lblGPA);
            Controls.Add(lblStudentName);
            Controls.Add(lblStudentId);
            Name = "Addform";
            Text = "Addform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentId;
        private Label lblStudentName;
        private Label lblGPA;
        private TextBox txtStudentID;
        private TextBox txtStudentName;
        private TextBox txtGPA;
        private Button btnAdd;
    }
}