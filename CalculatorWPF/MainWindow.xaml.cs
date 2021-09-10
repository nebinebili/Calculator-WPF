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

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool TrueFalse { get; set; }
        int count_command, count_add, count_negative, count_multi, count_divide, count_minus,count_sqrt = 0;
        private double _Result { get; set; }
        private double Resultcopy { get; set; }
        private double X { get; set; }
        private string Symbol { get; set; }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtB_result.Text=="Invalid input")
            {
                btn_divide.IsEnabled = true;
                btn_minus.IsEnabled = true;
                btn_multi.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_operation.IsEnabled = true;
                btn_comman.IsEnabled = true;
                btn_negative.IsEnabled = true;
                btn_doublemulti.IsEnabled = true;
                btn_fraction.IsEnabled = true;
            }

            if (TrueFalse)
            {
                txtB_result.Text = null;
            }
            if (sender is Button btn)
            {
                if (txtB_result.Text == "0" || txtB_result.Text=="-0") txtB_result.Text = btn.Content.ToString();
                else 
                {
                    txtB_result.Text += btn.Content;
                }
            }
            if (TrueFalse) X = Convert.ToDouble(txtB_result.Text);
            TrueFalse = false;
        }

        
        private void btn_comman_Click(object sender, RoutedEventArgs e)
        {
            if (count_command == 0)
            {
                txtB_result.Text += ".";
                ++count_command;
            }
        }

        private void btn_removeall_Click(object sender, RoutedEventArgs e)
        {
            if (txtB_result.Text == "Invalid input")
            {
                btn_divide.IsEnabled = true;
                btn_minus.IsEnabled = true;
                btn_multi.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_operation.IsEnabled = true;
                btn_comman.IsEnabled = true;
                btn_negative.IsEnabled = true;
                btn_doublemulti.IsEnabled = true;
                btn_fraction.IsEnabled = true;
            }
            txtB_result.Text = null;
            count_command = 0;
            count_negative = 0;
        }

        private void btn_deleteone_Click(object sender, RoutedEventArgs e)
        {
            if (txtB_result.Text.Length == 1)
            {
                txtB_result.Text = "0";
            }
            else
            {
                txtB_result.Text = txtB_result.Text.Remove(txtB_result.Text.Length - 1, 1);

                if (txtB_result.Text[txtB_result.Text.Length - 1] == '.')
                {
                    txtB_result.Text = txtB_result.Text.Remove(txtB_result.Text.Length - 1, 1);
                    count_command = 0;

                }
                if (txtB_result.Text[txtB_result.Text.Length - 1] == '-')
                {
                    txtB_result.Text = txtB_result.Text.Remove(txtB_result.Text.Length - 1, 1);
                    count_negative = 0;
                }

            }

        }

        private void btn_negative_Click(object sender, RoutedEventArgs e)
        {
            if (count_negative == 0)
            {
                txtB_result.Text = txtB_result.Text.Insert(0, "-");
                ++count_negative;
            }
            else if (count_negative == 1)
            {
                txtB_result.Text = txtB_result.Text.Remove(0, 1);
                count_negative = 0;
            }
        }


        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn)
            {
                if (btn.Content.ToString() == "+")
                {
                    Resultcopy = Convert.ToDouble(txtB_result.Text);
                    Symbol = "+";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_add = 0;
                }
                else if (btn.Content.ToString() == "-")
                {
                    Resultcopy = Convert.ToDouble(txtB_result.Text);
                    Symbol = "-";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_minus = 0;
                }
                else if (btn.Content.ToString() == "x")
                {
                    Resultcopy = Convert.ToDouble(txtB_result.Text);
                    Symbol = "x";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_multi = 0;
                    
                }
                else if (btn.Content.ToString() == "÷")
                {
                    Resultcopy = Convert.ToDouble(txtB_result.Text);
                    Symbol = "÷";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_divide = 0;
                }
                else if (btn.Content.ToString() == "x²")
                {
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    Resultcopy = Convert.ToDouble(txtB_result.Text);

                    txtB_result.Text = (Resultcopy * Resultcopy).ToString();
                }
                else if(btn.Content.ToString()== "√х")
                {
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;

                    Resultcopy = Convert.ToDouble(txtB_result.Text);

                    if (Resultcopy > 0)
                    {
                     txtB_result.Text = Math.Sqrt(Resultcopy).ToString();

                    }
                    else if (Resultcopy < 0)
                    {
                        txtB_result.Text = "Invalid input";
                        btn_divide.IsEnabled = false;
                        btn_minus.IsEnabled = false;
                        btn_multi.IsEnabled = false;
                        btn_sqrt.IsEnabled = false;
                        btn_operation.IsEnabled = false;
                        btn_comman.IsEnabled = false;
                        btn_negative.IsEnabled = false;
                        btn_doublemulti.IsEnabled = false;
                        btn_fraction.IsEnabled = false;
                    }
                    
                }

            }
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            if (txtB_result.Text == "Invalid input")
            {
                btn_divide.IsEnabled = true;
                btn_minus.IsEnabled = true;
                btn_multi.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_operation.IsEnabled = true;
                btn_comman.IsEnabled = true;
                btn_negative.IsEnabled = true;
                btn_doublemulti.IsEnabled = true;
                btn_fraction.IsEnabled = true;
                txtB_result.Text = "0";
            }
            ++count_add;
            ++count_minus;
            ++count_multi;
            ++count_divide;
            ++count_sqrt;

            _Result = Convert.ToDouble(txtB_result.Text);

            

            if (Symbol == "+")
            {
                if (count_add == 1)
                {
                    txtB_result.Text = (Resultcopy + _Result).ToString();
                }
                else if (count_add != 1)
                {
                    txtB_result.Text = (X + _Result).ToString();
                }

            }
            else if (Symbol == "-")
            {
                if (count_minus == 1)
                {
                    txtB_result.Text = (Resultcopy - _Result).ToString();
                }
                else if (count_minus != 1)
                {
                    txtB_result.Text = (_Result - X).ToString();
                }

            }
            else if (Symbol == "x")
            {
                if (count_multi == 1)
                {
                    txtB_result.Text = (Resultcopy * _Result).ToString();
                }
                else if (count_multi != 1)
                {
                    txtB_result.Text = (X * _Result).ToString();
                }

            }
            //else if (Symbol == "√х")
            //{
            //    if (count_multi == 1)
            //    {
            //        txtB_result.Text = (Math.Sqrt(_Result)).ToString();
            //    }
            //    else if (count_multi != 1)
            //    {
            //        txtB_result.Text = (X * _Result).ToString();
            //    }

            //}
            else if (Symbol == "÷")
            {
                if (count_divide == 1)
                {
                    if (_Result == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else txtB_result.Text = (Resultcopy / _Result).ToString();
                }
                else if (count_divide != 1)
                {
                    if (X == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else txtB_result.Text = (_Result / X).ToString();
                }
                
            }
        }


    }
}
