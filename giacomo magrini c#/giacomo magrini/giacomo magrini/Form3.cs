using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace giacomo_magrini
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text =
              "Battle info:\n\n"
              + "-When the unit icon is glowing it means it is selected.\n\n"
              + "-When the arrow icon is glowing it means you selected that\n"
              + "lane as unit's spawn.\n\n"
              + "-Under the unit icon there is the spawning time.\n\n"
              + "-When the spawning time reach 0 you can spawn the unit.\n\n"
              + "-Each player has its own Score and win the game when 5 is reached.\n\n"
              + "-In order to increase your score you need to reach\n"
              + "the enemy spawn with 1 of your unit.\n\n"
              + "-At the top there is the timer.\n\n"
              + "-When the timer reach 0 the battle will result in a win or a draw.\n\n"
              + "-You win if you have more HP than the enemy.\n\n"
              + "-You draw if you have the same HP as the enemy.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();  //Show the previous form
            Hide();
        }
    }
}
