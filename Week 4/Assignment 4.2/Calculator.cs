using System;

namespace Assignment_4._2
{
    public partial class Calculator : Form
    {
        double? firstValue = null;
        string currentInput = "0";
        string currentOperator = null;
        bool isEnteringSecond = false;
        public Calculator()
        {
            InitializeComponent();
            txtConsole.Text = currentInput;
        }
        void OnNumberClick(string digit)
        {
            if (currentInput == "0" || isEnteringSecond)
            {
                currentInput = digit;
                isEnteringSecond = false;
            }
            else
            {
                currentInput += digit;
            }

            txtConsole.Text = currentInput;
        }
        #region NumericEntry
        // Was adding individually, but if we use event args e with obj sender, it's a lot simpler!
        //private void btn0_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("0");
        //}

        //private void btn1_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("1");
        //}

        //private void btn2_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("2");
        //}

        //private void btn3_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("3");
        //}

        //private void btn4_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("4");
        //}

        //private void btn5_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("5");
        //}

        //private void btn6_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("6");
        //}

        //private void btn7_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("7");
        //}

        //private void btn8_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("8");
        //}

        //private void btn9_Click(object sender, EventArgs e)
        //{
        //    OnNumberClick("9");
        //}

        #endregion
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OnNumberClick(btn.Text);
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                currentInput = "0.";
            }
            else if (!currentInput.Contains("."))
            {
                currentInput += ".";
                txtConsole.Text = currentInput;
            }
        }
        void OnOperatorClick(string op)
        {
            firstValue = double.Parse(currentInput);
            currentOperator = op;
            isEnteringSecond = true;

            currentInput = "0";
        }
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OnOperatorClick(btn.Text);
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            OnComputeClick();
        }
        void OnComputeClick()
        {
            double result = 0;

            if (currentOperator == null)
                return;
            double secondValue = double.Parse(currentInput);
            if (currentOperator == "÷" && secondValue == 0)
            {
                txtConsole.Text = "Error";
                ResetCalculator();
                return;
            }

            switch (currentOperator)
            {
                case "+":
                    result = firstValue.Value + secondValue;
                    break;
                case "-":
                    result = firstValue.Value - secondValue;
                    break;
                case "*":
                    result = firstValue.Value * secondValue;
                    break;
                case "÷":
                    result = firstValue.Value / secondValue;
                    break;

            }

            currentInput = result.ToString();
            txtConsole.Text = currentInput;

            firstValue = result;
            currentOperator = null;
            isEnteringSecond = false;
        }
        void ResetCalculator()
        {
            currentInput = "0";
            firstValue = null;
            currentOperator = null;
            isEnteringSecond = false;

            txtConsole.Text = currentInput;
        }

        void OnToggleSign()
        {
            if (currentInput == "0") return;
            if (currentInput.StartsWith("-"))
                currentInput = currentInput.Substring(1);
            else
                currentInput = "-" + currentInput;
            txtConsole.Text = currentInput;
        }

        private void btnChangeSign_Click(object sender, EventArgs e)
        {
            OnToggleSign();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        void OnDelete()
        {
            if (currentInput.Length <= 1)
            {
                currentInput = "0";
            }
            else
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            txtConsole.Text = currentInput;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        void OnSqrt()
        {
            double value = double.Parse(currentInput);

            if (value < 0)
            {
                txtConsole.Text = "Error";
                return;
            }
            double result = Math.Sqrt(value);

            currentInput = result.ToString();
            txtConsole.Text = currentInput;

            firstValue = result;
            currentOperator = null;
            isEnteringSecond = false;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            OnSqrt();
        }
    }
}
