namespace Assignment_4._1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Get Data from Persons list
            personGrid.DataSource = Data.Persons;

            //Making sure the information fills up the grid to make it look nice
            personGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Vertical
            personGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Horizontal
            //MessageBox.Show(Data.PersonDict.Count.ToString());
            
            //Allows user to use 'enter' to activate search
            this.AcceptButton = btnSearch;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Addform addform = new Addform();
            addform.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this person?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Version I used to use:
                // Data.Persons.RemoveAt(personGrid.CurrentRow.Index);

                // Safer industry standard so that if the list got sorted/filtered, indices don't get messed up.
                Person selectedPerson = (Person)personGrid.CurrentRow.DataBoundItem;

                string key = $"{selectedPerson.FirstName.Trim()} {selectedPerson.LastName.Trim()}";

                //Remove from dictionary
                Data.PersonDict.Remove(key);
                //Remove from list
                Data.Persons.Remove(selectedPerson);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();
            //MessageBox.Show(txtSearch.Text); Checking what is actually being searched
            if(Data.PersonDict.TryGetValue(key, out var foundPerson))
            {
                MessageBox.Show(
                    $"Name: {foundPerson.FirstName} {foundPerson.LastName}\n" +
                    $"Mobile: {foundPerson.MobilePhone}\n" +
                    $"Work: {foundPerson.WorkPhone}\n" +
                    $"Address: {foundPerson.Address}"
                    );
            }
            else
            {
                MessageBox.Show("That person isn't on this list.");
            }
        }
    }
}
