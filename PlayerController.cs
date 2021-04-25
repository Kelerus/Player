using System;
using System.Collections.Generic;

namespace Players
{
    class PlayerController
    {
        private List<Player> players = new List<Player>();

        private GroupController group = new GroupController();
        private string[] pl = new string[] {"Kelerus", "James"};


        public List<Player> Players()
        {
            return players;
        }

        /// <summary>Генерация стартовых игроков</summary>
        public PlayerController()
        {
            players.Add(new Player(pl[0], 0, group.Groups()[0]));
            players.Add(new Player(pl[1], 0, group.Groups()[3]));
        }

        /// <summary>Добавить игрока</summary>
        /// <param name="name">Имя игрока</param>
        public void Add(string name)
        {
            if(CheckPlayer(name))
            {
                players.Add(new Player(name, 0, group.Groups()[0]));
            }
            
        }

        public void Add(string name, int _group)
        {
            if(CheckPlayer(name))
            {
                players.Add(new Player(name, group.Groups()[_group]));
            }
            
        }

        /// <summary>Добавить игрока</summary>
        /// <param name="name">Имя игрока</param>
        /// <param name="difficult">Сложность игрока</param>
        /// <param name="group">Класс игрока</param>
        public void Add(string name, int difficult, int _group)
        {
            if(CheckPlayer(name))
            {
                players.Add(new Player(name, difficult, group.Groups()[_group]));
            }
            
        }

        public string Remove(string name)
        {
            foreach (var item in players)
            {
                if(item.Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                   players.Remove(item);
                   return "Успешно";
                }
                
            }
            throw new ArgumentException("Такого игрока нету для удаления", nameof(name));
        }

        public bool CheckPlayer(string name)
        {
            foreach (var item in players)
            {
                if(item.Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                    throw new ArgumentException("Такой игрок уже существует", nameof(name));
                }
            }
            return true;
        }

        // private Group SetGroup(int idArray)
        // {
            
        //     foreach(var item in group.Groups())
        //     {
        //         if(item.Name.ToLower().TrimStart().TrimEnd() == group.Groups()[idArray].Name.ToLower().TrimStart().TrimEnd())
        //         {
        //             return item.Name;
        //         }
        //     }
        //     throw new ArgumentException("Id такой группы не существует", nameof(idArray));
        // }

    }
}