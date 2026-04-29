namespace Mod3EventsDelegateDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            BankAccount obj = new BankAccount();
            obj.LowBalDel += Obj_LowBalDel; //Obj_LowBalDel Name of the event handler and signature 
            //line that connects event to the event handler thru the delegate (knows which event signature is needed).
            //You can make a list of event handlers by using this statements again.
            obj.LowBalDel += Obj_LowBalDel1;//adding one more function (event handler) in the list
            obj.AccountBalance = int.Parse(txtAccNumber.Text);
            obj.AccountBalance = double.Parse(txtAccBalanace.Text);
        }

        private void Obj_LowBalDel1(double bal)
        {
            MessageBox.Show($"This is second notification");
        }

        private void Obj_LowBalDel(double bal)
        {// How should we communicate to user? It's up to us to customize
            MessageBox.Show($"{bal} is too low, maintain at least $200");
        }
    }
}
