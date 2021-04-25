using System;

namespace Players
{
    public class Player
    {
        public string Name {get; private set;}

        public int Health {get; private set;}

        public int Difficult {get; private set;}

        public Group Group {get; private set;}
        #region Конструкторы
        public Player()
        {
            Name = "NoName";
            Health = 100;
            Difficult = 0;
            Group = new Group("NoGroup");
        }

        public Player(string _name) :this()
        {
            if(string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentNullException("Имя игрока не может быть пустым или содержать только пробелы", nameof(_name));
            }
            Name = _name;
        }

        public Player(string _name, int _difficult) :this()
        {
            if(_difficult > 3 || _difficult < 0)
            {
                throw new ArgumentException("Сложность у игрока не может быть больше 3 или меньше 0", nameof(_difficult));
            }
            Name = _name;
            Difficult = _difficult;
        }

        public Player(string _name, Group _group) :this()
        {
            Name = _name;
            Difficult = RandomDiff();
            Group = _group;

        }

        public Player(string _name, int _difficult, Group _group) :this()
        {
            Name = _name;
            Difficult = _difficult;
            Group = _group;
        }
        #endregion
        /// <summary>Создание рандомной сложности</summary>
        public int RandomDiff()
        {
            Random random = new Random();
            int diff = random.Next(0, 3);
            return diff;
        }

    }
}