namespace Mod3EmpSystem
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
            empGrid = new DataGridView();
            btnAdd = new Button();
            btnRefresh = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)empGrid).BeginInit();
            SuspendLayout();
            // 
            // empGrid
            // 
            empGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            empGrid.Location = new Point(164, 80);
            empGrid.Name = "empGrid";
            empGrid.Size = new Size(501, 159);
            empGrid.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(164, 289);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 46);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add New Employee";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(347, 289);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(137, 46);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(528, 289);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 46);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Controls.Add(btnAdd);
            Controls.Add(empGrid);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)empGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView empGrid;
        private Button btnAdd;
        private Button btnRefresh;
        private Button btnDelete;
    }
}