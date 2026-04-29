namespace Assignment_4._2_Teacher_Student_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "Teacher" && txtPassWord.Text == "Admin")
            {
                Student_Form studentForm = new Student_Form();
                studentForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong credentials.");
            }
        }
    }
}
