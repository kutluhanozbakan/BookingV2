using BookingV2.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingV2.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public ICollection<Book> Books { get;  set; }

        public Author(string name = "", string surname = "")
        {
            Name = name;
            Surname = surname;
            Books = new List<Book>();
        }
    }
}
