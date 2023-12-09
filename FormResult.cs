using System;
using System.Windows.Forms;

namespace ConsoleApp7
{
    
    public partial class FormResult : Form
    {
       
        public bool[] IsPlayers = new bool[4];

       
        public string[] PlayersNames = new string[4];

        public int[] PlayersPoints = new int[4];

                      
        public int TurnsWalkthrough = 0;

        
        public FormResult()
        {
            InitializeComponent();
        }

        
        private void FormResult_Load(object sender, EventArgs e)
        {
            
            int max_points = -1;
            for (int i = 0; i < 4; i++)
            {
                if (IsPlayers[i]) 
                {
                    if (PlayersPoints[i] > max_points) max_points = PlayersPoints[i];
                }
            }

             int winners = 0;
            for (int i = 0; i < 4; i++)
            {
                if (IsPlayers[i]) 
                {
                    if (PlayersPoints[i] == max_points)
                    {
                        winners++;

                    }                    
                }
            }

            if (winners > 1) label_caption.Text = "Игра окончена! Победителей несколько!"; 
            else 
            {
                for (int i = 0; i < 4; i++)
                {
                    if (IsPlayers[i]) 
                    {
                        if (PlayersPoints[i] == max_points)
                        {
                            label_caption.Text = "Игра окончена! Победил " + PlayersNames[i] + "!";
                            break; 
                        }
                    }
                }
            }

            if (IsPlayers[0]) 
            {
                label_name_player_1.Text = PlayersNames[0]; 
                label_points_player_1.Text = PlayersPoints[0].ToString(); 
            }
            else 
            {
                label_name_player_1.Text = ""; 
                label_points_player_1.Text = ""; 
            }

            if (IsPlayers[1]) 
            {
                label_name_player_2.Text = PlayersNames[1]; 
                label_points_player_2.Text = PlayersPoints[1].ToString(); 
            }
            else 
            {
                label_name_player_2.Text = ""; 
                label_points_player_2.Text = ""; 
            }

            if (IsPlayers[2]) 
            {
                label_name_player_3.Text = PlayersNames[2]; 
                label_points_player_3.Text = PlayersPoints[2].ToString(); 
            }
            else 
            {
                label_name_player_3.Text = ""; 
                label_points_player_3.Text = ""; 
            }

            if (IsPlayers[3])
            {
                label_name_player_4.Text = PlayersNames[3]; 
                label_points_player_4.Text = PlayersPoints[3].ToString(); 
            }
            else 
            {
                label_name_player_4.Text = ""; 
                label_points_player_4.Text = ""; 
            }

            
        }

        
        private void FormResult_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Owner.Owner.Show(); 
        }

       
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void button_play_Click(object sender, EventArgs e)
        {
            Hide(); 
            Owner.Owner.Show(); 
        }
    }
}
