using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_2._0
{
    public enum Gender
    {
        male,
        female
    }
    internal class Human
    {
        internal string Name { get; set; }
        internal string Surname { get; set; }
        string Gender;
        DateTime Birthday;
        Human Father;
        Human Mother;
        List<Human> Childs;
        Human husband { get; set; }
        Human wife { get; set; }
        public Human(string name, string surname, Enum gender, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Gender = gender.ToString();
            Birthday = birthday;
            Childs = new List<Human>();
        }

        internal void AddWife(Human wife)
        {
            this.wife = wife;
        }

        internal void AddHusband(Human husband)
        {
            this.husband = husband;
        }

        internal void AddChild(Human child)
        {
            Childs.Add(child);
        }

        internal void AddFather(Human father)
        {
            Father = father;
        }
        internal void AddMother(Human mother)
        {
            Mother = mother;
        }


        internal string PrintInfo()
        {
            return $" {this} ";
        }
        internal string PrintFather()
        {
            return $"Отец = {Father}";
        }

        internal string PrintMother()
        {
            return $"Мать = {Mother}";
        }

        internal void PrintChilds()
        {
            if (Childs.Count > 0)
            {
                foreach (var child in Childs)
                {
                    Console.WriteLine(child);
                }
            }
        }

        internal string PrintHusband()
        {
            return $"Муж:\t {husband}\n";
        }

        internal string PrintWife()
        {
            return $"Жена:\t {wife}\n";
        }

        internal void PrintGenealogicTree()
        {
            PrintInfo();
            if (Childs is not null)
            {
                foreach (var child in Childs)
                {
                    if (child.Childs is not null)
                        if (husband is not null)
                            child.husband.PrintInfo();
                    if (wife is not null)
                        child.wife.PrintInfo();
                    PrintGenealogicTree();
                }
            }
        }

        public override string ToString()
        {
            return $"Имя = {Name}" +
                $" \n\t Фамилия = {Surname}" +
                $" \n\t Пол = {Gender}\n" +
                $"\t Дата рождения = {Birthday}";
        }
    }

}
