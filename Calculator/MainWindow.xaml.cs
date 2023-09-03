using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string mathSign;
        private string number1;
        private bool flagNumber2Start;
        private double result;
        List<Button> buttons = new List<Button>();
        SolidColorBrush WhiteColor = new SolidColorBrush(Colors.White);
        SolidColorBrush BlackColor = new SolidColorBrush(Colors.Black);
        SolidColorBrush BlueColor = new SolidColorBrush(Colors.Blue);
        SolidColorBrush GreenColor = new SolidColorBrush(Colors.Green);



        public MainWindow()
        {
            InitializeComponent();
            flagNumber2Start = false;
            addButtonsToList();
        }
        private void addButtonsToList()
        {
            buttons.Add(btn1);
            buttons.Add(btn2);
            buttons.Add(btn3);
            buttons.Add(btn4);
            buttons.Add(btn5);
            buttons.Add(btn6);
            buttons.Add(btn7);
            buttons.Add(btn8);
            buttons.Add(btn9);
            buttons.Add(btn0);
        }

        private void btnNumeric_Click(object sender, RoutedEventArgs e)
        {
            if (flagNumber2Start)
            {
                flagNumber2Start = false;
                Display.Text = String.Empty;
            }
            Button button = (Button)sender;
            Display.Text += button.Content;
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            mathSign += button.Content;
            number1 = Display.Text;
            flagNumber2Start = true;
        }

        private void btnEqual_Click (object sender, RoutedEventArgs e)
         {
            double numberCalc1, numberCalc2;
            numberCalc1 = Convert.ToDouble(number1);
            numberCalc2 = Convert.ToDouble(Display.Text);
            mathematicalAction(numberCalc1, numberCalc2);
            flagNumber2Start = true;
            Display.Text = result.ToString();
        }
        private double mathematicalAction(double number1, double number2)
        {
            switch (mathSign)
            {
                case "+":
                    result = number1 + number2; break;
                case "-":
                    result = number1 - number2; break;
                case "*":
                    result = number1 * number2; break;
                case "/":
                    if(number2 != 0) { result = number1 / number2;
                    }
                    else
                    {
                        MessageBox.Show("На 0 делить нельзя");
                    }
                    break;


            }
            return result;
        }

        private void btnStyle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string btnClolor = btn.Content.ToString();
            if (btnClolor == "Black")
            {

                this.Background = BlackColor;
            }
            if(btnClolor == "Green")
            {
                this.Background = GreenColor;
            }
            if (btnClolor == "Blue")
            {
                this.Background = BlueColor;
            }
            if (btnClolor == "White")
            {
                this.Background = WhiteColor;
            }

        }
    }
}
