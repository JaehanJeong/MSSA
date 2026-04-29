namespace Assignment_4._2
{
    partial class Calculator
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
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btn0 = new Button();
            btnAdd = new Button();
            btnSubtract = new Button();
            btnMultiply = new Button();
            btnDivide = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSqrt = new Button();
            btnChangeSign = new Button();
            btnCompute = new Button();
            btnDecimal = new Button();
            txtConsole = new TextBox();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Location = new Point(23, 135);
            btn1.Name = "btn1";
            btn1.Size = new Size(75, 23);
            btn1.TabIndex = 0;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += NumberButton_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(104, 135);
            btn2.Name = "btn2";
            btn2.Size = new Size(75, 23);
            btn2.TabIndex = 1;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += NumberButton_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(185, 135);
            btn3.Name = "btn3";
            btn3.Size = new Size(75, 23);
            btn3.TabIndex = 2;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += NumberButton_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(23, 164);
            btn4.Name = "btn4";
            btn4.Size = new Size(75, 23);
            btn4.TabIndex = 3;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += NumberButton_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(104, 164);
            btn5.Name = "btn5";
            btn5.Size = new Size(75, 23);
            btn5.TabIndex = 4;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += NumberButton_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(185, 164);
            btn6.Name = "btn6";
            btn6.Size = new Size(75, 23);
            btn6.TabIndex = 5;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += NumberButton_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(23, 193);
            btn7.Name = "btn7";
            btn7.Size = new Size(75, 23);
            btn7.TabIndex = 6;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += NumberButton_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(104, 193);
            btn8.Name = "btn8";
            btn8.Size = new Size(75, 23);
            btn8.TabIndex = 7;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += NumberButton_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(185, 193);
            btn9.Name = "btn9";
            btn9.Size = new Size(75, 23);
            btn9.TabIndex = 8;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += NumberButton_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(104, 222);
            btn0.Name = "btn0";
            btn0.Size = new Size(75, 23);
            btn0.TabIndex = 9;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += NumberButton_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(266, 106);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += OperatorButton_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.Location = new Point(266, 135);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(75, 23);
            btnSubtract.TabIndex = 11;
            btnSubtract.Text = "-";
            btnSubtract.UseVisualStyleBackColor = true;
            btnSubtract.Click += OperatorButton_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(266, 193);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(75, 23);
            btnMultiply.TabIndex = 12;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += OperatorButton_Click;
            // 
            // btnDivide
            // 
            btnDivide.Location = new Point(266, 164);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(75, 23);
            btnDivide.TabIndex = 13;
            btnDivide.Text = "÷";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += OperatorButton_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(104, 106);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Del";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(23, 106);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 15;
            btnClear.Text = "A/C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSqrt
            // 
            btnSqrt.Location = new Point(185, 106);
            btnSqrt.Name = "btnSqrt";
            btnSqrt.Size = new Size(75, 23);
            btnSqrt.TabIndex = 16;
            btnSqrt.Text = "√";
            btnSqrt.UseVisualStyleBackColor = true;
            btnSqrt.Click += btnSqrt_Click;
            // 
            // btnChangeSign
            // 
            btnChangeSign.Location = new Point(23, 222);
            btnChangeSign.Name = "btnChangeSign";
            btnChangeSign.Size = new Size(75, 23);
            btnChangeSign.TabIndex = 17;
            btnChangeSign.Text = "±";
            btnChangeSign.UseVisualStyleBackColor = true;
            btnChangeSign.Click += btnChangeSign_Click;
            // 
            // btnCompute
            // 
            btnCompute.Location = new Point(266, 222);
            btnCompute.Name = "btnCompute";
            btnCompute.Size = new Size(75, 23);
            btnCompute.TabIndex = 18;
            btnCompute.Text = "=";
            btnCompute.UseVisualStyleBackColor = true;
            btnCompute.Click += btnCompute_Click;
            // 
            // btnDecimal
            // 
            btnDecimal.Location = new Point(185, 222);
            btnDecimal.Name = "btnDecimal";
            btnDecimal.Size = new Size(75, 23);
            btnDecimal.TabIndex = 19;
            btnDecimal.Text = ".";
            btnDecimal.UseVisualStyleBackColor = true;
            btnDecimal.Click += btnDecimal_Click;
            // 
            // txtConsole
            // 
            txtConsole.Location = new Point(23, 23);
            txtConsole.Multiline = true;
            txtConsole.Name = "txtConsole";
            txtConsole.Size = new Size(318, 52);
            txtConsole.TabIndex = 20;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 264);
            Controls.Add(txtConsole);
            Controls.Add(btnDecimal);
            Controls.Add(btnCompute);
            Controls.Add(btnChangeSign);
            Controls.Add(btnSqrt);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnDivide);
            Controls.Add(btnMultiply);
            Controls.Add(btnSubtract);
            Controls.Add(btnAdd);
            Controls.Add(btn0);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Name = "Calculator";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn0;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnMultiply;
        private Button btnDivide;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSqrt;
        private Button btnChangeSign;
        private Button btnCompute;
        private Button btnDecimal;
        private TextBox txtConsole;
    }
}
