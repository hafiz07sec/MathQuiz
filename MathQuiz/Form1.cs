using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        int addend1, addend2;
        int minuend, substractend;
        int multiplicand, multiplier;
        int dividend, divisor; 

        int timeleft;
        Random randomizer = new Random();
        public void StartTheQuiz()
        {
            //sum operation value
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLebel.Text = addend1.ToString();
            plusRightLevel.Text = addend2.ToString();
            sum.Value = 0;

            //substraction variable value
            minuend = randomizer.Next(1, 101);
            substractend = randomizer.Next(1, minuend);
            minusLeftLebel.Text = minuend.ToString();
            minusRightLevel.Text = substractend.ToString();
            diference.Value = 0;

            //multiplication variable value

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            mulLeftLebel.Text = multiplicand.ToString();
            mulRightLebel.Text = multiplier.ToString();
            product.Value = 0;

            //division variable value

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            divLeftLebel.Text = dividend.ToString();
            diveRightLebel.Text = divisor.ToString();
            quotient.Value = 0;

            

            timeleft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) 
                && (minuend - substractend == diference.Value)
                && (multiplicand*multiplier ==product.Value)
                && (dividend/divisor == quotient.Value))
            {
                return true;
            }
            else
                return false;
        }
        public Form1()
        {
           
            InitializeComponent();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                        "Congratulations!");
                startButton.Enabled = true;
              
            }
            else if (timeleft > 0)
            {
                timeleft = timeleft - 1;
                timeLabel.Text = timeleft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry (-_-)");

                sum.Value = addend1 + addend2;
                diference.Value = minuend - substractend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;

                startButton.Enabled = true; 
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timeLabel.BackColor = Color.Red;
        }
        
    }
}
