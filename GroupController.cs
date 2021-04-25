using System;
using System.Collections.Generic;

namespace Players
{
    class GroupController
    {
        private List<Group> groups = new List<Group>(); // лист с классами

        private string[] gr = new string[] {"Помощь","Атака","Фланг","Танк"}; // Классы по умолчанию для тестов

        public GroupController()
        {
            foreach(var item in gr)
            {
                groups.Add(new Group(item));
            }
        }
        /// <summary>Обращение к конкретному классу</summary>
        public List<Group> Groups()
        {
            return groups;
        }
        /// <summary>Добавление нового класса</summary>
        /// <param name="name">Название класса</param>
        public void Add(string name) 
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Группа не может быть пустой");
                return;
            }
            if(IsRepetGroup(name))
            {
                throw new ArgumentException("Такая группа уже существует", nameof(name));
            }
            groups.Add(new Group(name));
        }
        /// <summary>Проверка на повторение класса</summary>
        /// <param name="name">Название класса</param>
        public bool IsRepetGroup(string name)
        {
            foreach(var item in groups)
            {
                if(item.Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>Удаление класса</summary>
        /// <param name="name">Название класса</param>
        public string Remove(string name)
        {
            foreach(var item in groups)
            {
                if(item.Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                    groups.Remove(item);
                    return "Успешно";
                }
            }
            throw new ArgumentException("Нет такой группы для удаления");
        }
    }
}