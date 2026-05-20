namespace Mod3EmpSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // CRUD : create, read, update, delete
            // lblLogin.Visible = false;
        }

        private void btnSignIn_Click(object sender, EventArgs e) // Obj - what's invoking? (This case: btn click) --> Send to Event e
        {
            //Hard coding cuz we don't have it connected to a database currently
            if(txtUsername.Text == "HR" && txtPassword.Text == "Password")
            {
                MessageBox.Show("Welcome HR!"); // Welcome Message
                MainForm mainForm = new MainForm(); // Instantiate the new form that we will lead user to.
                mainForm.Show(); // Main form show up!
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid credentials.");
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }
    }
}
