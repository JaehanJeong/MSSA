namespace Mod3EventsDelegateDemo
{
    partial class Form1
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
            btnCreate = new Button();
            label1 = new Label();
            label2 = new Label();
            txtAccNumber = new TextBox();
            txtAccBalanace = new TextBox();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(291, 286);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(107, 42);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create Account";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(154, 128);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 1;
            label1.Text = "Account Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(154, 190);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 2;
            label2.Text = "Account Balance";
            // 
            // txtAccNumber
            // 
            txtAccNumber.Location = new Point(291, 128);
            txtAccNumber.Name = "txtAccNumber";
            txtAccNumber.Size = new Size(100, 23);
            txtAccNumber.TabIndex = 3;
            // 
            // txtAccBalanace
            // 
            txtAccBalanace.Location = new Point(291, 187);
            txtAccBalanace.Name = "txtAccBalanace";
            txtAccBalanace.Size = new Size(100, 23);
            txtAccBalanace.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtAccBalanace);
            Controls.Add(txtAccNumber);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCreate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreate;
        private Label label1;
        private Label label2;
        private TextBox txtAccNumber;
        private TextBox txtAccBalanace;
    }
}
