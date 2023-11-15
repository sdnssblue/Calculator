using System;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumner;
        private string operatorName;
        private bool isOperatorClicked;

        private void ButtonCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (LabelResult.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                LabelResult.Text = button.Text;
            }
            else
            {
                LabelResult.Text += button.Text;
            }
        }

        private void ButtonClear_Clicked(object sender, EventArgs e)
        {
            LabelResult.Text = "0";
            isOperatorClicked = false;
            firstNumner = 0;
        }

        private void ButtonX_Clicked(object sender, EventArgs e)
        {
            string number = LabelResult.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LabelResult.Text = "0";
                }
                else
                {
                    LabelResult.Text = number;
                }
            }
        }

        private void ButtonCommonOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumner = Convert.ToDecimal(LabelResult.Text);
        }

        private async void ButtonPercentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = LabelResult.Text;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    LabelResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void ButtonEqual_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(LabelResult.Text);
                string finalResult = Calculate(firstNumner, secondNumber).ToString("0.##");
                LabelResult.Text = finalResult;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operatorName == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (operatorName == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (operatorName == "/")
            {
                result = firstNumber / secondNumber;
            }
            return result;
        }

    }
}
