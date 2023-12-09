namespace ConsoleApp7
{
    partial class FormResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_play = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_caption = new System.Windows.Forms.Label();
            this.label_points_player_4 = new System.Windows.Forms.Label();
            this.label_points_player_3 = new System.Windows.Forms.Label();
            this.label_points_player_1 = new System.Windows.Forms.Label();
            this.label_points_player_2 = new System.Windows.Forms.Label();
            this.label_name_player_4 = new System.Windows.Forms.Label();
            this.label_name_player_3 = new System.Windows.Forms.Label();
            this.label_name_player_2 = new System.Windows.Forms.Label();
            this.label_name_player_1 = new System.Windows.Forms.Label();
            this.pictureBox_player_4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_player_3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_player_2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_player_1 = new System.Windows.Forms.PictureBox();
            this.label_time = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_play
            // 
            this.button_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_play.Location = new System.Drawing.Point(1065, 452);
            this.button_play.Margin = new System.Windows.Forms.Padding(4);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(364, 78);
            this.button_play.TabIndex = 6;
            this.button_play.Text = "Играть ещё раз";
            this.button_play.UseVisualStyleBackColor = false;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(39, 452);
            this.button_exit.Margin = new System.Windows.Forms.Padding(4);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(357, 78);
            this.button_exit.TabIndex = 5;
            this.button_exit.Text = "Выйти в меню";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label_caption);
            this.groupBox1.Controls.Add(this.label_points_player_4);
            this.groupBox1.Controls.Add(this.label_points_player_3);
            this.groupBox1.Controls.Add(this.label_points_player_1);
            this.groupBox1.Controls.Add(this.label_points_player_2);
            this.groupBox1.Controls.Add(this.label_name_player_4);
            this.groupBox1.Controls.Add(this.label_name_player_3);
            this.groupBox1.Controls.Add(this.label_name_player_2);
            this.groupBox1.Controls.Add(this.label_name_player_1);
            this.groupBox1.Controls.Add(this.pictureBox_player_4);
            this.groupBox1.Controls.Add(this.pictureBox_player_3);
            this.groupBox1.Controls.Add(this.pictureBox_player_2);
            this.groupBox1.Controls.Add(this.pictureBox_player_1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(1432, 425);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результаты игры";
            // 
            // label_caption
            // 
            this.label_caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_caption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_caption.Location = new System.Drawing.Point(21, 53);
            this.label_caption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_caption.Name = "label_caption";
            this.label_caption.Size = new System.Drawing.Size(1389, 69);
            this.label_caption.TabIndex = 18;
            this.label_caption.Text = "Игра окончена!";
            this.label_caption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_points_player_4
            // 
            this.label_points_player_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_points_player_4.Location = new System.Drawing.Point(1124, 366);
            this.label_points_player_4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_points_player_4.Name = "label_points_player_4";
            this.label_points_player_4.Size = new System.Drawing.Size(287, 43);
            this.label_points_player_4.TabIndex = 16;
            this.label_points_player_4.Text = "0 баллов";
            this.label_points_player_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_points_player_3
            // 
            this.label_points_player_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_points_player_3.Location = new System.Drawing.Point(753, 366);
            this.label_points_player_3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_points_player_3.Name = "label_points_player_3";
            this.label_points_player_3.Size = new System.Drawing.Size(287, 43);
            this.label_points_player_3.TabIndex = 15;
            this.label_points_player_3.Text = "0 баллов";
            this.label_points_player_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_points_player_1
            // 
            this.label_points_player_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_points_player_1.Location = new System.Drawing.Point(21, 366);
            this.label_points_player_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_points_player_1.Name = "label_points_player_1";
            this.label_points_player_1.Size = new System.Drawing.Size(287, 43);
            this.label_points_player_1.TabIndex = 14;
            this.label_points_player_1.Text = "0 баллов";
            this.label_points_player_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_points_player_2
            // 
            this.label_points_player_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_points_player_2.Location = new System.Drawing.Point(387, 366);
            this.label_points_player_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_points_player_2.Name = "label_points_player_2";
            this.label_points_player_2.Size = new System.Drawing.Size(287, 43);
            this.label_points_player_2.TabIndex = 13;
            this.label_points_player_2.Text = "0 баллов";
            this.label_points_player_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_name_player_4
            // 
            this.label_name_player_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_player_4.Location = new System.Drawing.Point(1125, 137);
            this.label_name_player_4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_name_player_4.Name = "label_name_player_4";
            this.label_name_player_4.Size = new System.Drawing.Size(287, 31);
            this.label_name_player_4.TabIndex = 12;
            this.label_name_player_4.Text = "Игрок 4";
            this.label_name_player_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_name_player_3
            // 
            this.label_name_player_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_player_3.Location = new System.Drawing.Point(753, 137);
            this.label_name_player_3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_name_player_3.Name = "label_name_player_3";
            this.label_name_player_3.Size = new System.Drawing.Size(287, 31);
            this.label_name_player_3.TabIndex = 11;
            this.label_name_player_3.Text = "Игрок 3";
            this.label_name_player_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_name_player_2
            // 
            this.label_name_player_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_player_2.Location = new System.Drawing.Point(387, 137);
            this.label_name_player_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_name_player_2.Name = "label_name_player_2";
            this.label_name_player_2.Size = new System.Drawing.Size(287, 31);
            this.label_name_player_2.TabIndex = 10;
            this.label_name_player_2.Text = "Игрок 2";
            this.label_name_player_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_name_player_1
            // 
            this.label_name_player_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_player_1.Location = new System.Drawing.Point(21, 137);
            this.label_name_player_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_name_player_1.Name = "label_name_player_1";
            this.label_name_player_1.Size = new System.Drawing.Size(287, 31);
            this.label_name_player_1.TabIndex = 9;
            this.label_name_player_1.Text = "Игрок 1";
            this.label_name_player_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox_player_4
            // 
            this.pictureBox_player_4.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_player_4.Location = new System.Drawing.Point(1125, 174);
            this.pictureBox_player_4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox_player_4.Name = "pictureBox_player_4";
            this.pictureBox_player_4.Size = new System.Drawing.Size(287, 181);
            this.pictureBox_player_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_4.TabIndex = 8;
            this.pictureBox_player_4.TabStop = false;
            // 
            // pictureBox_player_3
            // 
            this.pictureBox_player_3.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_player_3.Location = new System.Drawing.Point(753, 174);
            this.pictureBox_player_3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox_player_3.Name = "pictureBox_player_3";
            this.pictureBox_player_3.Size = new System.Drawing.Size(287, 181);
            this.pictureBox_player_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_3.TabIndex = 7;
            this.pictureBox_player_3.TabStop = false;
            // 
            // pictureBox_player_2
            // 
            this.pictureBox_player_2.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_player_2.Location = new System.Drawing.Point(387, 174);
            this.pictureBox_player_2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox_player_2.Name = "pictureBox_player_2";
            this.pictureBox_player_2.Size = new System.Drawing.Size(287, 181);
            this.pictureBox_player_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_2.TabIndex = 6;
            this.pictureBox_player_2.TabStop = false;
            // 
            // pictureBox_player_1
            // 
            this.pictureBox_player_1.BackColor = System.Drawing.Color.White;
            this.pictureBox_player_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_player_1.Location = new System.Drawing.Point(21, 174);
            this.pictureBox_player_1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox_player_1.Name = "pictureBox_player_1";
            this.pictureBox_player_1.Size = new System.Drawing.Size(287, 181);
            this.pictureBox_player_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_player_1.TabIndex = 4;
            this.pictureBox_player_1.TabStop = false;
            // 
            // label_time
            // 
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time.Location = new System.Drawing.Point(404, 452);
            this.label_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(653, 78);
            this.label_time.TabIndex = 17;
            this.label_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1497, 550);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "\"Мир освещается солнцем, а человек — знанием!\"";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormResult_FormClosed);
            this.Load += new System.EventHandler(this.FormResult_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox_player_4;
        private System.Windows.Forms.PictureBox pictureBox_player_3;
        private System.Windows.Forms.PictureBox pictureBox_player_2;
        private System.Windows.Forms.PictureBox pictureBox_player_1;
        private System.Windows.Forms.Label label_points_player_4;
        private System.Windows.Forms.Label label_points_player_3;
        private System.Windows.Forms.Label label_points_player_1;
        private System.Windows.Forms.Label label_points_player_2;
        private System.Windows.Forms.Label label_name_player_4;
        private System.Windows.Forms.Label label_name_player_3;
        private System.Windows.Forms.Label label_name_player_2;
        private System.Windows.Forms.Label label_name_player_1;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_caption;
    }
}