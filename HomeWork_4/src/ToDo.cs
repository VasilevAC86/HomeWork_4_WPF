using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4.src
{
    public class ToDo
    {
        public bool Doing { get; set; } // Хранение инф-ии выполненно ли дело (true - выполнено, false - нет)
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }        
        public ToDo() 
        {
            Doing = false;
        }
        public ToDo(string title, DateTime date, string description, bool doind) 
        { 
            this.Title = title;
            this.Date = date;
            this.Description = description;
            this.Doing = doind;
        }     
    }
}
