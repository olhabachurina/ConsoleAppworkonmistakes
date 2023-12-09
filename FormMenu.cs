using System;
using System.Windows.Forms;

namespace ConsoleApp7
{
    /// <summary>Форма главного меню</summary>
    public partial class FormMenu : Form
    {
        /// <summary>Конструктор формы</summary>
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary>Событие нажатия на кнопку "Играть"</summary>
        private void button_play_Click(object sender, EventArgs e)
        {
            FormSettings form_settings = new FormSettings(); 
            form_settings.Owner = this;
            form_settings.Show(); 
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close(); 
        }

               
    }
}
