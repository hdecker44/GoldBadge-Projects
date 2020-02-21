using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Menu
    {

        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; private set; }
        public decimal Price { get; set; }

        public Menu() { }
        public Menu(int number, string name, string description, List<string> attachments, decimal price)
        {
            Number = number;
            Name = name;
            Description = description;
            Attachments = attachments;
            Price = price;
        }
    }

}
