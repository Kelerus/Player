using System;

namespace Players
{
    public class Group
    {
        public string Name {get; private set;}
        /// <summary>Конструктор Класса</summary>
        /// <param name="name">Название класса</param>
        public Group(string _name)
        {
            if(string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentNullException("Группа не может быть пустой или содержать только пробелы", nameof(_name));
            }
            if(_name.Length >= 15)
            {
                throw new ArgumentException("Название группы не может быть больше 15 символов", nameof(_name));
            }
            Name = _name;
        }
    }
}