namespace Notepad_Demo
{
    public partial class Form1 : Form
    {
        string filepath;
        public Form1()
        {
            InitializeComponent();
        }

        //tightly coupled - winform
        //mvvm - loosely coupled
        //mvc (mobile, asp.net mvc, blazor)
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filepath = string.Empty;
            txtArea.Clear();
            txtArea.Focus(); // Cursor blink on the first location
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open Text Files";
            openFile.Filter = "Text Files(*.txt)|*.txt";
            openFile.ShowDialog();
            if (openFile.FileName != string.Empty)
            {
                filepath = openFile.FileName;
                txtArea.Text = File.ReadAllText(filepath);
            }
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(filepath))
            {
                File.WriteAllText(filepath, txtArea.Text);
            }
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Save Text File";
                saveFile.Filter = "Text Files(*.txt)|*.txt";
                saveFile.ShowDialog();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    if (saveFile.FileName != string.Empty)
                    {
                        filepath = saveFile.FileName;
                        Stream stream = saveFile.OpenFile();
                        StreamWriter writer = new StreamWriter(stream);
                        writer.WriteLine(txtArea.Text);
                        writer.Close();
                        stream.Close();
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save text file";
            saveFile.Filter = "Text Files(*.txt)|*.txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FileName != string.Empty)
                {
                    filepath = saveFile.FileName;
                    Stream stream = saveFile.OpenFile();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(txtArea.Text);
                    writer.Close();
                    stream.Close();
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txtArea.SelectionFont = fontDialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtArea.SelectionColor = colorDialog.Color;
            }

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtArea.SelectedText);
            txtArea.SelectedText = string.Empty;
        }
    }
}
