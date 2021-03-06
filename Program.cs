using System;
using System.IO;
using System.Threading;

namespace Players
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Конструкторы
            GroupController groups = new GroupController();
            PlayerController players = new PlayerController();
            #endregion

            Console.WriteLine("\n\nДобро пожаловать выберите действие\n\n");
            
            bool programbool = true; // переменная для остановки программы

            while(programbool)
            {
                Menu(groups, players); // Запуск самой программы
                Console.WriteLine("\n\nНажмите любую кнопку для продолжения...\n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Или пропишите \"exit\" чтобы выйти из программы");
                string exit = Console.ReadLine(); // Проверка для выхода из программы
                Console.ResetColor();
                if(exit == "exit")
                {
                    programbool = false;
                }
            }

        }
        /// <summary>Меню программы</summary>
        /// <param name="_group">Конструктор класса</param>
        /// <param name="_players">Конструктор игроков</param>
        private static void Menu(GroupController _groups, PlayerController _players)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Просмотр всех игроков - \"all players\"\n");

            Console.WriteLine("Добавить нового игрока - \"add player\"\n");

            Console.WriteLine("Удалить игрока - \"del player\"\n");

            Console.WriteLine("Просмотр всех групп - \"all groups\"\n");

            Console.WriteLine("Добавить новую группу - \"add group\"\n");

            Console.WriteLine("Удалить группу - \"del group\"\n");

            Console.WriteLine("Очистить консоль - \"clear\"\n");

            Console.ResetColor();

            switch (Console.ReadLine())
            {
                case "all players":
                    PrintPlayers(_players);
                    break;

                case "add player":
                    AddPlayer(_players);
                    break;

                case "del player":
                    DelPlayer(_players);
                    break;
                
                case "all groups":
                    PrintGroups(_groups);
                    break;

                case "add group":
                    AddGroup(_groups);
                    break;

                case "del group":
                    DelGroup(_groups);
                    break;

                case "clear":
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Вы ничего не выбрали или допустили ошибку в написание команды\n\n"); break;
            }
            

        }
        /// <summary>Вывод в консоль название классов</summary>
        /// <param name="controller">Конструктор класса</param>
        private static void PrintGroups(GroupController controller)
        {
            foreach (var item in controller.Groups())
            {
                Console.WriteLine($"Название класса: {item.Name}");
            }
        }
        /// <summary>Вывод в консоль информации об игроке</summary>
        /// <param name="controller">Конструктор игрока</param>
        private static void PrintPlayers(PlayerController controller)
        {
            foreach (var item in controller.Players())
            {
                Console.WriteLine($"Имя: {item.Name}, Сложность: {item.Difficult}, Класс: {item.Group.Name}, Здоровье: {item.Health}");
            }
        }
        /// <summary>Добавление нового игрока в программу</summary>
        /// <param name="controller">Конструктор игрока</param>
        private static void AddPlayer(PlayerController _player)
        {
            string _namePlayer, _idGroup, _difficult;

            Console.WriteLine("Введите имя игрока:");
            _namePlayer = Console.ReadLine();
            Console.WriteLine("Введите класс игрока:");
            _idGroup = Console.ReadLine();
            Console.WriteLine("Введите сложность для игрока:");
            _difficult = Console.ReadLine();
            #region Проверки и разные опции
            if(string.IsNullOrWhiteSpace(_namePlayer))
            {
                Console.WriteLine($"Игрок не может быть без имени");
                return;
            }

            if(string.IsNullOrWhiteSpace(_idGroup) && string.IsNullOrWhiteSpace(_difficult))
            {
                _player.Add(_namePlayer);
                PrintPlayers(_player);
            }

            if(string.IsNullOrWhiteSpace(_difficult))
            {
                try 
                {
                    _player.Add(_namePlayer, Convert.ToInt16(_idGroup));
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Добавление класса можно только по цифре");
                    Console.ResetColor();
                }
            }
            else
            {
                try
                {
                    _player.Add(_namePlayer, Convert.ToInt16(_difficult), Convert.ToInt16(_idGroup));
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Добавление класса можно только по цифре");
                    Console.WriteLine("Добавление сложности можно только по цифре");
                    Console.ResetColor();
                }
            }
            #endregion
        }
        /// <summary>Удаление игрока из программы</summary>
        /// <param name="controller">Конструктор игрока</param>
        private static void DelPlayer(PlayerController _players)
        {
            Console.WriteLine("Введите имя игрока:");
            string name = Console.ReadLine();
            _players.Remove(name);
        }
        /// <summary>Добавление нового класса в программу</summary>
        /// <param name="controller">Конструктор класса</param>
        private static void AddGroup(GroupController _groups)
        {
            Console.WriteLine("Введите название класса:");
            string name = Console.ReadLine();
            _groups.Add(name);
        }
        /// <summary>Удаление класса из программы</summary>
        /// <param name="controller">Конструктор класса</param>
        private static void DelGroup(GroupController _groups)
        {
            Console.WriteLine("Введите название группы:");
            string name = Console.ReadLine();
            _groups.Remove(name);
        }
    }
}
