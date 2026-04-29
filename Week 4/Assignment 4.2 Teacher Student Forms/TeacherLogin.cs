namespace Assignment_4._2_Teacher_Student_Forms
{
    public partial class TeacherLogin : Form
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "Teacher" && txtPassWord.Text == "Admin")
            {
                this.Hide();
                Teacher_Form teacherForm = new Teacher_Form();
                teacherForm.FormClosed += (s,e) => this.Close(); // App kept running in the background
                teacherForm.Show(); // To ensure app closes when program ends, added form close logic.
            }
            else
            {
                MessageBox.Show("Wrong credentials.");
            }
        }

        private void TeacherLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }
    }
}
