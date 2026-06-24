using System.Diagnostics;

namespace ScoreCalculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0, totalScore = 0;
        float averageScore = 0.0f;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            if(int.TryParse(txtScoreEntry.Text, out int score))
            {
                totalScore += score;
                lblScoreTotal.Text = $"{totalScore}";
                count++;
                lblScoreCount.Text = $"{count}";
                averageScore = (float)totalScore / count;
                lblScoreAverage.Text = $"{averageScore:F2}";

            }
            else
            {
                DisplayAlert("invalid input", "Please enter a valid number", "Ok");
            }

        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            count = 0;
            totalScore = 0;
            averageScore = 0.0f;
            lblScoreTotal.Text = "0";
            lblScoreAverage.Text = "0";
            lblScoreCount.Text = "0";
            txtScoreEntry.Text = string.Empty;

        }

        private void btnExit_Clicked(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().CloseMainWindow();


        }
    }
}
