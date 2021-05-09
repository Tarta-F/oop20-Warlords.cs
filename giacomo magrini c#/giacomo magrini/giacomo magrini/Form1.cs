using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giacomo_magrini
{
    public partial class Form1 : Form
    {
        private Form2 fr2;
        private Form3 fr3;
        private Form4 fr4;


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

  
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Do you want to quit the game?", "Confirm", MessageBoxButtons.YesNo);
            if (choice == DialogResult.Yes)
            { 
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (fr2 == null)
            {
                fr2 = new Form2();
                fr2.FormClosed += Fr2_FormClosed;
            }
            fr2.Show(this);
            Hide();
        }

        private void Fr2_FormClosed(object sender, FormClosedEventArgs e)
        {
            fr2 = null;
            Show();
        }
        private void Button4_Click(object sender, EventArgs e)
        {

            if (Program.musicOnOff)
            {

                Program.splayer.Stop();
                Program.musicOnOff = false;
                

            }
            else
            {
                
                Program.splayer.PlayLooping();
                Program.musicOnOff = true;
               
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (fr3 == null)
            {
                fr3 = new Form3();
                fr3.FormClosed += Fr3_FormClosed;
            }
            fr3.Show(this);
            Hide();
        }
        void Fr3_FormClosed(object sender, FormClosedEventArgs e)
        {
            fr3 = null;
            Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (fr4 == null)
            {
                fr4 = new Form4();
                fr4.FormClosed += Fr4_FormClosed;
            }
            fr4.Show(this);
            Hide();
        }
        private void Fr4_FormClosed(object sender, FormClosedEventArgs e)
        {
            fr4 = null;
            Show();
        }
    }


    
}

