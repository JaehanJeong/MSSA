namespace Assignment_3._4
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            coffeeGrid = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            lblOrderTracker = new Label();
            ((System.ComponentModel.ISupportInitialize)coffeeGrid).BeginInit();
            SuspendLayout();
            // 
            // coffeeGrid
            // 
            coffeeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            coffeeGrid.Location = new Point(46, 47);
            coffeeGrid.Name = "coffeeGrid";
            coffeeGrid.Size = new Size(805, 325);
            coffeeGrid.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(314, 404);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(419, 404);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(529, 404);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(26, 23);
            btnRefresh.TabIndex = 3;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblOrderTracker
            // 
            lblOrderTracker.AutoSize = true;
            lblOrderTracker.Location = new Point(419, 19);
            lblOrderTracker.Name = "lblOrderTracker";
            lblOrderTracker.Size = new Size(78, 15);
            lblOrderTracker.TabIndex = 4;
            lblOrderTracker.Text = "Order Tracker";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 500);
            Controls.Add(lblOrderTracker);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(coffeeGrid);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)coffeeGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView coffeeGrid;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblOrderTracker;
    }
}