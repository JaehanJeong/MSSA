namespace Assignment_4._2_Teacher_Student_Forms
{
    partial class TeacherLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtUserID = new TextBox();
            txtPassWord = new TextBox();
            lblUserID = new Label();
            lblPassWord = new Label();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(126, 198);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(156, 85);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(100, 23);
            txtUserID.TabIndex = 1;
            // 
            // txtPassWord
            // 
            txtPassWord.Location = new Point(156, 140);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.PasswordChar = '*';
            txtPassWord.Size = new Size(100, 23);
            txtPassWord.TabIndex = 2;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Location = new Point(82, 85);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(44, 15);
            lblUserID.TabIndex = 3;
            lblUserID.Text = "User ID";
            // 
            // lblPassWord
            // 
            lblPassWord.AutoSize = true;
            lblPassWord.Location = new Point(82, 140);
            lblPassWord.Name = "lblPassWord";
            lblPassWord.Size = new Size(57, 15);
            lblPassWord.TabIndex = 4;
            lblPassWord.Text = "Password";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(126, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(66, 15);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Login Page";
            // 
            // TeacherLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 250);
            Controls.Add(lblTitle);
            Controls.Add(lblPassWord);
            Controls.Add(lblUserID);
            Controls.Add(txtPassWord);
            Controls.Add(txtUserID);
            Controls.Add(btnLogin);
            Name = "TeacherLogin";
            Text = "Teacher Login";
            Load += TeacherLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtUserID;
        private TextBox txtPassWord;
        private Label lblUserID;
        private Label lblPassWord;
        private Label lblTitle;
    }
}
