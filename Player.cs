namespace ConsoleApp7
{
    /// <summary>Игрок</summary>
    public class Player
    {
        /// <summary>Имя игрока</summary>
        private string m_name;

        /// <summary>Имя игрока</summary>
        public string Name
        {
            get
            {
                return m_name;
            }
        }

      
        public int Points;

        
        public Cell[] Cells;

        
    
        public Player(string name)
        {
            m_name = name;

            Points = 0;

            Cells = new Cell[7];
            for (int i = 0; i < 7; i++)
            {
                Cells[i] = new Cell(CellType.White);
            }
        }
        
    }
}
