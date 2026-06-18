namespace ClientApp
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
            dgMovies = new DataGridView();
            btnLoad = new Button();
            btnAdd = new Button();
            btnGetWeather = new Button();
            ((System.ComponentModel.ISupportInitialize)dgMovies).BeginInit();
            SuspendLayout();
            // 
            // dgMovies
            // 
            dgMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMovies.Location = new Point(194, 32);
            dgMovies.Name = "dgMovies";
            dgMovies.Size = new Size(389, 150);
            dgMovies.TabIndex = 0;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(276, 286);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(117, 29);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load Movies";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(417, 286);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Movie";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnGetWeather
            // 
            btnGetWeather.Location = new Point(355, 354);
            btnGetWeather.Name = "btnGetWeather";
            btnGetWeather.Size = new Size(92, 23);
            btnGetWeather.TabIndex = 3;
            btnGetWeather.Text = "Get Weather";
            btnGetWeather.UseVisualStyleBackColor = true;
            btnGetWeather.Click += btnGetWeather_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGetWeather);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(dgMovies);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgMovies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgMovies;
        private Button btnLoad;
        private Button btnAdd;
        private Button btnGetWeather;
    }
}
