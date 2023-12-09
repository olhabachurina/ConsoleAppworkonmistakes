using System;
using System.Windows.Forms;

namespace ConsoleApp7
{
   
    public partial class FormSettings : Form
    {
        
        public FormSettings()
        {
            InitializeComponent();
        }

        
        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show(); 
        }

     
        private void checkBox_player_1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox_player_1.Checked) 
            {
                textBox_player_1.Enabled = true; 
               
            }
            else 
            {
                textBox_player_1.Enabled = false; 
               
            }

            CheckedPlayers(); 
        }

       
        private void checkBox_player_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player_2.Checked) 
            {
                textBox_player_2.Enabled = true;
                
            }
            else 
            {
                textBox_player_2.Enabled = false; 
               
            }

            CheckedPlayers(); 
        }

       
        private void checkBox_player_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player_3.Checked) 
            {
                textBox_player_3.Enabled = true; 
               
            }
            else 
            {
                textBox_player_3.Enabled = false; 
                
            }

            CheckedPlayers(); 
        }

        
        private void checkBox_player_4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player_4.Checked) 
            {
                textBox_player_4.Enabled = true; 

            }
            else 
            {
                textBox_player_4.Enabled = false; 


                CheckedPlayers(); 
            }
        }



        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

      
        private void button_play_Click(object sender, EventArgs e)
        {
            FormGame form_game = new FormGame(); 
            form_game.Owner = this; 

           
            if (radioButton_limit_off.Checked) form_game.PointsLimit = -1;
            else form_game.PointsLimit = Convert.ToInt32(numericUpDown_limit.Value);

           
            form_game.CreatePlayers(checkBox_player_1.Checked, textBox_player_1.Text, checkBox_player_2.Checked, textBox_player_2.Text, checkBox_player_3.Checked, textBox_player_3.Text, checkBox_player_4.Checked, textBox_player_4.Text);

            Hide(); 
            form_game.Show();
        }

       
        private void CheckedPlayers()
        {
            int checked_players = 0; 
            if (checkBox_player_1.Checked) checked_players++;
            if (checkBox_player_2.Checked) checked_players++;
            if (checkBox_player_3.Checked) checked_players++;
            if (checkBox_player_4.Checked) checked_players++;

            if (checked_players >= 2) 
            {
                button_play.Enabled = true; 
            }
            else
            {
                button_play.Enabled = false; 
            }
        }

        
    }
}
