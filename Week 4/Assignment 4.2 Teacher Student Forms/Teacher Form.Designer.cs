namespace Assignment_4._2_Teacher_Student_Forms
{
    partial class Teacher_Form
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
            btnAdd = new Button();
            btnDelete = new Button();
            btnSaveHighest = new Button();
            studentGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)studentGrid).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(582, 85);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(132, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(582, 114);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(132, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete Student";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSaveHighest
            // 
            btnSaveHighest.Location = new Point(582, 143);
            btnSaveHighest.Name = "btnSaveHighest";
            btnSaveHighest.Size = new Size(132, 23);
            btnSaveHighest.TabIndex = 3;
            btnSaveHighest.Text = "Save Nerd Info";
            btnSaveHighest.UseVisualStyleBackColor = true;
            btnSaveHighest.Click += btnSaveHighest_Click;
            // 
            // studentGrid
            // 
            studentGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            studentGrid.Location = new Point(72, 29);
            studentGrid.Name = "studentGrid";
            studentGrid.Size = new Size(449, 242);
            studentGrid.TabIndex = 4;
            // 
            // Teacher_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(studentGrid);
            Controls.Add(btnSaveHighest);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Name = "Teacher_Form";
            Text = "Student_Form";
            Load += Teacher_Form_Load;
            ((System.ComponentModel.ISupportInitialize)studentGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Button btnDelete;
        private Button btnSaveHighest;
        private DataGridView studentGrid;
    }
}