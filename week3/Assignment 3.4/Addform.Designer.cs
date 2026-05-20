namespace Assignment_3._4
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
            lblName = new Label();
            lblSize = new Label();
            comboSize = new ComboBox();
            btnAdd = new Button();
            comboCoffeeName = new ComboBox();
            lblMilk = new Label();
            comboMilk = new ComboBox();
            numShots = new NumericUpDown();
            lblShots = new Label();
            lblBeans = new Label();
            comboBean = new ComboBox();
            lblPriceDisplay = new Label();
            ((System.ComponentModel.ISupportInitialize)numShots).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(193, 111);
            lblName.Name = "lblName";
            lblName.Size = new Size(77, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Coffee Name";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(193, 156);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(27, 15);
            lblSize.TabIndex = 2;
            lblSize.Text = "Size";
            // 
            // comboSize
            // 
            comboSize.FormattingEnabled = true;
            comboSize.Location = new Point(295, 156);
            comboSize.Name = "comboSize";
            comboSize.Size = new Size(121, 23);
            comboSize.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(340, 378);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // comboCoffeeName
            // 
            comboCoffeeName.FormattingEnabled = true;
            comboCoffeeName.Location = new Point(295, 111);
            comboCoffeeName.Name = "comboCoffeeName";
            comboCoffeeName.Size = new Size(121, 23);
            comboCoffeeName.TabIndex = 7;
            // 
            // lblMilk
            // 
            lblMilk.AutoSize = true;
            lblMilk.Location = new Point(193, 216);
            lblMilk.Name = "lblMilk";
            lblMilk.Size = new Size(30, 15);
            lblMilk.TabIndex = 8;
            lblMilk.Text = "Milk";
            // 
            // comboMilk
            // 
            comboMilk.BackColor = SystemColors.Window;
            comboMilk.FormattingEnabled = true;
            comboMilk.Location = new Point(295, 213);
            comboMilk.Name = "comboMilk";
            comboMilk.Size = new Size(121, 23);
            comboMilk.TabIndex = 9;
            // 
            // numShots
            // 
            numShots.Location = new Point(295, 311);
            numShots.Name = "numShots";
            numShots.Size = new Size(120, 23);
            numShots.TabIndex = 10;
            // 
            // lblShots
            // 
            lblShots.AutoSize = true;
            lblShots.Location = new Point(193, 319);
            lblShots.Name = "lblShots";
            lblShots.Size = new Size(36, 15);
            lblShots.TabIndex = 11;
            lblShots.Text = "Shots";
            // 
            // lblBeans
            // 
            lblBeans.AutoSize = true;
            lblBeans.Location = new Point(193, 275);
            lblBeans.Name = "lblBeans";
            lblBeans.Size = new Size(38, 15);
            lblBeans.TabIndex = 12;
            lblBeans.Text = "Beans";
            // 
            // comboBean
            // 
            comboBean.BackColor = SystemColors.Window;
            comboBean.FormattingEnabled = true;
            comboBean.Location = new Point(295, 267);
            comboBean.Name = "comboBean";
            comboBean.Size = new Size(121, 23);
            comboBean.TabIndex = 13;
            // 
            // lblPriceDisplay
            // 
            lblPriceDisplay.AutoSize = true;
            lblPriceDisplay.Location = new Point(460, 311);
            lblPriceDisplay.Name = "lblPriceDisplay";
            lblPriceDisplay.Size = new Size(83, 15);
            lblPriceDisplay.TabIndex = 14;
            lblPriceDisplay.Text = "Dynamic Price";
            // 
            // Addform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 497);
            Controls.Add(lblPriceDisplay);
            Controls.Add(comboBean);
            Controls.Add(lblBeans);
            Controls.Add(lblShots);
            Controls.Add(numShots);
            Controls.Add(comboMilk);
            Controls.Add(lblMilk);
            Controls.Add(comboCoffeeName);
            Controls.Add(btnAdd);
            Controls.Add(comboSize);
            Controls.Add(lblSize);
            Controls.Add(lblName);
            Name = "Addform";
            Text = "Addform";
            Load += Addform_Load;
            ((System.ComponentModel.ISupportInitialize)numShots).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblSize;
        private ComboBox comboSize;
        private Button btnAdd;
        private ComboBox comboCoffeeName;
        private Label lblMilk;
        private ComboBox comboMilk;
        private NumericUpDown numShots;
        private Label lblShots;
        private Label lblBeans;
        private ComboBox comboBean;
        private Label lblPriceDisplay;
    }
}