using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace giacomo_magrini
{
    public partial class Form2 : Form
    {
        private const string scenario1 = "FOREST";
        private const string scenario2 = "SAND";
        private const string scenario3 = "FIRE";
        private const int lane1 = 1;
        private const int lane2 = 2;
        private const int lane3 = 5;
        private const int timer1 = 1;
        private const int timer2 = 3;
        private const int timer3 = 5;


        String firstOption;
        String secondOption;
        String thirdOption;

        public Form2()
        {


            this.firstOption = "SELECTED SCENARIO " + scenario1;
            this.secondOption = "\n SELECTED LANES: " + lane1;
            this.thirdOption = "\n SELECTED TIMER: " + timer1 + " MIN";

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label6.Text = firstOption + secondOption + thirdOption;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.firstOption = "SELECTED SCENARIO " + scenario1;
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Owner.Show();  //Show the previous form
            Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.firstOption = "SELECTED SCENARIO " + scenario2;
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.firstOption = "SELECTED SCENARIO " + scenario3;
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.secondOption = "\n SELECTED LANES: " + lane1;
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.secondOption = "\n SELECTED LANES: " + lane2;
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.secondOption = "\n SELECTED LANES: " + lane3;
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.thirdOption = "\n SELECTED TIMER: " + timer1 + " MIN";
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.thirdOption = "\n SELECTED TIMER: " + timer2 + " MIN";
            label6.Text = firstOption + secondOption + thirdOption;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.thirdOption = "\n SELECTED TIMER: " + timer3 + " MIN";
            label6.Text = firstOption + secondOption + thirdOption;
        }
    }
}
