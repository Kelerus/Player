using System;
using System.Collections.Generic;

namespace Players
{
    class GroupController
    {
        private List<Group> groups = new List<Group>();

        private string[] gr = new string[] {"Помощь","Атака","Фланг","Танк"};

        public GroupController()
        {
            foreach(var item in gr)
            {
                groups.Add(new Group(item));
            }
        }

        public List<Group> Groups()
        {
            return groups;
        }

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

        public Group GetGroup(string name)
        {
            foreach(var item in groups)
            {
                if(item.Name.ToLower().TrimStart().TrimEnd() == name.ToLower().TrimStart().TrimEnd())
                {
                    return item;
                }
            }
            throw new Exception("Такой группы не существует");
        }
    }
}