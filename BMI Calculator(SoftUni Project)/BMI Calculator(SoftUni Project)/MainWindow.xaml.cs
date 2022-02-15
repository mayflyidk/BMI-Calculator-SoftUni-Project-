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

namespace BMI_Calculator_SoftUni_Project_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            // Checkboxes
            MaleCheckBox.IsChecked = true;
            EUCheckBox.IsChecked = true;

            // Visibility
            HeightFeet.Visibility = Visibility.Hidden;
            HeightInches.Visibility = Visibility.Hidden;

            // Contents
            Age.Text = "25";
            
            HeightCM.Text = "180";
            Weight.Text = "65";

            HeightFeet.Text = "5";
            HeightInches.Text = "10";

            Results.Text = " ";
            Results.IsReadOnly = true;
        }

        private void FemaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (FemaleCheckBox.IsChecked == true)
            {
                MaleCheckBox.IsChecked = false;
            }
        }

        private void MaleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (MaleCheckBox.IsChecked == true)
            {
                FemaleCheckBox.IsChecked = false;
            }
        }

        private void EUCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (EUCheckBox.IsChecked == true)
            {
                USCheckBox.IsChecked = false;

                // Visible
                HeightCM.Visibility = Visibility.Visible;

                // Hidden
                HeightFeet.Visibility = Visibility.Hidden;
                HeightInches.Visibility = Visibility.Hidden;

                // Content
                Weight.Text = "65";
                WeightInLabel.Content = "in kgs";
            }
        }

        private void USCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (USCheckBox.IsChecked == true)
            {
                EUCheckBox.IsChecked = false;

                // Visible
                HeightFeet.Visibility = Visibility.Visible;
                HeightInches.Visibility = Visibility.Visible;
                
                // Hidden
                HeightCM.Visibility = Visibility.Hidden;

                // Content
                WeightInLabel.Content = "in lbs";
                Weight.Text = "160";
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // EU
            double weight = double.Parse(Weight.Text);
            double height = double.Parse(HeightCM.Text);
            int age = int.Parse(Age.Text);

            // US
            double feet = int.Parse(HeightFeet.Text);
            double inches = int.Parse(HeightInches.Text);

            if (EUCheckBox.IsChecked == true)
            {
                double result = 10000 * (weight / (height * height));

                if (age >= 21) {
                    if (result < 16)
                    {
                        Results.Text = "You have severe thinness. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/underweight.html";
                    }

                    else if (result >= 16 && result < 17)
                    {
                        Results.Text = "You have moderate thinness. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/underweight.html";
                    }

                    else if (result >= 17 && result < 18.5)
                    {
                        Results.Text = "You have mild thinness. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/underweight.html";
                    }

                    else if (result >= 18.5 && result < 25)
                    {
                        Results.Text = "You are in normal weight. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/normal.html";
                    }

                    else if (result >= 25 && result < 30)
                    {
                        Results.Text = "You are overweighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }

                    else if (result >= 30 && result < 35)
                    {
                        Results.Text = "You are in obese class I. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }

                    else if (result >= 35 && result < 40)
                    {
                        Results.Text = "You are in obese class II. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }

                    else if (result >= 40)
                    {
                        Results.Text = "You are in obese class III. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }
                }

                else if (age <=20)
                {
                    if (result < 16)
                    {
                        Results.Text = $"Your kid is underweighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/underweight.html";
                    }
                    
                    else if (result >= 16 && result <= 22.6)
                    {
                        Results.Text = $"Your kid is healthy weighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/normal-weight.html";
                    }

                    else if (result > 22.6 && result <= 26.4)
                    {
                        Results.Text = $"Your kid is at risk of overweight. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/at-risk-of-overweight.html";
                    }

                    else if (result > 26.4)
                    {
                        Results.Text = $"Your kid is overweighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/overweight.html";
                    }
                }
            }

            else if (USCheckBox.IsChecked == true)
            {
                double result = (weight * 703) / Math.Pow(((feet * 12) + inches), 2);

                if (age >= 21)
                {
                    if (result < 16)
                    {
                        Results.Text = "You have severe thinness. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/underweight.html";
                    }

                    else if (result >= 16 && result < 17)
                    {
                        Results.Text = "You have moderate thinness. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/underweight.html";
                    }

                    else if (result >= 17 && result < 18.5)
                    {
                        Results.Text = "You have mild thinness. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/underweight.html";
                    }

                    else if (result >= 18.5 && result < 25)
                    {
                        Results.Text = "You are in normal weight. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/normal.html";
                    }

                    else if (result >= 25 && result < 30)
                    {
                        Results.Text = "You are overweighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }

                    else if (result >= 30 && result < 35)
                    {
                        Results.Text = "You are in obese class I. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }

                    else if (result >= 35 && result < 40)
                    {
                        Results.Text = "You are in obese class II. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }

                    else if (result >= 40)
                    {
                        Results.Text = "You are in obese class III. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/adults/overweight.html";
                    }
                }

                else if (age <= 20)
                {
                    if (result < 16)
                    {
                        Results.Text = $"Your kid is underweighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/underweight.html";
                    }

                    else if (result >= 16 && result <= 22.6)
                    {
                        Results.Text = $"Your kid is healthy weighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/normal-weight.html";
                    }

                    else if (result > 22.6 && result <= 26.4)
                    {
                        Results.Text = $"Your kid is at risk of overweight. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/at-risk-of-overweight.html";
                    }

                    else if (result > 26.4)
                    {
                        Results.Text = $"Your kid is overweighted. Click here to see some tips : https://bmi-softuniada-project.netlify.app/html/children/overweight.html";
                    }
                }
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            MaleCheckBox.IsChecked = true;
            EUCheckBox.IsChecked = true;

            Age.Text = "25";

            HeightCM.Text = "180";
            Weight.Text = "65";

            HeightFeet.Text = "5";
            HeightInches.Text = "10";

            Results.Text = " ";
        }
    }
}
