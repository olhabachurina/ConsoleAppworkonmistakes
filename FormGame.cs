using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp7
{
   
    public partial class FormGame : Form
    {
        
        private const int number_cells_in_line = 15;

       
        private const int cell_length = 40;
        private const int margin_between_cells = 2;

      
        private Rectangle m_board_rectangle;

        
        private List<Cell> m_cells;

        
        private Cell[,] m_map_cells = new Cell[number_cells_in_line, number_cells_in_line];

       
        public int PointsLimit = -1;

      
        private Player[] m_players = new Player[4];

       
        private int m_seconds_walkthrough;

        
        private int m_total_moving_player_id;

        
        private Random m_random = new Random();

        
        private int m_id_total_clicked_cell = -1;

        
        private bool m_was_first_word = false;

      
        private int m_total_turn;

      
        public FormGame()
        {
            InitializeComponent();
        }

       
        private void FormGame_Load(object sender, EventArgs e)
        {
            m_cells = new List<Cell>(); 

            
            m_board_rectangle = new Rectangle(214, 110, cell_length * number_cells_in_line + margin_between_cells * (number_cells_in_line + 1), cell_length * number_cells_in_line + margin_between_cells * (number_cells_in_line + 1));

           
            for (int y = 0; y < number_cells_in_line; y++)
            {
                for (int x = 0; x < number_cells_in_line; x++)
                {
                    m_map_cells[y, x] = new Cell(CellType.White);
                    m_map_cells[y, x].Rectangle = new Rectangle(m_board_rectangle.X + margin_between_cells + (cell_length + margin_between_cells) * x, m_board_rectangle.Y + margin_between_cells + (cell_length + margin_between_cells) * y, cell_length, cell_length);
                    m_cells.Add(m_map_cells[y, x]);
                }
            }

            
            GroupBox[] group_boxes = new GroupBox[4];
            group_boxes[0] = groupBox_player_1;
            group_boxes[1] = groupBox_player_2;
            group_boxes[2] = groupBox_player_3;
            group_boxes[3] = groupBox_player_4;

            for (int i = 0; i < 4; i++) 
            {
                if (m_players[i] != null) 
                {
                    group_boxes[i].Enabled = true; 
                    group_boxes[i].Visible = true; 

                    group_boxes[i].Text = m_players[i].Name; 

                    for (int x = 0; x < 4; x++) 
                    {
                        m_players[i].Cells[x] = new Cell(CellType.White); 
                        m_players[i].Cells[x].Rectangle = new Rectangle(group_boxes[i].Location.X + 5 + (cell_length + margin_between_cells) * x, group_boxes[i].Location.Y + group_boxes[i].Height + margin_between_cells, cell_length, cell_length); // перемещаем ячейку
                        m_cells.Add(m_players[i].Cells[x]); 
                    }
                    for (int x = 0; x < 3; x++) 
                    {
                        m_players[i].Cells[x + 4] = new Cell(CellType.White); 
                        m_players[i].Cells[x + 4].Rectangle = new Rectangle(group_boxes[i].Location.X + 5 + (cell_length + margin_between_cells) / 2 + (cell_length + margin_between_cells) * x, group_boxes[i].Location.Y + group_boxes[i].Height + margin_between_cells + cell_length + margin_between_cells, cell_length, cell_length); // перемещаем ячейку
                        m_cells.Add(m_players[i].Cells[x + 4]); 
                    }
                }
                else 
                {
                    group_boxes[i].Enabled = false; 
                    group_boxes[i].Visible = false; 
                }
            }

           
            m_map_cells[7, 7].CellType = CellType.Gray;

            
            m_map_cells[0, 3].CellType = m_map_cells[0, 11].CellType =
            m_map_cells[2, 6].CellType = m_map_cells[2, 8].CellType =
            m_map_cells[3, 0].CellType = m_map_cells[3, 7].CellType = m_map_cells[3, 14].CellType =
            m_map_cells[6, 2].CellType = m_map_cells[6, 6].CellType = m_map_cells[6, 8].CellType = m_map_cells[6, 12].CellType =
            m_map_cells[7, 3].CellType = m_map_cells[7, 11].CellType =
            m_map_cells[8, 2].CellType = m_map_cells[8, 6].CellType = m_map_cells[8, 8].CellType = m_map_cells[8, 12].CellType =
            m_map_cells[11, 0].CellType = m_map_cells[11, 7].CellType = m_map_cells[3, 14].CellType =
            m_map_cells[12, 6].CellType = m_map_cells[12, 8].CellType =
            m_map_cells[14, 3].CellType = m_map_cells[14, 11].CellType = CellType.Green;

           
            m_map_cells[1, 1].CellType = m_map_cells[1, 13].CellType =
            m_map_cells[2, 2].CellType = m_map_cells[2, 12].CellType =
            m_map_cells[3, 3].CellType = m_map_cells[3, 11].CellType =
            m_map_cells[4, 4].CellType = m_map_cells[4, 10].CellType =
            m_map_cells[10, 4].CellType = m_map_cells[10, 10].CellType =
            m_map_cells[11, 3].CellType = m_map_cells[11, 11].CellType =
            m_map_cells[12, 2].CellType = m_map_cells[12, 12].CellType =
            m_map_cells[13, 1].CellType = m_map_cells[13, 13].CellType = CellType.Blue;

            
            m_map_cells[1, 5].CellType = m_map_cells[1, 9].CellType =
            m_map_cells[5, 1].CellType = m_map_cells[5, 13].CellType =
            m_map_cells[9, 1].CellType = m_map_cells[9, 13].CellType =
            m_map_cells[13, 5].CellType = m_map_cells[13, 9].CellType = CellType.Yellow;

          
            m_map_cells[0, 0].CellType = m_map_cells[0, 7].CellType = m_map_cells[0, 14].CellType =
            m_map_cells[7, 0].CellType = m_map_cells[7, 14].CellType =
            m_map_cells[14, 0].CellType = m_map_cells[14, 7].CellType = m_map_cells[14, 14].CellType = CellType.Red;

            m_seconds_walkthrough = 0; 

            label_limit.Text = "Лимит очков: ";
            if (PointsLimit == -1) label_limit.Text += "отсутствует";
            else label_limit.Text += PointsLimit;

            m_total_moving_player_id = -1; 
            NextPlayerMove(); 
            update_timer.Start(); 

            m_was_first_word = false; 

            m_total_turn = 1;
        }

        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            game_timer.Stop(); 
            update_timer.Stop(); 

            FormResult form_result = new FormResult(); 
            form_result.Owner = this; 
            Hide(); 

            
            for (int i = 0; i < 4; i++)
            {
                form_result.IsPlayers[i] = !(m_players[i] is null); 
                if (form_result.IsPlayers[i]) 
                {
                    form_result.PlayersNames[i] = m_players[i].Name; 
                    form_result.PlayersPoints[i] = m_players[i].Points; 
                }
            }
           
            form_result.TurnsWalkthrough = m_total_turn;

            form_result.ShowDialog(); 
        }

       
        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            bool is_cursor = false; 

            DrawRectagle(e, m_board_rectangle, Brushes.Black); 

            Brush brush = Brushes.White; 
            for (int i = 0; i < m_cells.Count; i++) 
            {
                bool is_total_moving_player_cell = false; 
                for (int i2 = 0; i2 < 7; i2++) 
                {
                    if (m_cells[i] == m_players[m_total_moving_player_id].Cells[i2]) 
                    {
                        is_total_moving_player_cell = true; 
                        break; 
                    }
                }
                if (i < 225) is_total_moving_player_cell = true; 

                if (m_cells[i].Letter == null) 
                {
                    string text = "";
                    if (m_cells[i].CellType == CellType.White) 
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) 
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; 
                        }
                        else brush = Brushes.White;
                    }
                    else if (m_cells[i].CellType == CellType.Gray) 
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) 
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; 
                        }
                        else brush = Brushes.LightGray;
                    }
                    else if (m_cells[i].CellType == CellType.Green) 
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) 
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; 
                        }
                        else brush = Brushes.LightGreen;
                        text = "x2";
                    }
                    else if (m_cells[i].CellType == CellType.Blue) 
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) 
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; 
                        }
                        else brush = Brushes.Aqua;
                        text = "All\nx2";
                    }
                    else if (m_cells[i].CellType == CellType.Yellow) 
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) 
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; 
                        }
                        else brush = Brushes.Yellow;
                        text = "x3";
                    }
                    else if (m_cells[i].CellType == CellType.Red) 
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) 
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; 
                        }
                        else brush = Brushes.Pink;
                        text = "All\nx3";
                    }

                    if (i == m_id_total_clicked_cell) brush = Brushes.Green; 

                    DrawRectagle(e, m_cells[i].Rectangle, Brushes.Black, brush, 1); 
                    DrawText(e, m_cells[i].Rectangle, Brushes.Black, text, 0.25); 
                }
                else 
                {
                    string text = "" + m_cells[i].Letter.Symbol; 

                    brush = Brushes.LightYellow;
                    Brush brush2 = Brushes.Orange; 

                    if (is_total_moving_player_cell) 
                    {
                        if (m_cells[i].IsEntered) 
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; 
                        }
                        else 
                        {
                            brush = Brushes.Orange;
                        }
                        brush2 = Brushes.Brown;
                    }

                    if (i == m_id_total_clicked_cell) brush = Brushes.Green; 

                    DrawRectagle(e, m_cells[i].Rectangle, brush2, brush, margin_between_cells); 

                    DrawText(e, m_cells[i].Rectangle, Brushes.Black, text, 0.4); 

                    text = "" + m_cells[i].Letter.Points; 
                    Rectangle letter_points_rectangle = new Rectangle(m_cells[i].Letter.Rectangle.X + cell_length / 2 + margin_between_cells, m_cells[i].Letter.Rectangle.Y + cell_length / 2 + margin_between_cells, cell_length / 2, cell_length / 2); // баллы буквы (отображаются справа снизу ячейки)
                    DrawText(e, letter_points_rectangle, Brushes.Black, text, 0.35); 
                }
            }

            if (is_cursor) 
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

       
        private void FormGame_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_cells.Count; i++) 
            {
                if (m_cells[i].Rectangle.Contains(e.Location)) 
                {
                    bool is_total_moving_player_cell = false; 
                    for (int i2 = 0; i2 < 7; i2++) 
                    {
                        if (m_cells[i] == m_players[m_total_moving_player_id].Cells[i2]) // если ячейка игрока совпадает с текущей, значит она доступна игроку
                        {
                            is_total_moving_player_cell = true; // ячейка доступна игроку
                            break; // выходим из цикла
                        }
                    }
                    if (i < 225) is_total_moving_player_cell = true; // все ячейки поля доступны игроку

                    if (!is_total_moving_player_cell) // если ячейка недоступна игроку
                    {
                        m_cells[i].IsEntered = false;
                        continue; 
                    }

                    if (m_id_total_clicked_cell != -1) // если уже выбрана ячейка с буквой
                    {
                        if (m_cells[i].Letter == null) // если в ячейке нет буквы
                        {
                            m_cells[i].IsEntered = true;
                            continue;
                        }
                        else // если в ячейке есть буква
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed) // если эту букву поставил игрок на этом ходу
                            {
                                m_cells[i].IsEntered = true;
                                continue;
                            }
                        }
                    }
                    else // если не выбрана ячейка
                    {
                        if (m_cells[i].Letter != null) // если в ячейке есть буква
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed) // если эту букву поставил игрок на этом ходу
                            {
                                m_cells[i].IsEntered = true;
                                continue;
                            }
                        }
                    }
                    m_cells[i].IsEntered = false;
                }
                else 
                {
                    m_cells[i].IsEntered = false;
                }
            }

        }

      
        private void FormGame_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_cells.Count; i++) 
            {
                if (m_cells[i].Rectangle.Contains(e.Location)) 
                {
                    bool is_total_moving_player_cell = false; 
                    for (int i2 = 0; i2 < 7; i2++)
                    {
                        if (m_cells[i] == m_players[m_total_moving_player_id].Cells[i2]) 
                        {
                            is_total_moving_player_cell = true; 
                            break; 
                        }
                    }
                    if (i < 225) is_total_moving_player_cell = true; 

                    if (!is_total_moving_player_cell) 
                    {
                        m_cells[i].IsEntered = false;
                        continue; 
                    }

                    if (m_id_total_clicked_cell != -1) 
                    {
                        if (m_cells[i].Letter == null) 
                        {
                            
                            m_cells[i].Letter = m_cells[m_id_total_clicked_cell].Letter; 
                            m_cells[m_id_total_clicked_cell].Letter = null; 
                            m_id_total_clicked_cell = -1; 
                            if (i < 225) m_cells[i].Letter.LetterType = LetterType.Board; 
                            else m_cells[i].Letter.LetterType = LetterType.Player; 
                        }
                        else 
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed) 
                            {
                                if (m_id_total_clicked_cell == i) m_id_total_clicked_cell = -1; 
                                else m_id_total_clicked_cell = i; 
                            }
                        }
                    }
                    else 
                    {
                        if (m_cells[i].Letter != null) 
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed)
                            {
                                m_id_total_clicked_cell = i;
                            }
                        }
                    }
                }
            }
        }

      
        private void button_apply_Click(object sender, EventArgs e)
        {
            bool is_error = false; 

            bool was_direction_checked = false; 
            bool is_direction_horizontal = true; 
            int first_finded_letter_cell_id = -1; 
            bool is_any_border_letter_near_fixed_letter = false; 
            for (int i = 0; i < 225; i++)
            {
                if (m_cells[i].Letter != null) 
                {
                    
                    if (i % 15 != 14 && i < 210)
                    {
                        if (m_cells[i + 1].Letter != null && m_cells[i + 15].Letter != null && m_cells[i + 16].Letter != null)
                        {
                            MessageBox.Show("Недопустимое расположение букв!\nЧетыре буквы не могут находиться в квадрате 2 на 2.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            is_error = true;
                            break;
                        }
                    }

                    int number_cells_around = 0;
                    if (i % 15 != 0 && m_cells[i - 1].Letter != null) number_cells_around++;
                    if (i % 15 != 14 && m_cells[i + 1].Letter != null) number_cells_around++;
                    if (i > 14 && m_cells[i - 15].Letter != null) number_cells_around++;
                    if (i < 210 && m_cells[i + 15].Letter != null) number_cells_around++;
                    if (number_cells_around == 0)
                    {
                        MessageBox.Show("Недопустимое расположение букв!\nВсе буквы должны соприкасаться между собой.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        is_error = true;
                        break;
                    }

                    
                    if (m_cells[i].Letter.LetterType == LetterType.Board) 
                    {
                        first_finded_letter_cell_id = i;
                        if (i % 15 != 0 && m_cells[i - 1].Letter != null) 
                        {
                            if (m_cells[i - 1].Letter.LetterType == LetterType.Fixed) 
                            {
                                is_any_border_letter_near_fixed_letter = true; 
                            }
                            if (was_direction_checked && is_direction_horizontal == false) 
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i - 1].Letter.LetterType == LetterType.Fixed) 
                                {
                                    if ((i - 1) % 15 != 0 && m_cells[i - 2].Letter != null) 
                                    {
                                        if (m_cells[i - 2].Letter.LetterType == LetterType.Fixed) 
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = true;
                            }
                        }
                        if (i % 15 != 14 && m_cells[i + 1].Letter != null) 
                        {
                            if (m_cells[i + 1].Letter.LetterType == LetterType.Fixed) 
                            {
                                is_any_border_letter_near_fixed_letter = true; 
                            }
                            if (was_direction_checked && is_direction_horizontal == false) 
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i + 1].Letter.LetterType == LetterType.Fixed) 
                                {
                                    if ((i + 1) % 15 != 14 && m_cells[i + 2].Letter != null) 
                                    {
                                        if (m_cells[i + 2].Letter.LetterType == LetterType.Fixed) 
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = true;
                            }
                        }
                        if (i > 14 && m_cells[i - 15].Letter != null) 
                        {
                            if (m_cells[i - 15].Letter.LetterType == LetterType.Fixed) 
                            {
                                is_any_border_letter_near_fixed_letter = true; 
                            }
                            if (was_direction_checked && is_direction_horizontal == true) 
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i - 15].Letter.LetterType == LetterType.Fixed) 
                                {
                                    if ((i - 15) > 14 && m_cells[i - 30].Letter != null) 
                                    {
                                        if (m_cells[i - 30].Letter.LetterType == LetterType.Fixed) 
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = false;
                            }
                        }
                        if (i < 210 && m_cells[i + 15].Letter != null) // если ячейка снизу содержит букву
                        {
                            if (m_cells[i + 15].Letter.LetterType == LetterType.Fixed) // если ячейка слева была добавлена игроками ранее
                            {
                                is_any_border_letter_near_fixed_letter = true; // добавляемое игроком слово соприкасается с предыдущими
                            }
                            if (was_direction_checked && is_direction_horizontal == true) // если известно, что направление добавляемого игроком слова - горизонтальное
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i + 15].Letter.LetterType == LetterType.Fixed) // если ячейка снизу содержит букву, добавленную игроками ранее
                                {
                                    if ((i + 15) < 210 && m_cells[i + 30].Letter != null) // если ячейка снизу снизу содержит букву
                                    {
                                        if (m_cells[i + 30].Letter.LetterType == LetterType.Fixed) // если ячейка снизу снизу содержит букву, добавленную игроками ранее
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = false;
                            }
                        }
                    }
                }
            }

            if (!is_error) // если ошибки ещё не возникло
            {
                if (!m_was_first_word) // если добавляемое слово - первое
                {
                    if (m_cells[112].Letter == null) // если центральная ячейка не была задействована
                    {
                        MessageBox.Show("Первое слово должно пересекать центр поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        is_error = true;
                    }
                }
                else // если добавляемое слово - не первое
                {
                    if (!is_any_border_letter_near_fixed_letter) // если добавляемое игроком слово не соприкасается с предыдущими
                    {
                        MessageBox.Show("Новое слово должно пересекать ранее добавленные слова!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        is_error = true;
                    }
                }

                if (!is_error) // если ошибки ещё не возникло
                {
                    int first_word_cell_id = first_finded_letter_cell_id; // переменная, обозначающая ID ячейки первой буквы слова
                    if (is_direction_horizontal) // если направление слова - горизонтальное
                    {
                        while (first_word_cell_id % 15 != 0 && m_cells[first_word_cell_id - 1].Letter != null) // двигаемся влево по слову
                        {
                            first_word_cell_id--;
                        }
                    }
                    else // если направление слова - вертикальное
                    {
                        while (first_word_cell_id > 14 && m_cells[first_word_cell_id - 15].Letter != null) // двигаемся вверх по слову
                        {
                            first_word_cell_id -= 15;
                        }
                    }

                    List<Letter> word_letters = new List<Letter>();
                    int i2 = first_word_cell_id;
                    while (true)
                    {
                        word_letters.Add(new Letter(m_cells[i2].Letter.Symbol));
                        if (is_direction_horizontal) // если направление слова - горизонтальное
                        {
                            i2++; // перемещаемся к букве справа
                            if (i2 % 15 == 0 || m_cells[i2].Letter == null) break; // если достигнут конец слова - разрыв цикла
                        }
                        else // если направление слова - вертикальное
                        {
                            i2 += 15; 
                            if (i2 >= 225 || m_cells[i2].Letter == null) break; 
                        }
                    };

                    string word = ""; // слово
                    string text = ""; // выводимый текст
                    int points = 0; 
                    i2 = first_word_cell_id; // id проверяемой ячейки слова
                    for (int i = 0; i < word_letters.Count; i++)
                    {
                        word += word_letters[i].Symbol;
                        if (i2 != first_word_cell_id)
                        {
                            text += " + ";
                        }
                        text += word_letters[i].Points.ToString();
                        if (m_cells[i2].CellType == CellType.Green)
                        {
                            word_letters[i].Points *= 2;
                            text += " * 2";
                        }
                        else if (m_cells[i2].CellType == CellType.Yellow)
                        {
                            word_letters[i].Points *= 3;
                            text += " * 3";
                        }
                        points += word_letters[i].Points;

                        if (is_direction_horizontal) 
                        {
                            i2++; 
                        }
                        else 
                        {
                            i2 += 15; 
                        }
                    }


                    bool is_word_in_dictionary = false;
                    string path = @"C:\Users\Acer\source\repos\ConsoleApp7\words.txt";

                    try
                    {
                        if (System.IO.File.Exists(path))
                        {
                            using (StreamReader sr = new StreamReader(path))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    Debug.WriteLine($"Comparing: {word} and {line}");

                                    if ((word == line) || (word + '\r' == line))
                                    {
                                        is_word_in_dictionary = true;
                                        break;
                                    }
                                }
                            }

                            if (!is_word_in_dictionary)
                            {
                                MessageBox.Show("Слово не найдено в словаре!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                            }
                        }
                        else
                        {
                            throw new FileNotFoundException($"Файл {path} не найден.");
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        is_error = true;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show($"Отсутствуют права доступа к файлу: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        is_error = true;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Ошибка ввода/вывода: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        is_error = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Необработанное исключение: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        is_error = true;
                    }


                    if (!is_error) 
                    {
                        
                        for (int i = 0; i < 225; i++) 
                        {
                            if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board) 
                            {
                                m_cells[i].Letter.LetterType = LetterType.Fixed; 
                            }
                        }

                        m_was_first_word = true;

                        i2 = first_word_cell_id;
                        for (int i = 0; i < word_letters.Count; i++)
                        {
                            if (m_cells[i2].CellType == CellType.Blue)
                            {
                                points *= 2;
                                text = "(" + text + ")  * 2";
                            }
                            else if (m_cells[i2].CellType == CellType.Red)
                            {
                                points *= 3;
                                text = "(" + text + ") * 3";
                            }

                            if (is_direction_horizontal) 
                            {
                                i2++; 
                            }
                            else 
                            {
                                i2 += 15; 
                            }
                        }
                        text += " = " + points + " баллов";

                        m_players[m_total_moving_player_id].Points += points;

                        for (int i = 0; i < 225; i++) 
                        {
                            if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board) 
                            {
                                m_cells[i].Letter.LetterType = LetterType.Fixed;
                            }
                        }
                        text = m_players[m_total_moving_player_id].Name + " составил слово \"" + word + "\":\n" + text;
                        MessageBox.Show(text, "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (PointsLimit != -1) 
                        {
                            if (m_players[m_total_moving_player_id].Points >= PointsLimit) 
                            {
                                button_end_game.PerformClick(); 
                                return;
                            }
                        }

                        NextPlayerMove(); 
                    }
                }
            }

            if (is_error) 
            {
                for (int i = 0; i < 225; i++) 
                {
                    if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board) 
                    {
                       
                        for (int i2 = 0; i2 < 7; i2++)
                        {
                            if (m_players[m_total_moving_player_id].Cells[i2].Letter == null)
                            {
                                m_players[m_total_moving_player_id].Cells[i2].Letter = m_cells[i].Letter;
                                m_cells[i].Letter = null;
                                break;
                            }
                        }
                    }
                }
            }
        }

        
        private void button_skip_Click(object sender, EventArgs e)
        {
            NextPlayerMove(); 
        }

        
        private void button_end_game_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        
        private void update_timer_Tick(object sender, EventArgs e)
        {
            Refresh(); 
        }

        
        /// <param name="external_rec">Прямоугольник</param>
        /// <param name="external_brush">Кисть</param>
        public void DrawRectagle(PaintEventArgs e, Rectangle external_rec, Brush external_brush)
        {
            e.Graphics.FillRectangle(external_brush, external_rec); 
        }

      
        /// <param name="external_rec">Прямоугольник</param>
        /// <param name="external_brush">Кисть границы</param>
        /// <param name="internal_brush">Кисть заливки</param>
        /// <param name="border_size">Толщина границы</param>
        public void DrawRectagle(PaintEventArgs e, Rectangle external_rec, Brush external_brush, Brush internal_brush, int border_size)
        {
            e.Graphics.FillRectangle(external_brush, external_rec); 
            Size internal_size = new Size(external_rec.Width - border_size * 2, external_rec.Height - border_size * 2);
            Point internal_location = new Point(external_rec.X + border_size, external_rec.Y + border_size);
            Rectangle internal_rec = new Rectangle(internal_location, internal_size);
            e.Graphics.FillRectangle(internal_brush, internal_rec); 
        }

        /// <summary>Рисует текст в указанной прямоугольной области</summary>
        /// <param name="external_rec">Прямоугольная область, в которой будет расположен текст</param>
        /// <param name="text_brush">Цвет текста</param>
        /// <param name="text">Текст</param>
        /// <param name="k">Коэффициент (0-1) размера текста от высоты прямоугольной области<
        public void DrawText(PaintEventArgs e, Rectangle external_rec, Brush text_brush, string text, double k = 0.5)
        {
            StringFormat format = new StringFormat(); 
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(text, new Font("Segoe WP Black", (float)(external_rec.Height * k), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), text_brush, external_rec, format); // рисовка текста
        }

        /// <summary>Создаёт игроков в этой форме</summary>
        /// <param name="is_player_1">Участвует ли игрок 1 в игре</param>
        /// <param name="name_player_1">Имя игрока 1</param>
        /// <param name="is_player_2">Участвует ли игрок 2 в игре</param>
        /// <param name="name_player_2">Имя игрока 2</param>
        /// <param name="is_player_3">Участвует ли игрок 3 в игре</param>
        /// <param name="name_player_3">Имя игрока 3</param>
        /// <param name="is_player_4">Участвует ли игрок 4 в игре</param>
        /// <param name="name_player_4">Имя игрока 4</param>
        public void CreatePlayers(bool is_player_1 = true, string name_player_1 = "", bool is_player_2 = true, string name_player_2 = "", bool is_player_3 = true, string name_player_3 = "", bool is_player_4 = true, string name_player_4 = "")
        {
          
            if (name_player_1.Split(' ')[0].Length == 0) name_player_1 = "Игрок 1";
            if (name_player_2.Split(' ')[0].Length == 0) name_player_2 = "Игрок 2";
            if (name_player_3.Split(' ')[0].Length == 0) name_player_3 = "Игрок 3";
            if (name_player_4.Split(' ')[0].Length == 0) name_player_4 = "Игрок 4";

            

            if (is_player_1) m_players[0] = new Player(name_player_1);
            else m_players[0] = null;

            if (is_player_2) m_players[1] = new Player(name_player_2);
            else m_players[1] = null;

            if (is_player_3) m_players[2] = new Player(name_player_3);
            else m_players[2] = null;

            if (is_player_4) m_players[3] = new Player(name_player_4);
            else m_players[3] = null;
        }

       
        private void NextPlayerMove()
        {
            m_total_turn++;

           
            for (int i = 0; i < 225; i++)
            {
                if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board)
                {
                    m_cells[i].Letter = null;
                }
            }
            m_id_total_clicked_cell = -1;

            if (m_total_moving_player_id == -1) 
            {
                
                for (int i2 = 0; i2 < 4; i2++) 
                {
                    if (m_players[i2] != null) 
                    {
                        for (int i = 0; i < 7; i++) 
                        {
                            if (m_players[i2].Cells[i].Letter == null) 
                            {
                                m_players[i2].Cells[i].Letter = Letter.GetRandomLetter(m_random);
                            }
                        }
                    }
                }
            }
            else 
            {
                
                for (int i = 0; i < 7; i++) 
                {
                    if (m_players[m_total_moving_player_id].Cells[i].Letter == null) 
                    {
                        m_players[m_total_moving_player_id].Cells[i].Letter = Letter.GetRandomLetter(m_random); 
                    }
                }
            }

          
            do
            {
                m_total_moving_player_id++;
                if (m_total_moving_player_id == 4) m_total_moving_player_id = 0; 
            }
            while (m_players[m_total_moving_player_id] == null);

          
            GroupBox[] group_boxes = new GroupBox[4];
            group_boxes[0] = groupBox_player_1;
            group_boxes[1] = groupBox_player_2;
            group_boxes[2] = groupBox_player_3;
            group_boxes[3] = groupBox_player_4;

            PictureBox[] picture_boxes = new PictureBox[4];
            picture_boxes[0] = pictureBox_player_1;
            picture_boxes[1] = pictureBox_player_2;
            picture_boxes[2] = pictureBox_player_3;
            picture_boxes[3] = pictureBox_player_4;

            
            for (int i = 0; i < 4; i++)
            {
                if (m_players[i] != null)
                {
                    if (i == m_total_moving_player_id)
                    {
                        group_boxes[i].Enabled = true;
                         if (i == 0) pictureBox_player_1.Image = Image.FromFile(@"C:\Users\Acer\source\repos\ConsoleApp7\Resourse\player1.png");
                        else if (i == 1) pictureBox_player_2.Image = Image.FromFile(@"C:\Users\Acer\source\repos\ConsoleApp7\Resourse\player2.png");
                        else if (i == 2) pictureBox_player_3.Image = Image.FromFile(@"C:\Users\Acer\source\repos\ConsoleApp7\Resourse\player3.png");
                        else if (i == 3) pictureBox_player_4.Image = Image.FromFile(@"C:\Users\Acer\source\repos\ConsoleApp7\Resourse\player4.png");
                    }
                      else
                      {
                          group_boxes[i].Enabled = false;
                        
                    }
                }
            }

                if (m_players[0] != null) label_points_player_1.Text = m_players[0].Points.ToString();
                if (m_players[1] != null) label_points_player_2.Text = m_players[1].Points.ToString();
                if (m_players[2] != null) label_points_player_3.Text = m_players[2].Points.ToString();
                if (m_players[3] != null) label_points_player_4.Text = m_players[3].Points.ToString();
            }

       
    }
    }


